using System;
using System.Linq;

namespace _03_SequenceInMatrix
{
    class SequenceInMatrix
    {
        static readonly int[,] Directions = 
        { 
            { 0, 1 },
            { 1, 1 }, 
            { -1, 1 }, 
            { 1, 0 }
        };

        static void Main()
        {
            var inputString = Console.ReadLine();

            int[] arrayLengths = inputString.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            string[][] matrix = new string[arrayLengths[0]][];

            for (int i = 0; i < arrayLengths[0]; i++)
            {
                matrix[i] = Console.ReadLine().Trim().Split(' ').Select(n => n).ToArray();
            }

            int bestLength = 0;
            string bestElement = string.Empty;

            int max = FindLongestSequence(matrix, ref bestElement, ref bestLength);
            Console.WriteLine(max);
        }

        static int FindLongestSequence(string[][] matrix, ref string bestElement, ref int bestLength)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix[0].GetLongLength(0); col++)
                {
                    int direction = -1;

                    while (++direction < 4)
                    {
                        int _row = row + Directions[direction, 0];
                        int _col = col + Directions[direction, 1];
                        int currentLength = 1;

                        while (IsTraversable(matrix, row, col, _row, _col))
                        {
                            currentLength++;

                            if (currentLength > bestLength)
                            {
                                bestLength = currentLength;
                                bestElement = matrix[row][col];
                            }

                            _row += Directions[direction, 0];
                            _col += Directions[direction, 1];
                        }
                    }
                }
            }
            return bestLength;
        }

        static bool IsTraversable(string[][] matrix, int row, int col, int _row, int _col)
        {
            return _row >= 0 && _row < matrix.GetLongLength(0) &&
                   _col >= 0 && _col < matrix[0].GetLongLength(0) &&
                   matrix[_row][_col] == matrix[row][col];
        }

    }
}
