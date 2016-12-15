using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02_Products.Collections
{
    public class RangedCollection<T> : IEnumerable<T>
    {
        private readonly SortedList<Range, List<T>> intervals;

        public RangedCollection(int totalRanges, int minValue, int maxValue)
        {
            this.intervals = new SortedList<Range, List<T>>();
            this.InitializeRanges(totalRanges, minValue, maxValue);
        }

        public void InitializeRanges(int totalRanges, int min = int.MinValue, int max = int.MaxValue)
        {
            var coeff = max / totalRanges;
            var from = min;
            var to = from + coeff - 1;
            for (var i = 1; i < totalRanges + 1; i++)
            {
                var range = new Range(from, to);
                this.intervals.Add(range, new List<T>());
                from = min + i * coeff;
                to = from + coeff - 1;
            }
        }

        public void Add(T item, int value)
        {
            var interval = this.BinarySearch(this.intervals.Keys, value);
            if (interval == null)
            {
                throw new ArgumentException("No such interval!");
            }

            interval.Add(item);
        }

        public IList<T> Find(int from, int to, int numberOfItems = 0)
        {
            if (numberOfItems == 0)
            {
                var result = this.intervals.Where(i => i.Key.CompareTo(from) > 0 && i.Key.CompareTo(to) < 0)
                                    .SelectMany(x => x.Value)
                                    .ToList();
                return result;
            }
            else
            {
                var result = this.intervals.Where(i => i.Key.CompareTo(from) > 0 && i.Key.CompareTo(to) < 0)
                                    .SelectMany(x => x.Value)
                                    .Take(numberOfItems)
                                    .ToList();
                return result;
            }
        }

        public IList<T> BinarySearch(IList<Range> ranges, int value)
        {
            var min = 0;
            var max = ranges.Count - 1;

            while (min <= max)
            {
                var mid = (min + max) / 2;
                var comparison = ranges[mid].CompareTo(value);
                if (comparison == 0)
                {
                    return this.intervals[ranges[mid]];
                }

                if (comparison < 0)
                {
                    min = mid + 1;
                }
                else if (comparison > 0)
                {
                    max = mid - 1;
                }
            }

            return null;
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.intervals.Values.SelectMany(collection => collection).GetEnumerator();
        }
    }
}
