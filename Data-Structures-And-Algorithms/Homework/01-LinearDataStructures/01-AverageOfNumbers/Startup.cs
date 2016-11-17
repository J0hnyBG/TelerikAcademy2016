using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_AverageOfNumbers
{
    internal class Startup
    {
        private static void Main()
        {
            var numbersCollection = new List<int>();

            var userInput = Console.ReadLine();
            while (userInput != string.Empty)
            {
                int number;
                var isParsed = int.TryParse(userInput, out number);

                if (isParsed)
                {
                    numbersCollection.Add(number);
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer!");
                }

                userInput = Console.ReadLine();
            }

            long sum = numbersCollection.Sum();
            double avg = numbersCollection.Average();

            Console.WriteLine($"Average: {avg}\nSum: {sum}");
        }
    }
}
