using System.Configuration;
using Examine.Config.Configuration.Sections;

namespace Examine.Config.Configuration.Collections
{
    [ConfigurationCollection(typeof(IndexSection), AddItemName = "index")]
    public class IndexCollection : BaseCollection<IndexSection>
    {
        protected override object GetElementKey(IndexSection element) => element.Name;
    }
}