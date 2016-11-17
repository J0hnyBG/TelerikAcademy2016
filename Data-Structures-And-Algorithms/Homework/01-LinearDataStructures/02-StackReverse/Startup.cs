using System;
using System.Collections.Generic;

namespace _02_StackReverse
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter the value for n: ");

            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Please enter a valid integer: ");
            }

            var numberStack = new Stack<int>();
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine("Please enter a number: ");
                int currentNumber;

                while (!int.TryParse(Console.ReadLine(), out currentNumber))
                {
                    Console.WriteLine("Please enter a valid integer: ");
                }

                numberStack.Push(currentNumber);
            }

            Console.WriteLine("Displaying numbers in reverse.");

            var numbersInStackCount = numberStack.Count;
            for (var i = 0; i < numbersInStackCount; i++)
            {
                var numberToDisplay = numberStack.Pop();
                Console.WriteLine(numberToDisplay);
            }
        }
    }
}
