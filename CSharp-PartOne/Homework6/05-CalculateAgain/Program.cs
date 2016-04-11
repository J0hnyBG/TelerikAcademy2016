using System;
using System.Numerics;
//Write a program that calculates N! / K! for given N and K.
//Use only one loop.

namespace _05_CalculateAgain
{
    class Program
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            byte k = byte.Parse(Console.ReadLine());

            BigInteger factorial = new BigInteger(1);

            for (uint i = k + (uint)1; i <= n; i++)
            {
                factorial = BigInteger.Multiply(factorial, i);
            }

            Console.WriteLine(factorial);
        }
    }
}
