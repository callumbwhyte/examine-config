using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Examine.Config.Configuration.Collections;

namespace Examine.Config.Configuration.Sections
{
    public class IndexSection : ConfigurationElement, IIndexConfig
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
        }

        [ConfigurationProperty("includeFields", IsRequired = false)]
        public IndexFieldCollection IncludeFields
        {
            get
            {
                return (IndexFieldCollection)base["includeFields"];
            }
        }

        [ConfigurationProperty("excludeFields", IsRequired = false)]
        public IndexFieldCollection ExcludeFields
        {
            get
            {
                return (IndexFieldCollection)base["excludeFields"];
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

        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get
            {
                return (string)base["path"];
            }
        }

        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty("analyzer", IsRequired = true)]
        public Type Analyzer
        {
            get
            {
                return (Type)base["analyzer"];
            }
        }

        #region Interface members

        IEnumerable<IIndexField> IIndexConfig.IncludeFields => IncludeFields;

        IEnumerable<IIndexField> IIndexConfig.ExcludeFields => ExcludeFields;

        #endregion
    }
}