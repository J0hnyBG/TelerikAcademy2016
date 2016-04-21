using System;
using System.Security.Cryptography.X509Certificates;

namespace _03_CardWars
{
    class CardWars
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int firstTotalScore = 0;
            int secondTotalScore = 0;

            int firstWonGames = 0;
            int secondWonGames = 0;

            var firstWon = false;
            var secondWon = false;

            string[] cardStrength = {"0", "A", "10", "9", "8", "7", "6", "5", "4", "3", "2", "J", "Q", "K"};

            for (int i = 0; i < n; i++) // round loop
            {

                string[] firstPlayerCards = new string[3];
                string[] secondPlayerCards = new string[3];

                int firstPlayerRoundScore = 0;
                int secondPlayerRoundScore = 0;

                bool firstPlayerX = false;
                bool secondPlayerX = false;

                for (int j = 0; j < 3; j++)
                {
                    firstPlayerCards[i] = Console.ReadLine();
                    switch (firstPlayerCards[i])
                    {
                        case "Z":
                            firstTotalScore *= 2;
                            break;
                        case "X":
                            firstPlayerX = true;
                            break;
                        case "Y":
                            firstTotalScore -= 200;
                            break;
                        default:
                            firstPlayerRoundScore += Array.IndexOf(cardStrength, firstPlayerCards[i]);
                            break;
                    }
                }
                for (int j = 0; j < 3; j++)
                {
                    secondPlayerCards[i] = Console.ReadLine();
                    switch (secondPlayerCards[i])
                    {
                        case "Z":
                            secondTotalScore *= 2;
                            break;
                        case "X":
                            secondPlayerX = true;
                            break;
                        case "Y":
                            secondTotalScore -= 200;
                            break;
                        default:
                            secondPlayerRoundScore += Array.IndexOf(cardStrength, secondPlayerCards[i]);
                            break;
                    }
                }
                if (firstPlayerX && secondPlayerX)
                {
                    firstTotalScore += 50;
                    secondTotalScore += 50;
                }
                else if (firstPlayerX)
                {
                    firstWon = true;
                    Console.WriteLine("X card drawn! Player one wins the match!");
                    break;
                }
                else if (secondPlayerX)
                {
                    secondWon = true;
                    Console.WriteLine("X card drawn! Player two wins the match!");
                    break;
                }

                if (firstPlayerRoundScore > secondPlayerRoundScore)
                {
                    firstTotalScore += firstPlayerRoundScore;
                    firstWonGames++;
                }
                else if (secondPlayerRoundScore > firstPlayerRoundScore)
                {
                    secondTotalScore += secondPlayerRoundScore;
                    secondWonGames++;
                }

            }
            if (!(firstWon || secondWon))
            {
                if (firstTotalScore > secondTotalScore)
                {
                    Console.WriteLine("First player wins!");
                    Console.WriteLine("Score: " + firstTotalScore);
                    Console.WriteLine("Games won: " + firstWonGames);
                }
                else if (firstTotalScore == secondTotalScore)
                {
                    Console.WriteLine("It's a tie!");
                    Console.WriteLine("Score: " + firstTotalScore);
                }
                else
                {
                    Console.WriteLine("Second player wins!");
                    Console.WriteLine("Score: " + secondTotalScore);
                    Console.WriteLine("Games won: " + secondWonGames);
                }
            }

        }
    }
}
