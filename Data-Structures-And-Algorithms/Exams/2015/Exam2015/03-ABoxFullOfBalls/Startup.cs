using System;
using System.Linq;

namespace _03_ABoxFullOfBalls
{
    internal class Startup
    {
        private static void Main()
        {
            var possibleTurns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var ab = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var a = ab[0];
            var b = ab[1];

            var isWin = new bool[b + 1];
            isWin[0] = false;

            for (var currentBalls = 1; currentBalls <= b; currentBalls++)
            {
                foreach (var turn in possibleTurns)
                {
                    if (turn > currentBalls)
                    {
                        continue;
                    }

                    if (!isWin[currentBalls - turn])
                    {
                        isWin[currentBalls] = true;
                    }
                }
            }

            var mikiWins = 0;
            for (var currentBalls = a; currentBalls <= b; currentBalls++)
            {
                if (isWin[currentBalls])
                {
                    mikiWins++;
                }
            }

            Console.WriteLine(mikiWins);
        }
    }
}
