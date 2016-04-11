using System;
//Write a program that, for a given two integer numbers N and x, calculates
//the sum S = 1 + 1!/x + 2!/x<sup>2</sup> + … + n!/x<sup> N</sup>.
//Use only one loop. Print the result with 5 digits after the decimal point.

namespace _05_Calculate
{
    class Program
    {
        static void Main()
        {
            ushort n = ushort.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double sum = 1;
            double lastFactorial = 1;

            for (int i = 1; i <= n; i++)
            {
                lastFactorial *= i;
                sum += lastFactorial/Math.Pow(x, i);
            }
            sum = Math.Round(sum, 5);
            Console.WriteLine("{0:F5}", sum);

        }
    }
}
