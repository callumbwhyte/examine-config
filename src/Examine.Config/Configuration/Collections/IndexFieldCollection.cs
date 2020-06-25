using System.Configuration;
using Examine.Config.Configuration.Elements;

namespace Examine.Config.Configuration.Collections
{
    [ConfigurationCollection(typeof(IndexFieldElement))]
    public class IndexFieldCollection : BaseCollection<IndexFieldElement>
    {
        protected override object GetElementKey(IndexFieldElement element) => element.Name;
    }
}