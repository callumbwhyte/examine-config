using System.Collections.Generic;
using System.Configuration;
using Examine.Config.Configuration.Collections;

namespace Examine.Config.Configuration
{
    public class ExamineConfig : ConfigurationSection, IExamineConfig
    {
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
    }
}