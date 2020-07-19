using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Examine.Config.Helpers
{
    public class MappingHelper : IMappingHelper
    {
        public T Map<T>(object target, object source)
            where T : class
        {
            var properties = target
                .GetType()
                .GetProperties()
                .Where(x => x.CanWrite == true);

            if (properties.Any() == false)
            {
                throw new Exception("No writable properties found to map");
            }

            foreach (var property in properties)
            {
                var sourceValue = property.GetValue(source);

                if (sourceValue != null)
                {
                    property.SetValue(target, sourceValue);
                }
            }

            return (T)target;
        }

        public T Map<T>(object target, IDictionary<string, object> values)
            where T : class
        {
            var properties = target
                .GetType()
                .GetProperties()
                .Where(x => x.CanWrite == true);

            if (properties.Any() == false)
            {
                throw new Exception("No writable properties found to map");
            }

            foreach (var property in properties)
            {
                if (values.TryGetValue(property.Name, out object value) == true)
                {
                    var converter = TypeDescriptor.GetConverter(property.PropertyType);

                    if (converter != null)
                    {
                        property.SetValue(target, converter.ConvertFrom(value));
                    }
                }
            }

            return (T)target;
        }
    }
}