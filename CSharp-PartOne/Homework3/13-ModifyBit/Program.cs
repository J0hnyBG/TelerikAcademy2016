using System;

namespace _13_ModifyBit
{
    class Program
    {
        static void Main()
        {
            ulong n = ulong.Parse(Console.ReadLine());
            byte p = byte.Parse(Console.ReadLine());
            ushort v = ushort.Parse(Console.ReadLine());
            ulong result = 0;
            if (v==0)
            {
                result = n & (ulong)~(1 << p);
            }
            else if (v == 1)
            {
                result = n | (ulong)(1 << p);
            }

            Console.WriteLine(result);

            
        }
    }
}
