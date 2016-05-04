using System;
using System.Diagnostics;

namespace _13_MergeSort
{
    class MergeSortAlgo
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            MergeSort(arr, 0, arr.Length - 1);

            foreach (var num in arr)
            {
                Console.WriteLine(num);
            }
        }

        static public void Merge(int[] numbers, int leftIndex, int midIndex, int rightIndex)
        {
            int[] temp = new int[rightIndex + 1];
            int i;

            int left_end = (midIndex - 1);
            int tmp_pos = leftIndex;
            int num_elements = (rightIndex - leftIndex + 1);

            while ((leftIndex <= left_end) && (midIndex <= rightIndex))
            {
                if (numbers[leftIndex] <= numbers[midIndex])
                {
                    temp[tmp_pos++] = numbers[leftIndex++];
                }
                else
                {
                    temp[tmp_pos++] = numbers[midIndex++];
                } 
            }

            while (leftIndex <= left_end)
            {
                temp[tmp_pos++] = numbers[leftIndex++];
            }
            while (midIndex <= rightIndex)
            {
                temp[tmp_pos++] = numbers[midIndex++];
            }
            for (i = 0; i < num_elements; i++)
            {
                numbers[rightIndex] = temp[rightIndex];
                rightIndex--;
            }
        }

        static public void MergeSort(int[] numbers, int left, int right)
        {
            if (right <= left) return;

            int mid = (right + left)/2;
            MergeSort(numbers, left, mid);
            MergeSort(numbers, (mid + 1), right);

            Merge(numbers, left, (mid + 1), right);
        }
    }
}
