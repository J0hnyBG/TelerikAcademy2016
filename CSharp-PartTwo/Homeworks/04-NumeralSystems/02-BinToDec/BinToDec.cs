using System;

namespace _02_BinToDec
{
    class BinToDec
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(Convert.ToInt64(input, 2));
        }
    }
}

