using System;

namespace _10_FindSumInArray
{
    class FindSum
    {
        static void Main()
        {   //TODO: all
            int n = int.Parse(Console.ReadLine());
            int sumToFind = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int startIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;

                for (int j = i; j < arr.Length - i; j++)
                {
                    sum += arr[j];
                }
                if (sum == sumToFind)
                {
                    Console.WriteLine("found sum");
                    break;
                }
            }

        }
    }
}
