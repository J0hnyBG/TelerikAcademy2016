using System;

namespace _12_NthBit
{
    class Program
    {
        static void Main()
        {
            ulong input = ulong.Parse(Console.ReadLine());
            byte n = byte.Parse(Console.ReadLine());

            ulong mask = (ulong)(1 << n);
            ulong result = input & mask;
            ulong bit = result >> n;

            Console.WriteLine(bit);
        }
    }
}


