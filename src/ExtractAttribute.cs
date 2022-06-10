using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        ///
        /// Collect1D.None was added to simplify serialization of non-list 
        /// attributes.  No actual List[] attribute will use Collect1D.None.
        /// 
        /// - ALL list attributes are required to specify a non-None collect1D
        /// - SOME list attributes support Collect2D (either LoL or dict-based)
        /// - ALL LoL attributes MUST specify a non-None Collect2D (default could be Collate)
        /// - Dict-based attributes supporting Collect2D may leave it None
        /// - There are NO attributes with Collect2D but not Collect1D
        /// 
        /// </remarks>
        public enum Collect1D { TableCols, TableRows, Count, Sum, Mean, Median, Stdev, Min, Max, PipeDelimited, CommaDelimited, None };

        /// <summary>
        /// Allows aggregating multiple lists (2D input data) together into a new 
        /// 1D virtual list (which may itself be then aggregated using 
        /// Collect1D).
        /// </summary>
        public enum Collect2D { Mean, Median, Max, Min, Stdev, Collate, None };

        // public Properties are auto-populated to the bound DataGridView in definition order
        public string label { get; set; }
        public int precision { get; set; }
        public string defaultValue { get; set; }
        public Collect1D? collect1D { get; set; } = null;
        public Collect2D? collect2D { get; set; } = null;

        // If true, 2D data is a List-of-Lists, e.g. '8ms[]' -> [ [ 3, 4, 2 ], [ 4, 4, 5 ], [ 2, 3, 2 ] ]
        // If false, 2D data pivots on grandparent, e.g. 'measurements' -> 'measurement 1' -> 'processed[]'
        public bool collect2DLoL { get; set; } 
        public string interpolated { get => interpolatedAxis is null ? "" : interpolatedAxis.range(); }
        public bool graph { get; set; }
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

        // used for extractChart
        public List<GraphSeries> graphSeries = new();

        // This is because I want to keep all Series on the extract Chart at once
        // (some invisible) and don't want duplicate keys. This allows the same
        // attribute label ("processed[]") and collated subkeys ("processed[].Measurement 1")
        // to appear on different attributes (for instance, with different Collect2)
        // ("A.processed[]", etc)
        public string abbr = null;

        Logger logger = Logger.getInstance();

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                          Public Methods                            //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        // In the course of performing an extract, we are rendering a single
        // attribute (which may be a List[], and may have Collect1D and/or
        // Collect2D aggregations defined) -- however, the attribute is NOT
        // a table (does not have Collect1D.TableCols or .TableRows).
        //
        // Therefore, however complex the attribute is, we can render it to
        // a single formatted scalar (e.g. "3.14").
        public string formatValue(object obj, IDictionary<string, object> jsonRoot)
        {
            if (isTable())
            {
                logger.error($"formatValue should not be used on tables (use storeTable instead): {this}");
                return null;
            }
            else if (obj is null)
                return "";
            else if (obj is List<object>)
                return formatAggregate(obj, jsonRoot);
            else if (obj is float || obj is double)
                return formatDouble((double)obj);
            else
                return obj.ToString();
        }

        /// <summary>
        /// Rather than stream a single value into an ongoing extract, we've been
        /// asked to store a set of values (presumably a 1-dimensional array)
        /// for later summative output as a 2D table at the end of the extract.
        /// </summary>
        ///
        /// <remarks>
        /// This method is called INSTEAD OF formatValue() for attributes where 
        /// isTable() is true.
        /// 
        /// We do need to perform interpolation here (as we stream each record), 
        /// since each record will have its own calibration.
        /// </remarks>
        ///
        /// <param name="obj">The deserialized object we're to store in the table.  It is assumed that this object is a List of double.</param>
        /// <param name="recordKey">a label for the record we're storing, to be used in row/column headers (presumably basename)</param>
        /// <param name="jsonRoot">The root of the entire deserialized record being processed. If we're interpolating, we need this so we can extract the wavecal coeffs and excitation.</param>
        public Dictionary<string, List<double>> storeTable(object obj, string recordKey, IDictionary<string, object> jsonRoot)
        {
            if (!isTable())
            {
                logger.error($"storeTable should only be used on tables (use formatValue instead): {this}");
                return null;
            }

            if (doingCollation())
            {
                return storeTableCollate(obj, recordKey, jsonRoot);
            }
            else
            {
                var result = new Dictionary<string, List<double>>();
                result.Add(recordKey, storeTable1D(obj, recordKey, jsonRoot));
                return result;
            }
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

            return getTableName() + Environment.NewLine + table;
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                            Utility                                 //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        public override string ToString() => $"ExtractAttribute({label} ({jsonFullPath}), collect1D {collect1D}, collect2D {collect2D}, collect2DLoL {collect2DLoL})";

        public bool doingCollect2D() => collect2D != null && collect2D != Collect2D.None;

        public bool isTable() => collect1D != null && (collect1D == Collect1D.TableCols || collect1D == Collect1D.TableRows);

        bool doingCollation() => collect2D != null && collect2D == Collect2D.Collate;

        // This method is used across the class to format a final, aggregated
        // double value to the specified precision.
        string formatDouble(double d, int prec=0)
        {
            if (prec == 0)
                prec = precision;
            return (prec < 0) ? d.ToString() : decimal.Round(new decimal(d), prec).ToString();
        }

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

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                      Aggregations (1D & 2D)                        //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        // This function is called by formatValue() on each record during
        // extraction (not at the end) for NON-TABLE array attributes, meaning
        // the attribute can be rolled-up into a single formatted scalar for
        // inclusion in the main extract table.
        //
        // Since it is generating a scalar, interpolation is not an issue.
        string formatAggregate(object obj, IDictionary<string, object> jsonRoot)
        {
            if (collect1D is null)
                return null;

            if (isTable())
            {
                logger.error($"use storeTable() for {collect1D}");
                return null;
            }

            var l = (List<object>)obj;
            List<double> values = doingCollect2D() ? aggregate2D(jsonRoot) : l.Cast<double>().ToList();

            if (collect1D == Collect1D.PipeDelimited)
                return join("|", values);
            else if (collect1D == Collect1D.CommaDelimited)
                return join(",", values);
            else
                return formatDouble(aggregate1DData(values));
        }

        // Used by formatAggregate() to apply a 1D aggregation on a List<double>.
        double aggregate1DData(List<double> values)
        {
            if (collect1D == Collect1D.Count)
                return values.Count;
            else if (values.Count == 0)
                return 0;

            switch (collect1D)
            {
                case Collect1D.Min: return values.Min(); 
                case Collect1D.Max: return values.Max(); 
                case Collect1D.Sum: return values.Sum(); 
                case Collect1D.Mean: return values.Average(); 
                case Collect1D.Stdev: return Util.stdev(values); 
                case Collect1D.Median: return Util.median(values); 
                default:
                    logger.error($"aggregate1DData: unimplemented Collect1D.{collect1D}");
                    return 0;
            }
        }

        /// <summary>
        /// In the course of performing an extract, we are processing an array 
        /// attribute which has Collect2D enabled (other than Collate).  Go and 
        /// collect all the attributes which can be collected into this one, and
        /// merge them into a single list.
        ///
        /// Currently this is called from storeTable1D, to collapse multiple 
        /// arrays down to one, before storing them toward future table outputs.
        ///
        /// It COULD be called by any other other function wishing to collapse
        /// multiple arrays down to one, using the current (non-collation) 
        /// Collect2D setting.
        /// </summary>
        ///
        /// <returns>a 1D array of values collected from multiple attributes</returns>
        List<double> aggregate2D(IDictionary<string, object> jsonRoot)
        {
            if (collect2DLoL)
                return aggregate2DLoL(jsonRoot);
            else
                return aggregate2DDict(jsonRoot);
        }

        // Called by aggregate2D; should NOT interpolate (nor its children).
        List<double> aggregate2DLoL(IDictionary<string, object> jsonRoot)
        {
            List<List<double>> data = Util.toLoLTransposed(jsonRoot, collect2DPivotPath);
            return aggregate2DData(data);
        }

        // Called by aggregate2D; should NOT interpolate (nor its children).
        List<double> aggregate2DDict(IDictionary<string, object> jsonRoot)
        {
            var pivotObj = Util.getJsonValue(jsonRoot, collect2DPivotPath);
            IDictionary<string, object> pivotNode = (IDictionary<string, object>)pivotObj;

            List<List<double>> data = new(); // hold the 2D data we'll be collecting and then reducing

            // iterate over the top-level keys of the pivot, loading 
            // each target array into a new 2D matrix
            foreach (var pair in pivotNode)
            {
                var thisPath = collect2DPivotPath + "\\" + pair.Key + "\\" + Util.joinAny(collect2DRelativePath, "\\");
                /*
                logger.debug($"generating Collect2D<{collect2D}> {thisPath}");

                var thisObj = Util.getJsonValue(jsonRoot, thisPath);
                var l = (List<object>)thisObj;
                List<double> values = l.Cast<double>().ToList();
                */
                List<double> values = Util.toLoD(jsonRoot, thisPath);
                if (values.Count == 0)
                {
                    logger.error($"found empty array at {thisPath} during aggregate2DDict");
                    continue;
                }

                // append transposed vector as new matrix column
                if (data.Count == 0)
                    for (int i = 0; i < values.Count; i++)
                        data.Add(new List<double>());
                for (int i = 0; i < values.Count; i++)
                    data[i].Add(values[i]);
            }

            return aggregate2DData(data);
        }

        /// <summary>
        /// Called by aggregate2DDict and aggregate2DLoL, and also formatAggregate;
        /// should NOT interpolate. 
        /// </summary>
        /// 
        /// <remarks>
        /// When called by aggregate2DLoL/Dict, it will 
        /// be guaranteed not to use collation. For such cases, we stick to our 
        /// remit and perform Collect2D before Collect1D:
        ///
        /// [ [ 1, 1, 1, 1, 1 ],
        ///   [ 2, 2, 3, 4, 5 ],
        ///   [ 1, 2, 3, 4, 5 ] ]
        /// 
        /// Collect2D.Mean => [ 1, 3.2, 3]
        /// Collect1D.Median => 3.2
        ///  
        /// However, formatAggregate may call it while performing scalar
        /// "Collect1D" metrics on 2D data with Collect2D.Collate.
        ///
        /// In that case, we should consider which of these is correct / desired:
        ///
        /// [ [ 1, 1, 1, 1, 1 ],
        ///   [ 1, 2, 3, 4, 5 ],
        ///   [ 2, 2, 3, 4, 5 ] ]
        ///
        /// If flattened:
        ///    [ 1, 1, 1, 1, 1,   1, 2, 3, 4, 5,   2, 2, 3, 4, 5 ]
        /// => [ 1, 1, 1, 1, 1,   1, 2, 2, 2, 3,   3, 4, 4, 5, 5 ]
        /// => 2 (median of flattened list)
        ///
        /// If not flattened:
        ///    [ 1, 3, 3 ] (median of each sub-list)
        /// => 3 (median of sub-lists)
        ///
        /// Ideally we should provide a CheckBox allowing the user to choose
        /// either behavior, explaining it in "Explain".
        /// </remarks>
        List<double> aggregate2DData(List<List<double>> data)
        {
            switch (collect2D)
            {
                case Collect2D.Mean:   return Util.mean2D(data);
                case Collect2D.Stdev:  return Util.stdev2D(data);
                case Collect2D.Median: return Util.median2D(data);
                case Collect2D.Max:    return Util.max2D(data);
                case Collect2D.Min:    return Util.min2D(data);

                // Flatten (this should not be done during storeTable(), as we
                // want each sub-spectra to be output as its own row/column, but
                // could be okay when 2D aggregates are then wrapped with 1D
                // metrics by formatAggregate().
                case Collect2D.Collate: return data.SelectMany(x => x).ToList(); 

                default:
                    logger.error($"aggregate2DData: not for use with Collect2D.{collect2D}");
                    return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                             Tables                                 //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        // These functions are responsible for processing the current attribute
        // of the current record and adding any Collect1D.TableCols or TableRows
        // to tableData, under the new tableKeys, with updated tableDimension.

        // Helper function used exclusively by storeTable() for cases where we
        // are NOT doing Collect2D.Collate.
        //
        // Note that since we perform interpolation here, we SHOULD NOT perform
        // interpolation in any of the functions it calls (aggregate2D etc).
        List<double> storeTable1D(object obj, string recordKey, IDictionary<string, object> jsonRoot)
        {
            if (obj is null)
                return null;

            if (doingCollation())
            {
                logger.error("storeTable1D is not for use with collation");
                return null;
            }

            var l = (List<object>)obj;
            if (l.Count == 0)
                return null; // no data to store

            List<double> values;
            if (doingCollect2D())
                values = aggregate2D(jsonRoot); // first collapse multiple attributes into one, THEN we can store the resulting 1D array
            else
                values = l.Cast<double>().ToList(); // we're only processing ONE ATTRIBUTE, so just cast to double 

            if (interpolatedAxis != null)
            {
                List<double> oldX = wavecalGenerator.generateAxis(jsonRoot, values.Count);
                Interpolator interp = new Interpolator(oldX, values);
                values = interp.interpolate(interpolatedAxis.newX);
                // logger.debug($"storeTable1D: interpolated values from oldX ({oldX.First():f2}, {oldX.Last():f2}) to newX ({interpolatedAxis.newX.First():f2}, {interpolatedAxis.newX.Last():f2})");
            }

            tableKeys.Add(recordKey);
            tableData.Add(values);
            tableDimension = Math.Max(tableDimension, values.Count);

            return values;
        }

        Dictionary<string, List<double>> storeTableCollate(object obj, string recordKey, IDictionary<string, object> jsonRoot)
        {
            if (collect2DLoL)
                return storeTableCollate2DLoL(obj, recordKey, jsonRoot);
            else
                return storeTableCollate2DDict(obj, recordKey, jsonRoot);
        }

        // Called by storeTableCollate; SHOULD perform interpolation.
        Dictionary<string, List<double>> storeTableCollate2DLoL(object obj, string recordKey, IDictionary<string, object> jsonRoot)
        {
            if (obj is null)
                return null;

            Dictionary<string, List<double>> result = new(); 

            List<object> l = (List<object>)obj;
            for (int i = 0; i < l.Count; i++)
            {
                List<object> subList = (List<object>)l[i];
                List<double> values = subList.Cast<double>().ToList();

                if (interpolatedAxis != null)
                {
                    List<double> oldX = wavecalGenerator.generateAxis(jsonRoot, values.Count);
                    Interpolator interp = new Interpolator(oldX, values);
                    values = interp.interpolate(interpolatedAxis.newX);
                }

                var name = $"{recordKey}\\{i}";
                result.Add(name, values);
                tableKeys.Add(name);
                tableData.Add(values);
                tableDimension = Math.Max(tableDimension, values.Count);
            }
            return result;
        }

        // Called by storeTableCollate; SHOULD perform interpolation.
        Dictionary<string, List<double>> storeTableCollate2DDict(object obj, string recordKey, IDictionary<string, object> jsonRoot)
        { 
            if (obj is null)
                return null;

            var pivotObj = Util.getJsonValue(jsonRoot, collect2DPivotPath);
            IDictionary<string, object> pivotNode = (IDictionary<string, object>)pivotObj;

            Dictionary<string, List<double>> result = new();

            // iterate over the top-level keys of the pivot, collating
            // each into the output table (interpolated if specified)
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

                string name = recordKey + '\\' + pair.Key;
                tableKeys.Add(name);
                tableData.Add(values);
                tableDimension = Math.Max(tableDimension, values.Count);

                result.Add(name, values);
            }
            return result;
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                      Rendering Final Table                         //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        // These functions perform no aggregations, collation or interpolation, 
        // as all data has already been assembled into tableData, tableKeys and
        // tableDimension.

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

        string renderTableColumnOrderInterpolated()
        {
            StringBuilder sb = new();
            sb.AppendLine(wavecalGenerator.getLabel() + "," + string.Join(",", tableKeys)); // header row (record labels)
            for (int row = 0; row < interpolatedAxis.newX.Count; row++)
            {
                sb.Append(formatDouble(interpolatedAxis.newX[row], 2)); // header column (e.g. wavelength or wavenumber)
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
        //                                                                    //
        //                          De/Serialization                          //
        //                                                                    //
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
