using System;
using System.Linq;

namespace _07_CountNumbers
{
    internal class Startup
    {
        private static void Main()
        {
            var numbers = new[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var distinct = numbers.Distinct();
            foreach (var number in distinct)
            {
                var count = numbers.Count(n => n == number);
                Console.WriteLine($"{number} -> {count} times");
            }
        }
    }
}
