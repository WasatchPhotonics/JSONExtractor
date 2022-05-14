using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace JSONExtractor
{
    internal static class Util
    {
        public static string loadText(string pathname)
        {
            if (pathname.EndsWith(".gz"))
            {

                string s = "";
                using (FileStream reader = File.OpenRead(pathname))
                using (GZipStream zip = new GZipStream(reader, CompressionMode.Decompress))
                using (StreamReader unzip = new StreamReader(zip))
                    while (!unzip.EndOfStream)
                        s += unzip.ReadLine();
                return s;
            }
            else
            {
                return File.ReadAllText(pathname);
            }
        }
    }
}
