using System;

namespace _01_OddNumber
{
    internal class Startup
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            long number = 0;
            for (var i = 0; i < n; i++)
            {
                number ^= long.Parse(Console.ReadLine());
            }

            Console.WriteLine(number);
        }
    }
}
