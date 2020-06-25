using System.Collections.Generic;

namespace Examine.Config
{
    public interface IExamineConfig
    {
        IEnumerable<IIndexConfig> Indexes { get; }
        IEnumerable<ISearcherConfig> Searchers { get; }
    }
}