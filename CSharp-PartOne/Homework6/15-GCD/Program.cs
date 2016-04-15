using System;
//Write a program that calculates the greatest common divisor (GCD) of given two integers A and B.
//Use the Euclidean algorithm
namespace _15_GCD
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int a = Math.Abs(int.Parse(input[0]));
            int b = Math.Abs(int.Parse(input[1]));

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            Console.WriteLine(a);
        }
    }
}
