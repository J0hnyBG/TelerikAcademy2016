using System;

namespace _13_MergeSort
{
    class MergeSort
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Sort(arr, 0, arr.Length - 1);

            foreach (var num in arr)
            {
                Console.WriteLine(num);
            }
        }

        private static void Merge(int[] arr, int startIndex, int middleIndex, int endIndex)
        {
            int n1 = middleIndex - startIndex + 1;
            int n2 = endIndex - middleIndex;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                leftArray[i] = arr[startIndex + i];
            }
            for (int i = 0; i < n2; i++)
            {
                rightArray[i] = arr[middleIndex + i];
            }

            int h = 0;
            int j = 0;
            int k = startIndex;
            while (h < n1 && j < n2)
            {
                if (leftArray[h] <= rightArray[j])
                {
                    arr[k] = leftArray[h];
                    h++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (h < n1)
            {
                arr[k] = leftArray[h];
                h++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }

        static void Sort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int middleIndex = startIndex + (endIndex - 1)/2;

                Sort(arr, startIndex, middleIndex);
                Sort(arr, middleIndex + 1, endIndex);

                Merge(arr, startIndex, middleIndex, endIndex);
            }

        }

    }
}
