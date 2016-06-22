namespace _03_ExtensionMethodsAndStuff.ExtensionMethods
{   //Problem 2
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class EnumerableExtensions
    {
        public static T MyMax<T>(this IEnumerable<T> collection) where T : IComparable
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

        public static T MyMin<T>(this IEnumerable<T> collection) where T : IComparable
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

        public static decimal MySum<T>(this IEnumerable<T> collection)
            where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            var result = collection.Select(x => Convert.ToDecimal(x)).ToArray();
            var output = 0m;

            foreach (var item in result)
            {
                output += item;
            }
            return output;
        }
        public static decimal MyProduct<T>(this IEnumerable<T> collection)
            where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            var decimalColl = collection.Select(x => Convert.ToDecimal(x)).ToArray();

            var result = 1m;

            foreach (var item in decimalColl)
            {
                result *= item;
            }

            return result;
        }

        public static decimal MyAverage<T>(this IEnumerable<T> collection)
             where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            var sum = collection.MySum();
            var count = collection.Count();
            return sum / count;
        }
    }
}