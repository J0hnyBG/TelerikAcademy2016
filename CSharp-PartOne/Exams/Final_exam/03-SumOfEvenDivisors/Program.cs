using System;

namespace _03_SumOfEvenDivisors
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            long sumOfDivisors = 0;

            if (b<a)
            {
                b ^= a;
                b ^= a;
                b ^= a;
            }
            //if (a == b)
            //{
            //    for (int i = 2; i <= a; i+=2)
            //    {
            //        if ( a % i == 0)
            //        {
            //            sumOfDivisors += i;
            //        }
            //    }
            //}
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
            //for (int i = a; i <= b; i++)
            //{

            //    for (int j = 2; j <= a; j+=2)
            //    {
            //        if (i % j==0)
            //        {
            //            sumOfDivisors += j;
            //        }
            //    }
            //}

            Console.WriteLine(sumOfDivisors);

        }
    }
}
