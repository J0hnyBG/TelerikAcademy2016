using System;

namespace _06_BinToHex
{
    class BinToHex
    {
        static void Main()
        {
            string binStr = Console.ReadLine();
            string hexStr = Convert.ToInt64(binStr, 2).ToString("X");

            Console.WriteLine(hexStr);
        }
    }
}
