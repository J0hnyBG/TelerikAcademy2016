namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : AbstractSorter<T>
        where T : IComparable<T>
    {
        protected override void SortElements(IList<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private static void Merge(IList<T> collection, int leftIndex, int midIndex, int rightIndex)
        {
            var temp = new T[rightIndex + 1];
            int i;

            var leftEnd = (midIndex - 1);
            var tmpPos = leftIndex;
            var numElements = (rightIndex - leftIndex + 1);

            while ((leftIndex <= leftEnd) && (midIndex <= rightIndex))
            {
                if (collection[leftIndex].CompareTo(collection[midIndex]) < 0)
                {
                    temp[tmpPos++] = collection[leftIndex++];
                }
                else
                {
                    temp[tmpPos++] = collection[midIndex++];
                }
            }

            while (leftIndex <= leftEnd)
            {
                temp[tmpPos++] = collection[leftIndex++];
            }
            while (midIndex <= rightIndex)
            {
                temp[tmpPos++] = collection[midIndex++];
            }
            for (i = 0; i < numElements; i++)
            {
                collection[rightIndex] = temp[rightIndex];
                rightIndex--;
            }
        }

        private void MergeSort(IList<T> numbers, int left, int right)
        {
            if (right <= left) return;

            var mid = (right + left) / 2;
            this.MergeSort(numbers, left, mid);
            this.MergeSort(numbers, (mid + 1), right);

            Merge(numbers, left, (mid + 1), right);
        }
    }
}
