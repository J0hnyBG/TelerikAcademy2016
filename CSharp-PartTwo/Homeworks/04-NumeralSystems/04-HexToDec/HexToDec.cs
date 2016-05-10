using System;

namespace _04_HexToDec
{
    class HexToDec
    {
        static void Main()
        {
            string hex = Console.ReadLine();

            Console.WriteLine(Convert.ToInt64(hex, 16));
        }
    }
}
