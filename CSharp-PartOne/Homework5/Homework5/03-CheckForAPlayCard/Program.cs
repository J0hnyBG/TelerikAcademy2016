using System;
using System.Linq;

class Program
{
    private static void Main()
    {
        string input = Console.ReadLine();
        string[] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "j", "q", "k", "a"};
        bool isCorrectCard = cards.Any(card => input.ToLower() == card);

        if (isCorrectCard)
        {
            Console.WriteLine("yes " + input.ToLower());
        }
        else
        {
            Console.WriteLine("no " + input);
        }
    }
}

