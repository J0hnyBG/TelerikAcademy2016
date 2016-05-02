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

            foreach (var num in arr)
            {
                Console.WriteLine(num);
            }
        }
    }
}
