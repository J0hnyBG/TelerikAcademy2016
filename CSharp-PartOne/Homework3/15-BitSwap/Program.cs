using System;

namespace _15_BitSwap
{
    class Program
    {
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            for(int i = 0; i < k; i++)
            {
                n = ExchangeBits(p + i, q + i, n);
                
            }

            Console.WriteLine(n);
        }
        static uint ExchangeBits(int first, int second, uint input)
        {
            uint mask = (uint)(1 << first);
            uint result = input & mask;
            uint firstBit = result >> first;
            mask = (uint)(1 << second);
            result = input & mask;
            uint secondBit = result >> second;

            if (firstBit == secondBit)
            {
                return input;
            }
            else if (firstBit == 0 && secondBit == 1)
            {
                result = input | (uint)(1 << first);
                result = result & (uint)~(1 << second);
            }
            else
            {
                result = input | (uint)(1 << second);
                result = result & (uint)~(1 << first);
            }
            return result;
        }
    }
}
