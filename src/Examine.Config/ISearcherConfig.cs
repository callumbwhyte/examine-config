using System;

namespace Examine.Config
{
    public interface ISearcherConfig
    {
        string Name { get; }
        string IndexName { get; }
        Type Type { get; }
    }
}