using System;
//Write a program that calculates the greatest common divisor (GCD) of given two integers A and B.
//Use the Euclidean algorithm
namespace _15_GCD
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

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
