using System;
//You are given N integers(given in a single line, separated by a space).
//Write a program that checks whether the product of the odd elements is 
//equal to the product of the even elements.
//Elements are counted from 1 to N, so the first element is odd, the second is even, etc.
namespace _10_OddAndEvenProduct
{
    class Program
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            string[] inputNumbers = Console.ReadLine().Split(' ');

            var oddProduct = 1;
            var evenProduct = 1;

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (i%2 == 0)
                {
                    evenProduct *= int.Parse(inputNumbers[i]);
                }
                else
                {
                    oddProduct *= int.Parse(inputNumbers[i]);
                }
            }

            if (evenProduct == oddProduct)
            {
                Console.WriteLine("yes " + evenProduct);
            }
            else
            {
                Console.WriteLine("no "+ evenProduct + " " + oddProduct);
            }

        }
    }
}
