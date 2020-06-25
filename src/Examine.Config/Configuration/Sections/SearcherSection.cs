using System;
using System.ComponentModel;
using System.Configuration;

namespace Examine.Config.Configuration.Sections
{
    public class SearcherSection : ConfigurationElement, ISearcherConfig
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
        }

        [ConfigurationProperty("indexName", IsRequired = true)]
        public string IndexName
        {
            get
            {
                return (string)base["indexName"];
            }
        }

        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty("type", IsRequired = true)]
        public Type Type
        {
            get
            {
                return (Type)base["type"];
            }
        }
    }
}