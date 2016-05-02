using System;

namespace _11_BinarySearch
{
    internal class BinarySearch
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int x = int.Parse(Console.ReadLine());

            //Easy way
            //Console.WriteLine(Array.BinarySearch(arr, x));

            //Manually
            int low = 0;
            int high = n - 1;

            while (true)
            {
                if (high < low)
                {
                    Console.Write(x + " doesn't exist in array");
                    break;
                }
                int mid = low + (high - low) / 2;
                if (arr[mid] < x)
                {
                    low = mid + 1;
                }
                else if (arr[mid] > x)
                {
                    high = mid - 1;
                }
                else
                {
                    Console.WriteLine(mid);
                    break;
                }
            }

        }
    }
}