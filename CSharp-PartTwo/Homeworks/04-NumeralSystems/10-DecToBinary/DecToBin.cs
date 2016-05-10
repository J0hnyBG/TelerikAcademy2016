using System;

namespace _10_DecToBinary
{
    class DecToBin
    {
        static void Main()
        {
            long inputNumber = long.Parse(Console.ReadLine());

            Console.WriteLine(Convert.ToString(inputNumber, 2));
        }
    }
}
