namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

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

        public int LinearSearch(T item)
        {
            for (var i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public int BinarySearch(T item)
        {
            var low = 0;
            var high = this.items.Count - 1;

            while (true)
            {
                if (high < low)
                {
                    return -1;
                }

                var mid = low + (high - low) / 2;
                if (this.items[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else if (this.items[mid].CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
        }

        public void Shuffle()
        {
            var n = this.items.Count;
            while ( n > 1 )
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
