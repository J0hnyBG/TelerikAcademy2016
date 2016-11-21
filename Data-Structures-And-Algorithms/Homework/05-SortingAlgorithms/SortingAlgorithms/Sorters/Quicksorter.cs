namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class QuickSorter<T> : AbstractSorter<T>
        where T : IComparable<T>
    {
        protected override void SortElements(IList<T> collection)
        {
            Quicksort(collection, 0, collection.Count - 1);
        }

        private static void Quicksort(IList<T> collection, int left, int right)
        {
            int i = left, j = right;
            T pivot = collection[(left + right) / 2];

            while (i <= j)
            {
                while (collection[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (collection[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(collection, left, j);
            }

            if (i < right)
            {
                Quicksort(collection, i, right);
            }
        }
    }
}
