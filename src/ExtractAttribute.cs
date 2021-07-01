using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONExtractor
{
    class ExtractAttribute
    {
        public enum AggregateType { Scalar, Count, Sum, Mean, StdDev, Min, Max, TableRows, TableCols };

        public string label { get; set; }
        public string jsonFullPath { get; set; }
        public string defaultValue { get; set; }
        public AggregateType? aggregateType { get; set; }

        public override string ToString()
        {
            return $"ExtractAttribute({label} ({jsonFullPath}), default {defaultValue}, aggregateType {aggregateType})";
        }
    }
}
