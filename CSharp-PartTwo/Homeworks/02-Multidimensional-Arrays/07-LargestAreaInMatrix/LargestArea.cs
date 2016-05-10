using System;
using System.Linq;

namespace _07_LargestAreaInMatrix
{
    internal class LargestArea
    {
        private static int _maxLength = 0;
        private static int _currentLength = 0;
        private static int _currentNumber = 0;

        private static void Main()
        {
            var inputString = Console.ReadLine();

            int[] arrayLengths = inputString.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int[][] matrix = new int[arrayLengths[0]][];

            for (int i = 0; i < arrayLengths[0]; i++)
            {
                matrix[i] = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            }

            int maxArea = FindMaxAreaLength(matrix);
            Console.WriteLine(maxArea);
        }

        private static int FindMaxAreaLength(int[][] matrix)
        {
            _maxLength = 0;
            int rowLength = matrix.GetLength(0);
            int colLength = matrix[0].GetLength(0);

            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    _currentNumber = matrix[row][col];
                    _currentLength = 0;

                    GetAreaLength(row, col, matrix);

                    if (_currentLength > _maxLength)
                    {
                        _maxLength = _currentLength;
                    }
                }
            }

            return _maxLength;
        }

        private static void GetAreaLength(int row, int col, int[][] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix[0].GetLength(0);

            if (row < 0 || row >= rowLength ||
                col < 0 || col >= colLength || matrix[row][col] == 0)
                return;

            if (matrix[row][col] == _currentNumber)
            {
                matrix[row][col] = 0;
                _currentLength++;

                GetAreaLength(row - 1, col, matrix);
                GetAreaLength(row + 1, col, matrix);
                GetAreaLength(row, col - 1, matrix);
                GetAreaLength(row, col + 1, matrix);
            }
        }
    }
}