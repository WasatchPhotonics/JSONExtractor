using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.IO.Compression;

namespace JSONExtractor
{
    internal static class Util
    {
        static Logger logger = Logger.getInstance();

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                         String Helpers                             //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        public static string joinAny(IEnumerable<object> things, string delim = ", ")
        {
            return string.Join(delim, things.Select(thing => thing.ToString()).ToArray());
        }

        public static string timeRemainingLabel(double totalSec)
        {
            int hours = (int)Math.Floor(totalSec / 3600);
            if (hours > 1)
            {
                int mins = (int)Math.Ceiling((totalSec - (hours * 3600)) / 60.0);
                return $"{hours}hr {mins}min remaining";
            }
            else
            {
                int mins = (int)Math.Floor(totalSec / 60.0);
                int secs = (int)Math.Ceiling(totalSec - (mins * 60));
                return $"{mins}min {secs}sec remaining";
            }
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                          File Helpers                              //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Load all text from the specified file and return as a string. If 
        /// filename ends in ".gz", uncompress it automatically.
        /// </summary>
        public static string loadText(string pathname)
        {
            if (pathname.EndsWith(".gz"))
            {
                StringBuilder sb = new StringBuilder();
                using (FileStream reader = File.OpenRead(pathname))
                    using (GZipStream zip = new GZipStream(reader, CompressionMode.Decompress))
                        using (StreamReader unzip = new StreamReader(zip))
                            while (!unzip.EndOfStream)
                                sb.AppendLine(unzip.ReadLine());
                return sb.ToString();
            }
            else
            {
                return File.ReadAllText(pathname);
            }
        }

        public static List<double> forceDouble(List<object> l)
        {
            List<double> result = new List<double>(l.Count);
            for (int i = 0; i < l.Count; i++)
                result.Add(toDouble(l[i]));
            return result;
        }

        // surely there's an easier way to do this
        public static double toDouble(object o)
        {
            if (o is Double d) return d;
            if (o is Single f) return f;
            if (o is Int64 i64) return i64;
            if (o is Int32 i32) return i32;
            if (o is Int16 i16) return i16;
            return Double.NaN;
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                          JSON Helpers                              //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        // I'm not sure I'm doing all these type conversions as elegantly or
        // efficiently as possible.  Suggestions welcome!

        /// <summary>
        /// Given the root of a JSON object tree and a backslash-delimited path 
        /// of dictionary keys, returns the object at the end of the path.
        /// </summary>
        /// <param name="node">starting dictionary node</param>
        /// <param name="jsonPath">backslash-delimited string of dictionary keys</param>
        /// <returns>null on error</returns>
        public static object getJsonValue(IDictionary<string, object> node, string jsonPath, string defaultValue = null)
        {
            object result = defaultValue;
            if (jsonPath is null)
                return result;
            var tok = jsonPath.Split("\\");
            try
            {
                int start = 0;
                if (tok[0] == "root")
                    start = 1; // skip artificial "root" tier

                for (int i = start; i < tok.Length; i++)
                {
                    var key = tok[i];
                    if (key.EndsWith("[]"))
                        key = key.Substring(0, key.Length - 2);

                    if (node is null || !node.ContainsKey(key))
                        break;

                    // are we at the last node?
                    if (i + 1 == tok.Length)
                        return node[key];

                    // traverse to the next JSON node
                    node = (IDictionary<string, object>)node[key];
                }
            }
            catch (Exception ex)
            {
                logger.error($"exception finding {jsonPath} in node: {ex}");
            }
            logger.error($"getJsonValue: can't find {jsonPath} in node");
            return result;
        }

        /// <summary>
        /// Instead of returning the actual object at a given path (of type 
        /// Double[] or whatever with 2048 elements), return a string which is 
        /// "representative" of the object contents. Used for mouseOver tooltips.
        /// </summary>
        public static string getJsonValueShortString(IDictionary<string, object> node, string jsonPath)
        {
            var obj = getJsonValue(node, jsonPath);

            // handle scalars
            if (obj is not List<object>)
                return obj.ToString();

            // handle lists
            var l = (List<object>)obj;
            List<string> tok = new();
            if (l.Count <= 5)
                for (int i = 0; i < l.Count; i++)
                    tok.Add(l[i].ToString());
            else
            {
                for (int i = 0; i < 3; i++)
                    tok.Add(l[i].ToString());
                tok.Add("...");
                for (int i = l.Count - 3; i < l.Count; i++)
                    tok.Add(l[i].ToString());
            }
            return "[" + string.Join(", ", tok) + "]";
        }

        public static string getJsonType(object obj)
        { 
            string result = "";
            if (obj == null)
                result = "";
            else if (obj is List<object> l)
            {
                var cnt = l.Count;
                if (cnt == 0)
                    result = "List<object>";
                else
                {
                    var subObj = l[0];
                    if (subObj is List<object> subList)
                        result = $"List<List<{subList[0].GetType()}>>[{cnt}]";
                    else
                        result = $"List<{l[0].GetType()}>[{cnt}]";
                }
            }
            else 
                result = obj.GetType().ToString();
            return result.Replace("System.", "");
        }

        public static string getJsonType(IDictionary<string, object> node, string jsonPath)
        {
            var obj = getJsonValue(node, jsonPath);
            return getJsonType(obj);
        }

        // is this a List-of-Lists [of double]?
        public static bool isLoL(IDictionary<string, object> node, string jsonPath)
        {
            var obj = getJsonValue(node, jsonPath);
            return isLoL(obj);
        }

        // is this a List-of-Double?
        public static bool isLoD(IDictionary<string, object> node, string jsonPath)
        {
            var obj = getJsonValue(node, jsonPath);
            return isLoD(obj);
        }

        public static bool isLoL(object obj) 
        {
            var typeName = getJsonType(obj);
            return typeName.StartsWith("List<List<Double>>");
        }

        public static bool isLoD(object obj)
        {
            var typeName = getJsonType(obj);
            return typeName.StartsWith("List<Double>");
        }

        public static List<double> toLoD(IDictionary<string, object> node, string jsonPath)
        {
            var obj = getJsonValue(node, jsonPath);
            if (obj is List<object> l)
                return l.Cast<double>().ToList();
            return null;
        }

        public static List<List<double>> toLoL(IDictionary<string, object> node, string jsonPath)
        {
            List<List<double>> data = new();

            var pivotObj = Util.getJsonValue(node, jsonPath);
            List<object> l = (List<object>)pivotObj;
            foreach (var subObj in l)
            {
                List<object> subList = (List<object>)subObj;
                List<double> values = subList.Cast<double>().ToList();
                data.Add(values);
            }
            return data;
        }

        public static List<List<double>> toLoLTransposed(IDictionary<string, object> node, string jsonPath)
        {
            List<List<double>> data = new();

            var pivotObj = Util.getJsonValue(node, jsonPath);
            List<object> l = (List<object>)pivotObj;
            foreach (var subObj in l)
            {
                List<object> subList = (List<object>)subObj;
                List<double> values = subList.Cast<double>().ToList();
                if (data.Count == 0)
                    for (int i = 0; i < values.Count; i++)
                        data.Add(new List<double>());
                for (int i = 0; i < values.Count; i++)
                    data[i].Add(values[i]);
            }
            return data;
        }

        ////////////////////////////////////////////////////////////////////////
        //                                                                    //
        //                          Math Helpers                              //
        //                                                                    //
        ////////////////////////////////////////////////////////////////////////

        public static List<double> mean2D(List<List<double>> data)
        {
            List<double> result = new();
            for (int i = 0; i < data.Count; i++)
                result.Add(data[i].Average());
            return result;
        }

        /// <see href="https://stackoverflow.com/a/897463/11615696"/>
        public static double stdev(IEnumerable<double> values)
        {
            double M = 0.0;
            double S = 0.0;
            int k = 1;
            foreach (var value in values)
            {
                var tmpM = M;
                M += (value - tmpM) / k;
                S += (value - tmpM) * (value - M);
                k++;
            }
            return Math.Sqrt(S / (k - 2));
        }

        public static List<double> stdev2D(List<List<double>> data)
        {
            List<double> result = new();
            for (int i = 0; i < data.Count; i++)
                result.Add(stdev(data[i]));
            return result;
        }

        public static double median(IEnumerable<double> values)
        {
            List<double> s = new(values);
            s.Sort();
            return (s.Count % 2 == 1) ? s[s.Count / 2] : (s[s.Count / 2 - 1] + s[s.Count / 2]) / 2.0;
        }

        public static List<double> median2D(List<List<double>> data)
        {
            List<double> result = new();
            for (int i = 0; i < data.Count; i++)
                result.Add(median(data[i]));
            return result;
        }

        public static List<double> max2D(List<List<double>> data)
        {
            List<double> result = new();
            for (int i = 0; i < data.Count; i++)
                result.Add(data[i].Max());
            return result;
        }

        public static List<double> min2D(List<List<double>> data)
        {
            List<double> result = new();
            for (int i = 0; i < data.Count; i++)
                result.Add(data[i].Min());
            return result;
        }
    }
}
