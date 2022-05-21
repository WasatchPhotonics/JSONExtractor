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

        public static double median(IEnumerable<double> values)
        {
            List<double> s = new(values);
            s.Sort();
            return (s.Count % 2 == 1) ? s[s.Count / 2] : (s[s.Count / 2 - 1] + s[s.Count / 2]) / 2.0;
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

        // surely there's an easier way to do this
        public static double toDouble(object o)
        {
            if (o is Double) return (Double)o;
            if (o is Single) return (Single)o;
            if (o is Int64) return (Int64)o;
            if (o is Int32) return (Int32)o;
            if (o is Int16) return (Int16)o;
            return Double.NaN;
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

        public static string joinAny(IEnumerable<object> things, string delim = ", ")
        {
            return string.Join(delim, things.Select(thing => thing.ToString()).ToArray());
        }

        public static List<double> collateMean(List<List<double>> data)
        {
            List<double> result = new();
            for (int i = 0; i < data.Count; i++)
                result.Add(data[i].Average());
            return result;
        }

        public static List<double> collateStdev(List<List<double>> data)
        {
            List<double> result = new();
            for (int i = 0; i < data.Count; i++)
                result.Add(stdev(data[i]));
            return result;
        }

        public static List<double> collateMedian(List<List<double>> data)
        {
            List<double> result = new();
            for (int i = 0; i < data.Count; i++)
                result.Add(median(data[i]));
            return result;
        }
    }
}
