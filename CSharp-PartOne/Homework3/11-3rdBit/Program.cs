using System;

namespace _11_3rdBit
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            bool bit = (input & (1 << 3)) != 0;
            if (bit)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
