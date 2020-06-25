using System.Collections.Generic;

namespace Examine.Config.Helpers
{
    public interface IExamineHelper
    {
        void ConfigureIndexes(IEnumerable<IIndexConfig> indexes);
        void ConfigureSearchers(IEnumerable<ISearcherConfig> searchers);
    }
}