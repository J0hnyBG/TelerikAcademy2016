using System;
//Write a program that reads from the console a positive integer N 
//and prints all the numbers from 1 to N not divisible by 3 or 7, on a single line, separated by a space.
namespace _02_NotDivisibleNumbers
{
    class Program
    {
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                if (i%3 != 0 && i%7 != 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
