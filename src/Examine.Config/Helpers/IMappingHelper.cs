using System.Collections.Generic;

namespace Examine.Config.Helpers
{
    public interface IMappingHelper
    {
        T Map<T>(object target, object source) where T : class;
        T Map<T>(object target, IDictionary<string, object> values) where T : class;
    }
}