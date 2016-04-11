using System;
//Write a program that reads from the console a positive integer
//number N and prints a matrix like in the examples below.Use two nested loops.

namespace _09_MatrixOfNumbers
{
    class Program
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());

            for (int j = 0; j < n; j++)
            {
                for (int i = 1 + j; i <= n + j; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
