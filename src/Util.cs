﻿using System;
using System.Collections.Generic;
using System.Text;
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
                    start = 1;
                for (int i = start; i < tok.Length; i++)
                {
                    var key = tok[i];

                    if (key.EndsWith("[]"))
                        key = key.Substring(0, key.Length - 2);

                    if (node.ContainsKey(key))
                    {
                        if (i + 1 < tok.Length)
                            node = (IDictionary<string, object>)node[key];
                        else
                            result = node[key];
                    }
                    else
                        break;
                }
            }
            catch(Exception ex)
            {
                logger.error($"can't find {tok} in node: {ex}");
            }
            return result;
        }

        /// <see href="https://stackoverflow.com/a/897463/11615696"/>
        public static double standardDeviation(IEnumerable<double> valueList)
        {
            double M = 0.0;
            double S = 0.0;
            int k = 1;
            foreach (double value in valueList)
            {
                double tmpM = M;
                M += (value - tmpM) / k;
                S += (value - tmpM) * (value - M);
                k++;
            }
            return Math.Sqrt(S / (k - 2));
        }
    }
}