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
    class ExtractAttribute
    {
        /// <summary>
        /// Arrays in the JSON data can be aggregated (rolled-up) in extracts 
        /// using any of the following functions.  Most are intuitive, but for
        /// the rest:
        /// 
        /// - CommaDelimited : output the array as a comma-delimited string
        /// - TableRows : append to end of output as an independent row-ordered table
        /// - TableCols : append to end of output as an independent column-ordered table
        /// </summary>
        public enum AggregateType { Count, Sum, Mean, StdDev, Min, Max, CommaDelimited, PipeDelimited, TableRows, TableCols };

        // public Properties are auto-populated to the bound DataGridView in definition order
        public string label { get; set; }
        public int precision { get; set; }
        public string defaultValue { get; set; }
        public AggregateType? aggregateType { get; set; } = null;
        public string jsonFullPath { get; set; }

        List<List<double>> tableData = new List<List<double>>();
        List<string> tableKeys = new List<string>();
        int tableDimension = 0; // not all arrays (spectra, wavecal etc) may be of the same length

        Logger logger = Logger.getInstance();

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

        string formatDouble(double d)
        {
            if (precision >= 0)
            {
                Decimal dec = new Decimal(d);
                return Decimal.Round(dec, precision).ToString();
            }
            else
                return d.ToString();
        }

        /// <summary>
        /// Probably a clever way to do this using LINQ.
        /// </summary>
        /// <param name="delim"></param>
        /// <param name="values"></param>
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

            List<double> values = l.OfType<double>().ToList();
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
                result = Util.standardDeviation(values);

            return formatDouble(result);
        }

        public void storeTable(object obj, string key)
        {
            if (obj is null)
                return;

            var l = (List<object>)obj;
            if (l.Count == 0)
                return;

            List<double> values = l.OfType<double>().ToList();

            tableData.Add(values);
            tableKeys.Add(key);
            if (tableDimension < values.Count)
                tableDimension = values.Count;
        }

        public string formatTable()
        {
            StringBuilder sb = new StringBuilder();
            if (aggregateType == AggregateType.TableRows)
            {
                for (int i = 0; i < tableData.Count; i++)
                {
                    sb.Append(tableKeys[i]);
                    for (int j = 0; j < tableData[i].Count; j++)
                    {
                        string value = formatDouble(tableData[i][j]);
                        sb.Append($", {value}");
                    }
                    sb.Append(Environment.NewLine);
                }
            }
            else if (aggregateType == AggregateType.TableCols)
            {
                foreach (var key in tableKeys)
                    sb.Append(key);
                for (int i = 0; i < tableDimension; i++)
                {
                    for (int j = 0; j < tableData.Count; i++)
                    {
                        string value = "";
                        if (i < tableData[j].Count)
                            value = formatDouble(tableData[j][i]);
                        sb.Append($", {value}");
                    }
                    sb.Append(Environment.NewLine);
                }
            }

            tableData.Clear();
            tableDimension = 0;

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"ExtractAttribute({label} ({jsonFullPath}), default {defaultValue}, aggregateType {aggregateType})";
        }
    }
}
