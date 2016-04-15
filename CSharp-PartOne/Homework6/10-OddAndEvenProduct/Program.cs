using System;

//You are given N integers(given in a single line, separated by a space).
//Write a program that checks whether the product of the odd elements is 
//equal to the product of the even elements.
//Elements are counted from 1 to N, so the first element is odd, the second is even, etc.

namespace _10_OddAndEvenProduct
{
    internal class Program
    {
        private static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            string[] inputNumbers = Console.ReadLine().Trim().Split(' ');

            double evenProduct = 1d;
            double oddProduct = 1d;

            for (int i = 1; i <= n; i++)
            {
                if (i%2 == 0)
                {
                    evenProduct *= double.Parse(inputNumbers[i - 1]);
                }
                else
                {
                    oddProduct *= double.Parse(inputNumbers[i - 1]);
                }
            }

            if (oddProduct == evenProduct)
            {
                Console.WriteLine("yes " + oddProduct);
            }
            else
            {
                Console.WriteLine("no " + oddProduct + " " + evenProduct);
            }
        }
    }
}
