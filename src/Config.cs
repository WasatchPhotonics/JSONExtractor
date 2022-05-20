using System.Collections.Generic;

namespace JSONExtractor
{
    internal class Config
    {
        public List<ExtractAttribute.Serialized> extractAttributes { get; set; } = new();
        public List<FilterAttribute.Serialized> filterAttributes { get; set; } = new();
    }
}
