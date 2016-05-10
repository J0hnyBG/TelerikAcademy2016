using System;
using System.Linq;

namespace _09_SortingArray
{
    class SortingArray
    {
        static void Main()
        {
            string size = Console.ReadLine();
            int[] arr = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            //Array.Sort(arr);
            BubbleSort(arr);
            foreach (var number in arr)
            {
                Console.Write(number + " ");
            }
        }

        static void BubbleSort(int[] arr)
        {
            int temp = 0;
            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
        }
    }
}
