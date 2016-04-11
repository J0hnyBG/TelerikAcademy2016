using System;
//Write a program that enters from the console a positive integer n and prints all
//the numbers from 1 to N inclusive, on a single line, separated by a whitespace.
namespace _01_NumbersFrom1ToN
{
    class Program
    {
        static void Main()
        {
            uint finalNumber = uint.Parse(Console.ReadLine());

            for (var i = 1; i <= finalNumber; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}
