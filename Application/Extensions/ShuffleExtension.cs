using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Extensions
{
    public static class ShuffleExtension
    {
        public static void Shuffle<T>(this IEnumerable<T> items)
        {
            var rnd = new Random();

            var result = items.Select(x => new { value = x, order = rnd.Next() })
                              .OrderBy(x => x.order)
                              .Select(x => x.value)
                              .ToList();
            //return result;
        }
    }
}
