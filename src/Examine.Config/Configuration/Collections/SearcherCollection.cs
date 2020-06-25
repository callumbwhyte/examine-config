using System.Configuration;
using Examine.Config.Configuration.Sections;

namespace Examine.Config.Configuration.Collections
{
    [ConfigurationCollection(typeof(SearcherSection), AddItemName = "searcher")]
    public class SearcherCollection : BaseCollection<SearcherSection>
    {
        protected override object GetElementKey(SearcherSection element) => element.Name;
    }
}