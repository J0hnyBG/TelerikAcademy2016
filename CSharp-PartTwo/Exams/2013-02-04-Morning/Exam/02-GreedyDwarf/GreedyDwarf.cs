using System;
using System.Linq;

namespace _02_GreedyDwarf
{
    class GreedyDwarf
    {
        static void Main()
        {
            int[] coins = Console.ReadLine().Split(',').Select(n => int.Parse(n)).ToArray();

            int numberOfPatterns = int.Parse(Console.ReadLine());
            long maxScore = long.MinValue;

            for (int i = 0; i < numberOfPatterns; i++)
            {
                int[] patternNumbers = Console.ReadLine().Split(',').Select(n => int.Parse(n)).ToArray();
                long currentScore = CalculateScore(patternNumbers, coins);
                maxScore = Math.Max(maxScore, currentScore);
            }
            Console.WriteLine(maxScore);
        }

        static long CalculateScore(int[] pattern, int[] coins)
        {
            bool[] visited = new bool[coins.Length];

            long score = coins[0];
            visited[0] = true;
            int position = 0;
            bool backTracking = false;

            while(!backTracking)
            {
                foreach (var number in pattern)
                {
                    position += number;
                    if (position >= 0 && position <= coins.Length - 1)
                    {
                        if (!visited[position])
                        {
                            score += coins[position];
                            visited[position] = true;
                        }
                        else
                        {
                            backTracking = true;
                            break;
                        }
                    }
                    else
                    {
                        backTracking = true;
                        break;
                    }
                }
            }
            return score;
        }
    }
}
