using System;
using System.Linq;
//Write a program that finds the biggest of three numbers that are read from the console.

namespace _05_BiggestOfThree
{
    class Program
    {
        static void Main()
        {
            double[] inputNumbers =
            {
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine())
            };

            double max = inputNumbers.Concat(new double[] {0}).Max();

            Console.WriteLine(max);
        }
    }
}
