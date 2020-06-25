using System;
using System.ComponentModel;
using System.Configuration;

namespace Examine.Config.Configuration.Elements
{
    public class IndexFieldElement : ConfigurationElement, IIndexField
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get
            {
                return (string)base["type"];
            }
        }

        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty("analyzer", IsRequired = false)]
        public Type Analyzer
        {
            get
            {
                return (Type)base["analyzer"];
            }
        }
    }
}