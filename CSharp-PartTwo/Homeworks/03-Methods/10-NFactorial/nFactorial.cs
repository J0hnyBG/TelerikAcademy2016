using System;
using System.Numerics;

namespace _10_NFactorial
{
    class nFactorial
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger result = GetFactorial(n);

            Console.WriteLine(result);
        }

        static BigInteger GetFactorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
