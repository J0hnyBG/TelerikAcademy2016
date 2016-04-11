using System;
//Write a program that enters 3 real numbers and prints them sorted in descending order.

//Use nested if statements.
//Don’t use arrays and the built-in sorting functionality.
namespace _07_SortThreeNumbers
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a > b && a > c)
            {
                if (b > c)
                {
                    Console.WriteLine("{0} {1} {2}", a, b, c);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", a, c, b);
                }
                
            }
            else if (b > a && b > c)
            {
                if (a > c)
                {
                    Console.WriteLine("{0} {1} {2}", b, a, c);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", b, c, a);
                }
            }
            else //if (c > a && c > b)
            {
                if (b > a)
                {
                    Console.WriteLine("{0} {1} {2}", c, b, a);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", c, a, b);
                }
            }

        }
    }
}
