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
        /// - CommaDelimited : output the array as a comma-delimited string ("1,2,3")
        /// - CommaDelimited : output the array as a pipe-delimited string ("1|2|3")
        /// - TableRows : append to end of output as an independent row-ordered table (foo, 1, 2, 3)
        /// - TableCols : append to end of output as an independent column-ordered table
        ///
        /// It is important to recognize that these aggregations are performed on 
        /// the contents OF ONE LIST: for multi-list rollups, see RollupType.
        /// </remarks>
        public enum AggregateType { TableCols, TableRows, Count, Sum, Mean, Median, StdDev, Min, Max, PipeDelimited, CommaDelimited };

        /// <summary>
        /// Allows collating multiple lists (2D input data) together into a new 
        /// 1D virtual list (which may itself be then aggregated using 
        /// AggregateType).
        /// </summary>
        public enum CollateType { Mean, Median, StdDev };

        // public Properties are auto-populated to the bound DataGridView in definition order
        public string label { get; set; }
        public int precision { get; set; }
        public string defaultValue { get; set; }
        public AggregateType? aggregateType { get; set; } = null;
        public CollateType? collateType { get; set; } = null;
        public string jsonFullPath { get; set; }

        public string collatePivotPath { get; set; }
        public List<string> collationPath { get; set; }

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
            return $"ExtractAttribute({label} ({jsonFullPath}), default {defaultValue}, aggregateType {aggregateType})";
        }

        public bool isTable()
        {
            return aggregateType == AggregateType.TableCols ||
                   aggregateType == AggregateType.TableRows;
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
            if (aggregateType is null)
                return null;

            if (aggregateType == AggregateType.TableCols || aggregateType == AggregateType.TableRows)
            {
                logger.error($"use storeValue() for {aggregateType}");
                return null;
            }

            var l = (List<object>)obj;

            if (aggregateType == AggregateType.Count)
                return l.Count.ToString();

            List<double> values = l.Cast<double>().ToList();
            if (values.Count == 0)
                return formatDouble(0);

            if (aggregateType == AggregateType.CommaDelimited)
                return join(",", values);
            else if (aggregateType == AggregateType.PipeDelimited)
                return join("|", values);

            double result = 0;
            if (aggregateType == AggregateType.Sum)
                result = values.Sum();
            else if (aggregateType == AggregateType.Mean)
                result = values.Average();
            else if (aggregateType == AggregateType.Min)
                result = values.Min();
            else if (aggregateType == AggregateType.Max)
                result = values.Max();
            else if (aggregateType == AggregateType.StdDev)
                result = Util.stdev(values);
            else if (aggregateType == AggregateType.Median)
                result = Util.median(values);

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
            if (obj is null)
                return;

            var l = (List<object>)obj;
            if (l.Count == 0)
                return;

            List<double> values = l.Cast<double>().ToList();

            if (interpolatedAxis != null)
            {
                List<double> oldX = wavecalGenerator.generateAxis(jsonRoot, values.Count);
                Interpolator interp = new Interpolator(oldX, values);
                values = interp.interpolate(interpolatedAxis.newX);
            }

            tableData.Add(values);
            tableKeys.Add(recordKey);
            if (tableDimension < values.Count)
                tableDimension = values.Count;
        }

        /// <summary>
        /// At the end of the extract, we can render the 2D tables from the lists that we stored.
        /// </summary>
        public string formatTable()
        {
            string table = null;
            if (aggregateType == AggregateType.TableRows)
            {
                if (interpolatedAxis is null)
                    table = renderTableRowOrderUninterpolated();
                else
                    table = renderTableRowOrderInterpolated();
            }
            else if (aggregateType == AggregateType.TableCols)
            {
                if (interpolatedAxis is null)
                    table = renderTableColumnOrderUninterpolated();
                else
                    table = renderTableColumnOrderInterpolated();
            }
            else
                logger.error($"unsupported table type: {aggregateType}");

            tableData.Clear();
            tableKeys.Clear();
            tableDimension = 0;

            return table;
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
            public string aggregateType { get; set; }
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
                    aggregateType = ea.aggregateType.ToString(),
                    jsonFullPath = ea.jsonFullPath,
                    wavecalJsonPath = ea.wavecalGenerator is null ? null : ea.wavecalGenerator.wavecalJsonPath,
                    excitationJsonPath = ea.wavecalGenerator is null ? null : ea.wavecalGenerator.excitationJsonPath,
                    newX = ea.interpolatedAxis is null ? null : ea.interpolatedAxis.newX
                };
                return ser;
            }

            public ExtractAttribute deserialize()
            {
                AggregateType aggregateTypeEnum = AggregateType.Count;
                Enum.TryParse(aggregateType, out aggregateTypeEnum);

                ExtractAttribute ea = new()
                {
                    aggregateType = aggregateTypeEnum,
                    label = label,
                    precision = precision,
                    defaultValue = defaultValue,
                    jsonFullPath = jsonFullPath,
                    wavecalGenerator = new(wavecalJsonPath, excitationJsonPath),
                    interpolatedAxis = new(newX)
                };
                return ea;
            }
        }
    }
}
