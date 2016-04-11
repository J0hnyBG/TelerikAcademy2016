using System;
//Write a program that calculates with how many zeroes the factorial of a given number N has at its end.
//Your program should work well for very big numbers, e.g.N = 100000.
namespace _16_Trailing0InNFactorial
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int numberOfZeroes = 0;
            for (int i = 5; n/i >= 1; i *= 5)
            {
                numberOfZeroes += n/i;
            }

            Console.WriteLine(numberOfZeroes);
        }
    }
}
