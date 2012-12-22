using System.Collections.Generic;
using System.Linq;

namespace BlogBuiltBy.ServiceStack.Web.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
        {
            return items == null || !(items.Any());
        }
    }
}