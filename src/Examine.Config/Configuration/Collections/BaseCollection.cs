using System.Collections.Generic;
using System.Configuration;

namespace Examine.Config.Configuration.Collections
{
    public abstract class BaseCollection<T> : ConfigurationElementCollection, IEnumerable<T>
        where T : ConfigurationElement, new()
    {
        protected override ConfigurationElement CreateNewElement() => new T();

        protected override object GetElementKey(ConfigurationElement element) => GetElementKey((T)element);

        protected abstract object GetElementKey(T element);

        public new T this[string key]
        {
            get
            {
                return (T)BaseGet(key);
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return BaseGet(i) as T;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}