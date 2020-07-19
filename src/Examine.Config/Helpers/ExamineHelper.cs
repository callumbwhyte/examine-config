using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Examine.Config.Helpers
{
    public class ExamineHelper : IExamineHelper
    {
        private readonly IExamineManager _examineManager;
        private readonly IMappingHelper _mappingHelper;

        internal ExamineHelper()
            : this(ExamineManager.Instance, new MappingHelper())
        {

        }

        public ExamineHelper(IExamineManager examineManager, IMappingHelper mappingHelper)
        {
            _examineManager = examineManager;
            _mappingHelper = mappingHelper;

        #region Singleton accessors

        public static IExamineHelper Instance => new ExamineHelper();

        public static ConcurrentDictionary<string, IIndexConfig> Indexes => new ConcurrentDictionary<string, IIndexConfig>();

        public static ConcurrentDictionary<string, ISearcherConfig> Searchers => new ConcurrentDictionary<string, ISearcherConfig>();

        #endregion

        public void RegisterIndex(IIndexConfig index)
        {
            if (Indexes.TryGetValue(index.Name, out IIndexConfig baseConfig) == true)
            {
                if (!(index is BaseIndexConfig config))
                {
                    config = new BaseIndexConfig(index);
                }

                index = _mappingHelper.Map<IIndexConfig>(baseConfig, config);
            }

            Indexes[index.Name] = index;
        }

        public void RegisterIndexes(IEnumerable<IIndexConfig> indexes)
        {
            foreach (var index in indexes)
            {
                RegisterIndex(index);
            }
        }

        public void RegisterSearcher(ISearcherConfig searcher)
        {
            if (Searchers.TryGetValue(searcher.Name, out ISearcherConfig baseConfig) == true)
            {
                if (!(searcher is BaseSearcherConfig config))
                {
                    config = new BaseSearcherConfig(searcher);
                }

                searcher = _mappingHelper.Map<ISearcherConfig>(baseConfig, config);
            }

            Searchers[searcher.Name] = searcher;
        }

        public void RegisterSearchers(IEnumerable<ISearcherConfig> searchers)
        {
            foreach (var searcher in searchers)
            {
                RegisterSearcher(searcher);
            }
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