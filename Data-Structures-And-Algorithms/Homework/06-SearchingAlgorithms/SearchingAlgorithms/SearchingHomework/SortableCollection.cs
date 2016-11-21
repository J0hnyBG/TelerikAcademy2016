using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingHomework
{
    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private readonly Random random;

        public SortableCollection()
        {
            this.items = new List<T>();
            this.random = new Random();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
            this.random = new Random();
        }

        public IList<T> Items
        {
            get { return this.items; }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (var i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            var elements = this.items.OrderBy(x => x).ToList();
            var low = 0;
            var high = this.items.Count - 1;

            while (high >= low)
            {
                var mid = low + (high - low) / 2;
                if (elements[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else if (elements[mid].CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        // ~O(n)
        public void Shuffle()
        {
            var n = this.items.Count;
            while (n > 1)
            {
                n--;
                var k = this.random.Next(n + 1);
                var value = this.items[k];
                this.items[k] = this.items[n];
                this.items[n] = value;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
