using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _04_LongestSubsequenceOfEqualNumbers
{
    internal class Startup
    {
        private static void Main()
        {
            var numbers = new[] { 1, 1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2, 2, 2, 2 };

            var result = FindLongestSubsequenceOfEqualNumbers(numbers);

            Debug.Assert(result == 10);
            Console.WriteLine(result);
        }

        private static long FindLongestSubsequenceOfEqualNumbers(IList<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("List cannot be null or empty!");
            }

            var currentCount = 1;
            var max = 1;

            for (var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }

                if (currentCount > max)
                {
                    max = currentCount;
                }
            }

            return max;
        }
    }
}
