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
        public enum FilterType { Regex, NumberEquals, LessThanEqualTo, GreaterThanEqualTo, Empty, NonEmpty, DateBefore, DateAfter }

        // public Properties are auto-populated to the bound DataGridView in definition order
        public string name { get; set; }
        public FilterType filterType { get; set; } = FilterType.NonEmpty;
        public string pattern { get; set; }
        public bool nullOk { get; set; }
        public bool negate { get; set; }    
        public bool sufficient { get; set; }

        public string jsonFullPath;
        public bool isFilenameFilter;

        Regex re;
        DateTime dateThreshold;
        bool dateValid = false;

        Logger logger = Logger.getInstance();

        public FilterAttribute(string jsonFullPath, FilterType filterType, string pattern, bool negate)
        {
            this.jsonFullPath = jsonFullPath;
            this.filterType = filterType;
            this.pattern = pattern;
            this.negate = negate;

            isFilenameFilter = (jsonFullPath == "filename");
            name = jsonFullPath.Split("\\").Last();

            if (filterType == FilterType.Regex)
                re = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (filterType == FilterType.DateAfter || filterType == FilterType.DateBefore)
            {
                dateValid = DateTime.TryParse(pattern, out dateThreshold);
                if (!dateValid)
                    logger.error("unable to parse date field: {pattern}");
            }
        }

        public override string ToString()
        {
            return $"FilterAttribute({jsonFullPath}, {filterType}, {pattern})";
        }

        /// <returns>
        /// True if value PASSES filter (i.e. the value should NOT be filtered-
        /// out or rejected)
        /// </returns>
        private bool passesFilterUnnegated(string value)
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
                return re.Match(value).Success;

            if (dateValid)
            {
                DateTime date;
                if (DateTime.TryParse(value, out date))
                {
                    if (filterType == FilterType.DateBefore)
                        return date < dateThreshold;
                    else 
                        return date > dateThreshold;
                }
                else
                {
                    logger.error($"unable to parse date {value} (treating as null)");
                    return nullOk;
                }
            }

            return false;
        }

        public bool passesFilter(string value)
        {
            // first compute straight filter match
            var pass = passesFilterUnnegated(value);

            // negate if requested
            if (negate)
                pass = !pass;

            // ignore failure if empty and nullOk
            if (!pass && nullOk && (value is null || value.Length == 0))
                pass = true;

            return pass;
        }

        ////////////////////////////////////////////////////////////////////////
        // De/Serialization
        ////////////////////////////////////////////////////////////////////////

        public class Serialized
        {
            public string filterType { get; set; }
            public string name { get; set; }
            public string pattern { get; set; }
            public bool nullOk { get; set; }
            public bool negate { get; set; }
            public bool sufficient { get; set; }
            public string jsonFullPath { get; set; }
            public bool isFilenameFilter { get; set; }

            public static Serialized serialize(FilterAttribute fa)
            {
                var ser = new Serialized()
                { 
                    filterType = fa.filterType.ToString(),
                    name = fa.name,
                    pattern = fa.pattern,
                    nullOk = fa.nullOk,
                    negate = fa.negate,
                    sufficient = fa.sufficient,
                    jsonFullPath = fa.jsonFullPath,
                    isFilenameFilter = fa.isFilenameFilter
                };
                return ser;
            }

            public FilterAttribute deserialize()
            {
                FilterType filterTypeEnum = FilterType.Empty;
                Enum.TryParse(filterType, out filterTypeEnum);
                FilterAttribute fa = new(jsonFullPath, filterTypeEnum, pattern, negate)
                {
                    nullOk = nullOk,
                    sufficient = sufficient,
                    isFilenameFilter = isFilenameFilter
                };
                return fa;
            }
        }
    }
}
