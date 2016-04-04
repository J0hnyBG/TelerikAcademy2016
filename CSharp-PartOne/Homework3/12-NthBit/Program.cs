using System;

namespace _12_NthBit
{
    class Program
    {
        static void Main()
        {
            long input = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            bool bit = (input & (1 << n)) != 0;
            
            if (bit)
            {
                Console.WriteLine("1");
            }
            else
            {
                Console.WriteLine("0");
            }


        }
    }
}


