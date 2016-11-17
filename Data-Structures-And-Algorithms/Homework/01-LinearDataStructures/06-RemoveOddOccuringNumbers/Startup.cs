using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_RemoveOddOccuringNumbers
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            //{ 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → { 5, 3, 3, 5}
            var numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var filteredCollection = new List<int>();

            foreach (var number in numbers)
            {
                var numberCount = numbers.Count(n => n == number);

                if (numberCount % 2 == 0)
                {
                    filteredCollection.Add(number);
                }
            }

            foreach (var i in filteredCollection)
            {
                Console.WriteLine(i);
            }
        }
    }
}
