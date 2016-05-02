using System;

namespace _08_MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxSum = -100000;
            int maxLocal = -100000;

            foreach (var x in arr)
            {
                maxLocal = Math.Max(x, maxLocal + x);
                maxSum = Math.Max(maxSum, maxLocal);
            }

            Console.WriteLine(maxSum);
        }
    }
}
