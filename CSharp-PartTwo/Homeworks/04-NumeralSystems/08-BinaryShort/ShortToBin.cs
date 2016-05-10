using System;

namespace _08_BinaryShort
{
    internal class ShortToBin
    {
        private static void Main()
        {
            short inputNumber = short.Parse(Console.ReadLine());

            Console.WriteLine(Convert.ToString(inputNumber, 2).PadLeft(16, '0'));

        }
    }
}