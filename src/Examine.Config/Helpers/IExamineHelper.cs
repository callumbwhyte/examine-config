using System.Collections.Generic;

namespace Examine.Config.Helpers
{
    public interface IExamineHelper
    {
        void RegisterIndex(IIndexConfig index);
        void RegisterIndexes(IEnumerable<IIndexConfig> indexes);
        void RegisterSearcher(ISearcherConfig searcher);
        void RegisterSearchers(IEnumerable<ISearcherConfig> searchers);
    }
}