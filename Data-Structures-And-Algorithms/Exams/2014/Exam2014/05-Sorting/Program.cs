using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Sorting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var collectionCount = int.Parse(Console.ReadLine());
            var numbersToSort = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var countToReverseSwap = int.Parse(Console.ReadLine());

            var result = SwapSort(numbersToSort, countToReverseSwap);
            Console.WriteLine(result);
        }

        private static int SwapSort(IList<int> collection, int groupCount)
        {
            if (collection.IsSorted())
            {
                return 0;
            }

            var previous = new Dictionary<int, int>();
            previous[GetHashCode(collection)] = 0;

            var queue = new Queue<IList<int>>();
            queue.Enqueue(collection);

            while (queue.Count > 0)
            {
                var currentCollection = queue.Dequeue();

                for (var i = 0; i <= collection.Count - groupCount; i++)
                {
                    var modCollection = new int[currentCollection.Count];
                    currentCollection.CopyTo(modCollection, 0);

                    Array.Reverse(modCollection, i, groupCount);

                    if (previous.ContainsKey(GetHashCode(modCollection)))
                    {
                        continue;
                    }

                    var steps = previous[GetHashCode(currentCollection)];
                    if (modCollection.IsSorted())
                    {
                        return steps + 1;
                    }

                    previous[GetHashCode(modCollection)] = steps + 1;
                    queue.Enqueue(modCollection);
                }
            }

            return -1;
        }

        private static int GetHashCode(IEnumerable<int> state)
        {
            return state.Aggregate(0, (current, number) => ( current * 8 ) + number);
        }
    }
}

internal static class ListExtensions
{
    public static bool IsSorted<T>(this IList<T> collection) where T : IComparable<T>
    {
        for (var i = 1; i < collection.Count; i++)
        {
            if (collection[i].CompareTo(collection[i - 1]) < 0)
            {
                return false;
            }
        }

        return true;
    }
}
