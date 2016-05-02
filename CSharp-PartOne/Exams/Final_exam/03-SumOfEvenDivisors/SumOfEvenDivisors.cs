using System;

namespace _03_SumOfEvenDivisors
{
    class SumOfEvenDivisors
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            long sumOfDivisors = 0;

            if (b<a)
            {
                b ^= a;
                a ^= b;
                b ^= a;
            }

            for (int i = a; i <= b; i++)
            {
                for (int j = 2; j <= i; j+=2)
                {
                    if (i % j == 0)
                    {
                        sumOfDivisors += j;
                    }
                }
            }
            Console.WriteLine(sumOfDivisors);

        }
    }
}
