namespace _03_ExtensionMethodsAndStuff.ExtensionMethods
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            var max = collection.First();

            foreach (var item in collection)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            var min = collection.First();

            foreach (var item in collection)
            {
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }

            return min;
        }
    }
}