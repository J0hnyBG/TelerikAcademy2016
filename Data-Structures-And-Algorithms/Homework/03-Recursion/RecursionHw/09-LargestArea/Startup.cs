using System;

namespace _09_LargestArea
{
    internal class Startup
    {
        private const char PassableCell = ' ';
        private const char VisitedCell = '-';

        private static readonly char[,] Matrix =
        {
            { '*', ' ', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', '*', '*', ' ' },
            { '*', '*', '*', '*', '*', ' ' },
            { '*', ' ', '*', '*', ' ', '*' },
            { '*', ' ', '*', ' ', ' ', ' ' }
        };

        public static void Main()
        {
            var bestLength = FindLargestConnectedArea();

            Console.WriteLine($"Max area = {bestLength}");
        }

        private static int FindLargestConnectedArea()
        {
            var bestLength = int.MinValue;

            for (var i = 0; i < Matrix.GetLongLength(0); i++)
            {
                for (var j = 0; j < Matrix.GetLongLength(1); j++)
                {
                    var currentLength = 0;

                    FindArea(i, j, ref currentLength);

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                    }
                }
            }

            return bestLength;
        }

        private static void FindArea(int row, int col, ref int currentLength)
        {
            while (true)
            {
                var isNonPassableCell = row < 0 || row >= Matrix.GetLongLength(0) || col < 0 || col >= Matrix.GetLongLength(1) || Matrix[row, col] != PassableCell;

                if (isNonPassableCell)
                {
                    return;
                }

                currentLength++;
                Matrix[row, col] = VisitedCell;

                FindArea(row, col - 1, ref currentLength);
                FindArea(row, col + 1, ref currentLength);
                FindArea(row - 1, col, ref currentLength);
                row = row + 1;
            }
        }
    }
}
