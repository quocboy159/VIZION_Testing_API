using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeApp.Extentions
{
    public static class CollectionExtentions
    {
        public static IEnumerable<(T item, int index)> LoopIndex<T>(this IEnumerable<T> items)
        {
            return items.Select((x, i) => (x, i));
        }
    }
}
