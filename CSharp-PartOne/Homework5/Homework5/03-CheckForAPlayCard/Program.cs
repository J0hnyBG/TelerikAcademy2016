using System;
using System.Linq;

class Program
{
    private static void Main()
    {
        string input = Console.ReadLine();
        string[] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        bool isCorrectCard = cards.Any(card => input.ToUpper() == card);

        if (isCorrectCard)
        {
            Console.WriteLine("yes " + input.ToUpper());
        }
        else
        {
            Console.WriteLine("no " + input);
        }
    }
}

