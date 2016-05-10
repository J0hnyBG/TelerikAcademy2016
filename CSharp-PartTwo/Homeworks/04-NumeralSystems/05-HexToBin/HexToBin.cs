using System;
using System.Linq;

namespace _05_HexToBin
{
    internal class HexToBin
    {
        private static void Main()
        {
            string hexStr = Console.ReadLine();
            string binStr = string.Join(string.Empty, hexStr.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            Console.WriteLine(binStr.TrimStart('0'));
        }
    }
}