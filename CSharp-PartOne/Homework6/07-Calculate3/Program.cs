using System;
using System.Numerics;
//Calculate number of combinations
namespace _07_Calculate3
{
    class Program
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            byte k = byte.Parse(Console.ReadLine());

            var numerator = new BigInteger(1);
            var denominator = new BigInteger(1);

            for (uint i = k + (uint)1; i <= n; i++)
            {
                numerator = BigInteger.Multiply(i, numerator);
            }
            for (uint i = 1; i <= n - k; i++)
            {
                denominator =  BigInteger.Multiply(i, denominator);
            }

            var result = BigInteger.Divide(numerator, denominator);

            Console.WriteLine(result);
        }
    }
}
