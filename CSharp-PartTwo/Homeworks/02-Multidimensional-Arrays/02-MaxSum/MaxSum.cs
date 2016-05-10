using System;
using System.Linq;

namespace _02_MaxSum
{
    internal class MaxSum
    {
        private static void Main()
        {
            var inputString = Console.ReadLine();

            int[] arrayLengths = inputString.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int[][] matrix = new int[arrayLengths[0]][];

            for (int i = 0; i < arrayLengths[0]; i++)
            {
                string row = Console.ReadLine();
                matrix[i] = row.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                
            }

            int maxSum = int.MinValue;

            for (int row = 0; row < arrayLengths[0] - 2; row++)
            {
                for (int col = 0; col < arrayLengths[1] - 2; col++)
                {
                    int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][ col + 2] +
                              matrix[row + 1][ col] + matrix[row + 1][ col + 1] + matrix[row + 1][ col + 2] +
                              matrix[row + 2][ col] + matrix[row + 2][ col + 1] + matrix[row + 2][ col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}