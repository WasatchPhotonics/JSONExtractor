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
        public bool interpolate { get; set; }

        List<List<double>> tableData = new List<List<double>>();
        List<string> tableKeys = new List<string>();
        int tableDimension = 0; // not all arrays (spectra, wavecal etc) may be of the same length

        public string interpolationCoeffsFullPath; // jsonFullPath to the coefficients array used for interpolation
        public int interpolationStart;
        public int interpolationEnd;
        public float interpolationIncr;

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

        /// <summary>
        /// Rather than output a single value into an ongoing extract, we've been
        /// asked to store a set of values (presumably a 1-dimensional array)
        /// for later output as a 2D table at the end of the extract.
        /// </summary>
        /// <remarks>
        /// We need to perform interpolation here, since each record may have its
        /// own calibration coefficients.
        /// </remarks>
        public void storeTable(object obj, string key, IDictionary<string, object> jsonObj = null)
        {
            if (obj is null)
                return;

            var l = (List<object>)obj;
            if (l.Count == 0)
                return;

            List<double> values = l.OfType<double>().ToList();

            if (interpolate && jsonObj != null)
                values = interpolateValues(values, jsonObj);

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
                sb.AppendLine(String.Join(",", tableKeys));
                for (int row = 0; row < tableDimension; row++)
                {
                    if (row < tableData[0].Count)
                        sb.Append(formatDouble(tableData[0][row]));
                    for (int col = 1; col < tableData.Count; col++)
                    {
                        sb.Append(",");
                        if (row < tableData[col].Count)
                            sb.Append(formatDouble(tableData[col][row]));
                    }
                    sb.AppendLine();
                }
            }

            tableData.Clear();
            tableKeys.Clear();
            tableDimension = 0;

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"ExtractAttribute({label} ({jsonFullPath}), default {defaultValue}, aggregateType {aggregateType})";
        }

        ////////////////////////////////////////////////////////////////////////
        // Interpolation
        ////////////////////////////////////////////////////////////////////////

        List<double> getCoefficients(IDictionary<string, object> jsonObj)
        {
            var value = Util.getJsonValue(jsonObj, interpolationCoeffsFullPath);
            if (value is null)
                return null;

            var l = (List<object>)jsonObj;
            List<double> values = l.OfType<double>().ToList();
            if (values.Count == 0)
                return null;

            return values;
        }

        double evaluatePolynomial(double x, List<double> coeffs)
        {
            // compromise between length, performance and reusability
            double result = 0;
            if (coeffs.Count >= 1) result  = coeffs[0];
            if (coeffs.Count >= 2) result += coeffs[1] * x;
            if (coeffs.Count >= 3) result += coeffs[2] * coeffs[2] * x;
            if (coeffs.Count >= 4) result += coeffs[3] * coeffs[3] * coeffs[3] * x;
            if (coeffs.Count >= 5) result += coeffs[4] * coeffs[4] * coeffs[4] * coeffs[4]  * x;
            for (int i = 5; i < coeffs.Count; i++)
                result += x * Math.Pow(coeffs[i], i);
            return result;
        }

        /// <summary>
        /// Interpolate this 1D array to the specified arithmetic x-axis.
        /// </summary>
        List<double> interpolateValues(List<double> a, IDictionary<string, object> jsonObj)
        {
            List<double> coeffs = getCoefficients(jsonObj);
            List<double> oldX = new List<double>(a.Count);
            for (int i = 0; i < a.Count; i++)
                oldX.Add(evaluatePolynomial(i, coeffs));
            Interpolator interp = new Interpolator(oldX, a);
            int step = 0;
            List<double> newY = new();
            double x = interpolationStart;
            while (x <= interpolationEnd)
            {
                newY.Add(interp.interpolate(interpolationStart + step * interpolationIncr));
                step++;
            }
            return newY;
        }

    }
}
