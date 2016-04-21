using System;

namespace _03_CardWars
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int firstTotalScore = 0;
            int secondTotalScore = 0;

            for (int i = 0; i < n; i++)
            {
                char[] firstPlayerCards = new char[3];
                char[] secondPlayerCards = new char[3];

                for (int j = 0; j < 3; j++)
                {
                    firstPlayerCards[i] = Console.ReadLine()[0];
                }
                for (int j = 0; j < 3; j++)
                {
                    secondPlayerCards[i] = Console.ReadLine()[0];
                }
            }
        }
    }
}
