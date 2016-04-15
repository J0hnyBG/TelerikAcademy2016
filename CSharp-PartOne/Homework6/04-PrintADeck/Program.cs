using System;
//Write a program that reads a card sign(as a char) from the console and generates and prints all possible cards from a standard deck of 52 cards up to the card with the given sign(without the jokers). The cards should be printed using the classical notation(like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
//The card faces should start from 2 to A.
//Print each card face in its four possible suits: clubs, diamonds, hearts and spades.

namespace _04_PrintADeck
{
    class Program
    {
        static void Main()
        {
            string inputChar = Console.ReadLine();
            string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] suits = {"of spades", "of clubs", "of hearts", "of diamonds"};

            for (int i = 0; i < cards.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    Console.Write(cards[i] + " " + suits[j]);
                    if (j < suits.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }
                if (inputChar.ToUpper() == cards[i])
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
