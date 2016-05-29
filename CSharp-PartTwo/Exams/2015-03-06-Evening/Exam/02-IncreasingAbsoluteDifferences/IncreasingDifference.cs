using System;
using System.Linq;

internal class IncreasingDifference
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var intArray = Console.ReadLine().Split().Select(long.Parse).ToArray();

            bool isIncreasing = true;
            for (int j = 2; j < intArray.Length; j++)
            {
                var lastAbsDiff = Math.Abs(intArray[j - 2] - intArray[j - 1]);
                var currentAbsDiff = Math.Abs(intArray[j - 1] - intArray[j]);
                if (lastAbsDiff > currentAbsDiff || currentAbsDiff - lastAbsDiff > 1)
                {
                    isIncreasing = false;
                    break;
                }
            }
            Console.WriteLine(isIncreasing);
        }
    }
}