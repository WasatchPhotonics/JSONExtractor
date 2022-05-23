using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace JSONExtractor
{
    /// <summary>
    /// Definition of  one attribute being output from the sample files.
    /// </summary>
    /// <remarks>
    /// There are various ways we could save memory in TableRows and TableCols.  
    /// TableRows could be cached to a tempfile as we go, then merely copied-over
    /// at the end.  TableCols could be done the same way, then transposed during
    /// final copy.  However, presumably they're going to open the CSV after
    /// generation, so either they have the RAM or they don't.
    /// </remarks>
    /// <todo>
    /// - break out ExtractTable?
    /// </todo>
    class ExtractAttribute
    {
        /// <summary>
        /// Allows aggregating a single, simple numeric list (1D vector) in the 
        /// extracted report.
        /// </summary>
        /// <remarks>
        /// Arrays in the JSON data (simple lists of native numeric values, 
        /// mapped to a single dict key) can be aggregated in extracts using any
        /// of the following functions.  Most are intuitive, but for the rest:
        /// 
        /// - TableCols : append to end of output as an independent column-ordered table
        /// - TableRows : append to end of output as an independent row-ordered table (foo, 1, 2, 3)
        /// - PipeDelimited : output the array as a pipe-delimited string ("1|2|3")
        /// - CommaDelimited : output the array as a comma-delimited string ("1,2,3") (essentially extend record's CSV row)
        ///
        /// It is important to recognize that these aggregations are performed on 
        /// the contents OF ONE LIST: for multi-list rollups, see Collect2D.
        ///
        /// Aggregation can be combined with interpolation, and if you plan to 
        /// plot multiple records on the same graph (a common use-case for 
        /// TableCols and TableRows), probably should be.
        ///
        /// 1D aggregation can be combined with 2D aggregation.  In that case, 
        /// 2D collection is performed *first*, merging data across JSON 
        /// attributes, then 1D aggregation is performed *after*, across the 
        /// newly merged 1D array.
        /// </remarks>
        public enum Collect1D { TableCols, TableRows, Count, Sum, Mean, Median, Stdev, Min, Max, PipeDelimited, CommaDelimited, None };

        /// <summary>
        /// Allows aggregating multiple lists (2D input data) together into a new 
        /// 1D virtual list (which may itself be then aggregated using 
        /// Collect1D).
        /// </summary>
        public enum Collect2D { Mean, Median, Stdev, Collate, None };

        // public Properties are auto-populated to the bound DataGridView in definition order
        public string label { get; set; }
        public int precision { get; set; }
        public string defaultValue { get; set; }
        public Collect1D? collect1D { get; set; } = null;
        public Collect2D? collect2D{ get; set; } = null;
        public string jsonFullPath { get; set; }

        public string collect2DPivotPath { get; set; }
        public List<string> collect2DRelativePath;

        // used for TableCols/Rows AggregateTypes
        List<List<double>> tableData = new List<List<double>>();
        List<string> tableKeys = new List<string>();
        int tableDimension = 0; // not all arrays (spectra, wavecal etc) may be of the same length

        // used for TableCols/Rows with interpolation
        public Interpolator.Axis interpolatedAxis;
        public SpectrumUtil.WavecalGenerator wavecalGenerator;

        Logger logger = Logger.getInstance();

        public override string ToString()
        {
            return $"ExtractAttribute({label} ({jsonFullPath}), collect1D {collect1D}, collect2D {collect2D})";
        }

        public bool isTable()
        {
            return collect1D == Collect1D.TableCols ||
                   collect1D == Collect1D.TableRows;
        }

        public string formatValue(object obj)
        {
            if (obj is null)
                return "";
            else if (obj is List<object>)
                return formatAggregate(obj);
            else if (obj is float || obj is double)
                return formatDouble((double)obj);
            else
                return obj.ToString();
        }

        string formatDouble(double d) => (precision < 0) ? d.ToString() : decimal.Round(new decimal(d), precision).ToString();

        /// <summary>
        /// Probably a clever way to do this using LINQ.
        /// </summary>
        /// <returns>values joined with delim using configured precision</returns>
        string join(string delim, List<double> values)
        {
            if (values.Count == 0)
                return "";
            StringBuilder sb = new StringBuilder(formatDouble(values[0]));
            for (int i = 1; i < values.Count; i++)
                sb.Append(delim + formatDouble(values[i]));
            return sb.ToString();
        }

        string formatAggregate(object obj)
        {
            if (collect1D is null)
                return null;

            if (collect1D == Collect1D.TableCols || collect1D == Collect1D.TableRows)
            {
                logger.error($"use storeTable() for {collect1D}");
                return null;
            }

            var l = (List<object>)obj;

            if (collect1D == Collect1D.Count)
                return l.Count.ToString();

            List<double> values = l.Cast<double>().ToList();
            if (values.Count == 0)
                return formatDouble(0);

            double result = 0;
            switch (collect1D)
            {
                case Collect1D.Min: result = values.Min(); break;
                case Collect1D.Max: result = values.Max(); break;
                case Collect1D.Sum: result = values.Sum(); break;
                case Collect1D.Mean: result = values.Average(); break;
                case Collect1D.Stdev: result = Util.stdev(values); break;
                case Collect1D.Median: result = Util.median(values); break;
                case Collect1D.PipeDelimited: return join("|", values); 
                case Collect1D.CommaDelimited: return join(",", values);
            }
            return formatDouble(result);
        }

        ////////////////////////////////////////////////////////////////////////
        // Tables
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Rather than stream a single value into an ongoing extract, we've been
        /// asked to store a set of values (presumably a 1-dimensional array)
        /// for later summative output as a 2D table at the end of the extract.
        /// </summary>
        /// <remarks>
        /// We need to perform interpolation here (as we stream each record), 
        /// since each record will have its own calibration.
        /// </remarks>
        /// <param name="obj">The deserialized object we're to store in the table.  It is assumed that this object is a List of double.</param>
        /// <param name="recordKey">a label for the record we're storing, to be used in row/column headers (presumably basename)</param>
        /// <param name="jsonRoot">The root of the entire deserialized record being processed. If we're interpolating, we need this so we can extract the wavecal coeffs and excitation.</param>
        public void storeTable(object obj, string recordKey, IDictionary<string, object> jsonRoot)
        {
            if (doingCollation())
                storeTableCollate(obj, recordKey, jsonRoot);
            else
                storeTable1D(obj, recordKey, jsonRoot);
        }

        void storeTable1D(object obj, string recordKey, IDictionary<string, object> jsonRoot)
        {
            if (obj is null)
                return;

            var l = (List<object>)obj;
            if (l.Count == 0)
                return;

            List<double> values;
            if (!doingCollect2D())
                values = l.Cast<double>().ToList();
            else
                values = aggregate2D(jsonRoot);

            if (interpolatedAxis != null)
            {
                List<double> oldX = wavecalGenerator.generateAxis(jsonRoot, values.Count);
                Interpolator interp = new Interpolator(oldX, values);
                values = interp.interpolate(interpolatedAxis.newX);
            }

            tableKeys.Add(recordKey);
            tableData.Add(values);
            if (tableDimension < values.Count)
                tableDimension = values.Count;
        }

        /// <summary>
        /// This function merges storeTable1D() and aggregate2D(), used for the 
        /// special case of collating (expanding) multiple arrays when 
        /// Collect2D.Collate is specified.
        /// </summary>
        void storeTableCollate(object obj, string recordKey, IDictionary<string, object> jsonRoot)
        {
            if (obj is null)
                return;

            var pivotObj = Util.getJsonValue(jsonRoot, collect2DPivotPath);
            IDictionary<string, object> pivotNode = (IDictionary<string, object>)pivotObj;

            // iterate over the top-level keys of the pivot, collating
            // each into the output table
            foreach (var pair in pivotNode)
            {
                var thisPath = collect2DPivotPath + "\\" + pair.Key + "\\" + Util.joinAny(collect2DRelativePath, "\\");
                logger.debug($"collating {thisPath}");

                var thisObj = Util.getJsonValue(jsonRoot, thisPath);
                var l = (List<object>)thisObj;
                if (l.Count == 0)
                {
                    logger.error($"found empty array at {thisPath} during collation");
                    continue;
                }

                List<double> values = l.Cast<double>().ToList();

                if (interpolatedAxis != null)
                {
                    List<double> oldX = wavecalGenerator.generateAxis(jsonRoot, values.Count);
                    Interpolator interp = new Interpolator(oldX, values);
                    values = interp.interpolate(interpolatedAxis.newX);
                }

                tableKeys.Add(recordKey + '\\' + pair.Key);
                tableData.Add(values);
                if (tableDimension < values.Count)
                    tableDimension = values.Count;
            }
        }

        /// <summary>
        /// In the course of performing an extract, we are processing an array 
        /// attribute which has Collect2D enabled (other than Collate).  Go and 
        /// collect all the attributes which can be collected into this one, and
        /// merge them into a single list.
        /// </summary>
        /// <warning>not for use with Collect2D.Collate</warning>
        /// <param name="jsonRoot"></param>
        /// <returns>a 1D array of values collected from multiple attributes</returns>
        List<double> aggregate2D(IDictionary<string, object> jsonRoot)
        {
            var pivotObj = Util.getJsonValue(jsonRoot, collect2DPivotPath);
            IDictionary<string, object> pivotNode = (IDictionary<string, object>)pivotObj;

            List<List<double>> data = new(); // hold the 2D data we'll be collecting and then reducing

            // iterate over the top-level keys of the pivot, loading 
            // each target array into a new 2D matrix
            foreach (var pair in pivotNode)
            {
                // append the configured relative path
                var thisPath = collect2DPivotPath + "\\" + pair.Key + "\\" + Util.joinAny(collect2DRelativePath, "\\");

                logger.debug($"generating Collect2D<{collect2D}> {thisPath}");

                var thisObj = Util.getJsonValue(jsonRoot, thisPath);
                var l = (List<object>)thisObj;
                if (l.Count == 0)
                {
                    logger.error($"found empty array at {thisPath} during aggregate2D");
                    continue;
                }

                List<double> values = l.Cast<double>().ToList();
                if (data.Count == 0)
                    for (int i = 0; i < values.Count; i++)
                        data.Add(new List<double>());
                for (int i = 0; i < values.Count; i++)
                    data[i].Add(values[i]);
            }

            switch (collect2D)
            {
                case Collect2D.Mean: return Util.mean2D(data);
                case Collect2D.Stdev: return Util.stdev2D(data);
                case Collect2D.Median: return Util.median2D(data);
                case Collect2D.Collate:
                default:
                    logger.error($"should not use {collect2D} with aggregate2D");
                    break;
            }
            return null;
        }

        bool doingCollect1D() => collect1D != null && collect1D != Collect1D.None;
        bool doingCollect2D() => collect2D != null && collect2D != Collect2D.None;
        bool doingCollation() => collect2D != null && collect2D == Collect2D.Collate;

        string getTableName()
        {
            // from: root\AxisStabilityTest\Measurements\Measurement 2\processed[]
            //   to: AxisStabilityTest\Measurements\Mean\processed[]
            string name = jsonFullPath;
            if (name.StartsWith("root\\"))
                name = name.Substring(5);
            if (doingCollect2D())
            {
                var tok = name.Split('\\');
                var cnt = tok.Length;
                tok[cnt - 2] = collect2D.ToString();
                name = string.Join('\\', tok);
            }
            return name;
        }

        /// <summary>
        /// At the end of the extract, we can render the 2D tables from the lists that we stored.
        /// </summary>
        public string formatTable()
        {
            string table = "";
            if (collect1D == Collect1D.TableRows)
            {
                if (interpolatedAxis is null)
                    table = renderTableRowOrderUninterpolated();
                else
                    table = renderTableRowOrderInterpolated();
            }
            else if (collect1D == Collect1D.TableCols)
            {
                if (interpolatedAxis is null)
                    table = renderTableColumnOrderUninterpolated();
                else
                    table = renderTableColumnOrderInterpolated();
            }
            else
                logger.error($"unsupported table type: {collect1D}");

            tableData.Clear();
            tableKeys.Clear();
            tableDimension = 0;

            return getTableName() + Environment.NewLine + table;
        }

        string renderTableColumnOrderInterpolated()
        {
            StringBuilder sb = new();
            sb.AppendLine(wavecalGenerator.getLabel() + "," + string.Join(",", tableKeys)); // header row (record labels)
            for (int row = 0; row < interpolatedAxis.newX.Count; row++)
            {
                sb.Append(formatDouble(interpolatedAxis.newX[row])); // header column (e.g. wavelength or wavenumber)
                for (int col = 0; col < tableData.Count; col++)
                {
                    sb.Append(",");
                    if (row < tableData[col].Count)
                        sb.Append(formatDouble(tableData[col][row]));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        string renderTableColumnOrderUninterpolated()
        {
            StringBuilder sb = new();
            sb.AppendLine("Row," + string.Join(",", tableKeys)); // header row (record labels)
            for (int row = 0; row < tableDimension; row++)
            {
                sb.Append(row); // header column (e.g. pixel)
                for (int col = 0; col < tableData.Count; col++)
                {
                    sb.Append(",");
                    if (row < tableData[col].Count)
                        sb.Append(formatDouble(tableData[col][row]));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        string renderTableRowOrderInterpolated()
        {
            StringBuilder sb = new();

            // header row (e.g interpolated wavelengths or wavenumbers)
            sb.Append(wavecalGenerator.getLabel());
            for (int i = 0; i < interpolatedAxis.newX.Count; i++)
                sb.Append("," + formatDouble(interpolatedAxis.newX[i]));
            sb.AppendLine();

            for (int i = 0; i < tableData.Count; i++)
            {
                sb.Append(tableKeys[i]); // header column (record label)
                for (int j = 0; j < tableData[i].Count; j++)
                    sb.Append("," + formatDouble(tableData[i][j]));
                sb.AppendLine();
            }
            return sb.ToString();
        }

        string renderTableRowOrderUninterpolated()
        {
            StringBuilder sb = new();

            // header row (e.g. pixels)
            sb.Append("Column");
            for (int i = 0; i < tableDimension; i++)
                sb.Append($",{i}");

            for (int i = 0; i < tableData.Count; i++)
            {
                sb.Append(tableKeys[i]); // header column (record label)
                for (int j = 0; j < tableData[i].Count; j++)
                    sb.Append("," + formatDouble(tableData[i][j]));
                sb.AppendLine();
            }
            return sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////
        // De/Serialization
        ////////////////////////////////////////////////////////////////////////

        public class Serialized
        {
            public string label { get; set; }
            public int precision { get; set; }
            public string defaultValue { get; set; }
            public string collect1D { get; set; }
            public string collect2D { get; set; }
            public string jsonFullPath { get; set; }
            public string wavecalJsonPath { get; set; }
            public string excitationJsonPath { get; set; }
            public List<double> newX { get; set; }

            public static Serialized serialize(ExtractAttribute ea)
            {
                var ser = new Serialized()
                {
                    label = ea.label,
                    precision = ea.precision,
                    defaultValue = ea.defaultValue,
                    collect1D = ea.collect1D.ToString(),
                    collect2D = ea.collect2D.ToString(),
                    jsonFullPath = ea.jsonFullPath,
                    wavecalJsonPath = ea.wavecalGenerator is null ? null : ea.wavecalGenerator.wavecalJsonPath,
                    excitationJsonPath = ea.wavecalGenerator is null ? null : ea.wavecalGenerator.excitationJsonPath,
                    newX = ea.interpolatedAxis is null ? null : ea.interpolatedAxis.newX
                };
                return ser;
            }

            public ExtractAttribute deserialize()
            {
                Collect1D collect1D_tmp = Collect1D.None;
                Enum.TryParse(collect1D, out collect1D_tmp);

                Collect2D collect2D_tmp = Collect2D.None;
                Enum.TryParse(collect1D, out collect2D_tmp);

                ExtractAttribute ea = new()
                {
                    label = label,
                    precision = precision,
                    defaultValue = defaultValue,
                    jsonFullPath = jsonFullPath,
                    collect1D = collect1D_tmp == Collect1D.None ? null : collect1D_tmp,
                    collect2D = (collect2D_tmp == Collect2D.None || collect2D_tmp == Collect2D.None) ? null : collect2D_tmp,
                    wavecalGenerator = new(wavecalJsonPath, excitationJsonPath),
                    interpolatedAxis = new(newX)
                };
                return ea;
            }
        }
    }
}
