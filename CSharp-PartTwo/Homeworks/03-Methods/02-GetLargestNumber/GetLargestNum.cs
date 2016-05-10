using System;
using System.Linq;

namespace _02_GetLargestNumber
{
    internal class GetLargestNum
    {
        private static void Main()
        {
            string inputString = Console.ReadLine();

            int[] arr = inputString.Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int max = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                max = GetMax(arr[i], max);
            }

            Console.WriteLine(max);
        }

        private static int GetMax(int first, int second)
        {
            return first > second ? first : second;
        }
    }
}