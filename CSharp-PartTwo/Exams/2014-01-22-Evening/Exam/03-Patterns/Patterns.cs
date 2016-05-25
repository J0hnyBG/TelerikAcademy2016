using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Patterns
{
    class Patterns
    {
        private static int[,] matrix;

        static Dictionary<char, int[]> directions = new Dictionary<char, int[]>
        {
            {'r', new [] {0, 1} },
            {'d', new [] {1, 0} }
        };

        private static char[] patternSteps = { 'r', 'r', 'd', 'd', 'r', 'r', 'r' };

        private static int[] currentCoords = {0, 0};

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            long max = GetMaxPattern();
            if (max != long.MinValue)
            {
                Console.WriteLine("YES " + max);
            }
            else
            {
                Console.WriteLine("NO " + GetDiagonalSum());
            }
        }

        static long GetMaxPattern()
        {
            long maxSum = long.MinValue;
            for (int h = 0; h < matrix.GetLength(0) - 2; h++)
            {
                for (int w = 0; w < matrix.GetLength(1) - 4; w++)
                {
                    currentCoords[0] = h;
                    currentCoords[1] = w;
                    int value = 0;
                    var previousValue = matrix[currentCoords[0], currentCoords[1]] - 1;
                    long currentSum = 0;
                    foreach ( var step in patternSteps)
                    {
                        value = matrix[currentCoords[0], currentCoords[1]];
                        if ( value != previousValue + 1 )
                        {
                            currentSum = long.MinValue;
                            break;
                        }
                        currentSum += value;
                        previousValue = value;
                        currentCoords[0] += directions[step][0];
                        currentCoords[1] += directions[step][1];
                    }
                    maxSum = Math.Max(maxSum, currentSum);
                }
            }
            return maxSum;
        }

        static long GetDiagonalSum()
        {
            long sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }
    }
}
