using System;
using System.Collections.Generic;

namespace Examine.Config
{
    public interface IIndexConfig
    {
        string Name { get; }
        IEnumerable<IIndexField> IncludeFields { get; }
        IEnumerable<IIndexField> ExcludeFields { get; }
        Type Type { get; }
        string Path { get; }
        Type Analyzer { get; }
    }
}