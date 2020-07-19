using System;

namespace Examine.Config.Composing
{
    internal class BaseSearcherConfig : ISearcherConfig
    {
        public BaseSearcherConfig(string name, string indexName)
        {
            Name = name;
            IndexName = indexName;
        }

        public BaseSearcherConfig(ISearcherConfig searcherConfig)
        {
            Name = searcherConfig.Name;
            IndexName = searcherConfig.IndexName;
            Type = searcherConfig.Type;
        }

        public string Name { get; internal set; }

        public string IndexName { get; internal set; }

        public Type Type { get; internal set; }
    }
}