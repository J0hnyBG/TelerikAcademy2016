
using System;

namespace _14_BitExchange
{
    class Program
    {
        static void Main()
        {
            uint input = uint.Parse(Console.ReadLine());
            uint result = ExchangeBits(3, 24, input);
            result = ExchangeBits(4, 25, result);
            result = ExchangeBits(5, 26, result);

            Console.WriteLine(result);
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
