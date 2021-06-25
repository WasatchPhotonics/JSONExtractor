using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace JSONExtractor
{
    class FilterAttribute
    {
        public enum FilterType { Regex, NumberEquals, LessThanEqualTo, GreaterThanEqualTo, Empty, NonEmpty }

        public FilterType filterType { get; set; } = FilterType.NonEmpty;
        public string pattern { get; set; }
        public string jsonFullPath { get; set; }
        public int rejectCount { get; private set; }

        Regex re;

        public FilterAttribute()
        {
            if (filterType == FilterType.Regex)
                re = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        /// <returns>
        /// True if value PASSES filter (i.e. the value should NOT be filtered-
        /// out or rejected)
        /// </returns>
        public bool passesFilter(string value)
        {
            // Empty, NonEmpty
            if (filterType == FilterType.Empty)
                return value is null || value.Length == 0;
            else if (filterType == FilterType.NonEmpty)
                return value != null && value.Length > 0;

            // NumberEquals, LessThanEqualTo, GreaterThanEqualTo
            if (filterType == FilterType.NumberEquals || 
                filterType == FilterType.LessThanEqualTo || 
                filterType == FilterType.GreaterThanEqualTo)
            {
                double d = 0;
                if (!Double.TryParse(value, out d))
                    return false;
                
                double limit = 0;
                if (!Double.TryParse(pattern, out limit))
                    return false;

                if (filterType == FilterType.LessThanEqualTo)
                    return d <= limit;
                else if (filterType == FilterType.GreaterThanEqualTo)
                    return d >= limit;
                else
                    return d == limit;
            }

            // Regex 
            if (re != null && filterType == FilterType.Regex)
                return re.Match(value) != null;
            return false;
        }
    }
}
