using System;
using System.Collections.Generic;

namespace _03_SortedSequence
{
    internal class Startup
    {
        private static void Main(string[] args)
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

            numbersCollection.Sort((a, b) => a.CompareTo(b));

            foreach (var number in numbersCollection)
            {
                Console.WriteLine(number);
            }
        }
    }
}
