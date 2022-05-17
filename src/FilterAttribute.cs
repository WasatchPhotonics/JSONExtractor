﻿using System;
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
        public int rejectCount { get; set; }

        public string jsonFullPath;
        Regex re;
        DateTime dateThreshold;
        bool dateValid = false;
        public bool isFilenameFilter;

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
                    else // filterType == FilterType.DateAfter
                        return dateThreshold < date;
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

            if (!pass)
                rejectCount++;
            return pass;
        }
    }
}
