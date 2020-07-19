using System;
using System.Collections.Generic;

namespace Examine.Config.Composing
{
    internal class BaseIndexConfig : IIndexConfig
    {
        public BaseIndexConfig(string name)
        {
            Name = name;
        }

        public BaseIndexConfig(IIndexConfig indexConfig)
        {
            Name = indexConfig.Name;
            IncludeFields = indexConfig.IncludeFields;
            ExcludeFields = indexConfig.ExcludeFields;
            Type = indexConfig.Type;
            Path = indexConfig.Path;
            Analyzer = indexConfig.Analyzer;
        }

        public string Name { get; internal set; }

        public IEnumerable<IIndexField> IncludeFields { get; internal set; }

        public IEnumerable<IIndexField> ExcludeFields { get; internal set; }

        public Type Type { get; internal set; }

        public string Path { get; internal set; }

        public Type Analyzer { get; internal set; }
    }
}