using System;
using System.Numerics;

namespace _08_CatalanNumbers
{
    class Program
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());

            var numerator = new BigInteger(1);
            var denominator = new BigInteger(1);

            for (uint i = n + (uint)1; i <= 2*n; i++)
            {
                numerator = BigInteger.Multiply(i, numerator);
            }
            for (uint i = 1; i <= n + 1; i++)
            {
                denominator = BigInteger.Multiply(i, denominator);
            }

            var result = BigInteger.Divide(numerator, denominator);

            Console.WriteLine(result);
        }
    }
}
