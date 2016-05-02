using System;
using System.Collections.Generic;

namespace _07_SelectionSort
{
    class SelectonSort
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n-1; i++)
            {
                int iMin = i;

                for (int j = i+1; j < n; j++)
                {
                    if (arr[j] < arr[iMin])
                    {
                        iMin = j;
                    }
                }
                if (iMin != i)
                {
                    SwapInts(arr, i, iMin);
                }
            }

            foreach (var t in arr)
            {
                Console.WriteLine(t);
            }
        }

        static void SwapInts(IList<int> arr, int p1, int p2)
        {
            var temp = arr[p1];
            arr[p1] = arr[p2];
            arr[p2] = temp;
        }
    }
}
