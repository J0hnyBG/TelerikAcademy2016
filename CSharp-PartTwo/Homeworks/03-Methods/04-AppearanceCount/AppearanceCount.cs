using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_AppearanceCount
{
    class AppearanceCount
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int targetNumber = int.Parse(Console.ReadLine());

            int numberOfAppearances = CountAppearances(arr, targetNumber);

            Console.WriteLine(numberOfAppearances);
        }

        static int CountAppearances(IEnumerable<int> arr, int targetNumber)
        {
            return arr.Count(t => t == targetNumber);
        }
    }
}
