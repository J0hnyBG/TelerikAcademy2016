using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_RemoveNegativeNumbers
{
    internal class Startup
    {
        private static void Main()
        {
            var numbers = new List<int>() {-1, 2, 3, 500, -5000, -6, -2, -3, -5, 2, 4, 6, 23, 3, 4, 3, 2, 3, 4, 3, -0, -50, 0 };
            var filteredNumbers = numbers.Where(number => number > 0).ToList();

            foreach (var number in filteredNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
