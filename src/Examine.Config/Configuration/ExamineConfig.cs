using System.Collections.Generic;
using System.Configuration;
using Examine.Config.Configuration.Collections;
using Examine.Config.Helpers;

namespace Examine.Config.Configuration
{
    public class ExamineConfig : ConfigurationSection, IExamineConfig
    {
        public ExamineConfig()
        {
            Configure(this);
        }

        [ConfigurationProperty("indexes", IsRequired = true)]
        public IndexCollection Indexes
        {
            get
            {
                return (IndexCollection)base["indexes"];
            }
        }

        [ConfigurationProperty("searchers", IsRequired = true)]
        public SearcherCollection Searchers
        {
            get
            {
                return (SearcherCollection)base["searchers"];
            }
        }

        #region Interface members

        IEnumerable<IIndexConfig> IExamineConfig.Indexes => Indexes;

        IEnumerable<ISearcherConfig> IExamineConfig.Searchers => Searchers;

        #endregion

        public void Configure(IExamineConfig examineConfig)
        {
            ExamineHelper.Instance.RegisterIndexes(examineConfig.Indexes);

            ExamineHelper.Instance.RegisterSearchers(examineConfig.Searchers);
        }
    }
}