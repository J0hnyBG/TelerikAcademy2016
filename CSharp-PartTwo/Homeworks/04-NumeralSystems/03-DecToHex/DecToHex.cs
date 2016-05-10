using System;

namespace _03_DecToHex
{
    class DecToHex
    {
        static void Main()
        {
            long input = long.Parse(Console.ReadLine());

            Console.WriteLine(input.ToString("X"));
        }
    }
}
