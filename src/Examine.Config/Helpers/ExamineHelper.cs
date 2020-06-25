using System;
using System.Collections.Generic;

namespace Examine.Config.Helpers
{
    public class ExamineHelper : IExamineHelper
    {
        private readonly IExamineManager _examineManager;

        internal ExamineHelper()
            : this(ExamineManager.Instance)
        {

        }

        public ExamineHelper(IExamineManager examineManager)
        {
            _examineManager = examineManager;
        }

        public void ConfigureIndexes(IEnumerable<IIndexConfig> indexes)
        {
            foreach (var index in indexes)
            {
                if (_examineManager.TryGetIndex(index.Name, out IIndex existingIndex) == true)
                {
                    throw new Exception($"Index {index.Name} already exists");
                }
            }
        }

        public void ConfigureSearchers(IEnumerable<ISearcherConfig> searchers)
        {
            foreach (var searcher in searchers)
            {
                if (_examineManager.TryGetIndex(searcher.IndexName, out IIndex index) == false)
                {
                    throw new Exception($"Failed to load {searcher.IndexName} for searcher {searcher.Name}");
                }
            }
        }
    }
}