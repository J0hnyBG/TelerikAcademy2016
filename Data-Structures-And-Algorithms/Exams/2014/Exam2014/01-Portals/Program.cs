using System;
using System.Linq;

namespace _01_Portals
{
    internal class Program
    {
        //TODO: 64/100
        private static void Main(string[] args)
        {
            var xy = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var startX = xy[0];
            var startY = xy[1];

            var rc = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rows = rc[0];
            var cols = rc[1];

            var matrix = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Replace(" ", "").Select(x => x - '0').ToArray();
            }

            var visited = new bool[rows, cols];
            var hasTeleported = false;
            var result = TraverseMatrix(startX, startY, matrix, visited, 0);

            Console.WriteLine(result);
        }

        private static int TraverseMatrix(int row, int col, int[][] matrix, bool[,] visited, int currentSum)
        {
            if (row < 0 || row > matrix.Length - 1
                || col < 0 || col > matrix[0].Length - 1)
            {
                return currentSum;
            }

            if (matrix[row][col] < 0
                || visited[row, col])
            {
                return currentSum;
            }

            visited[row, col] = true;
            var upScore = TraverseMatrix(row - matrix[row][col], col, matrix, visited, currentSum + matrix[row][col]);
            var downScore = TraverseMatrix(row + matrix[row][col], col, matrix, visited, currentSum + matrix[row][col]);
            var leftScore = TraverseMatrix(row, col - matrix[row][col], matrix, visited, currentSum + matrix[row][col]);
            var rightScore = TraverseMatrix(row, col + matrix[row][col], matrix, visited, currentSum + matrix[row][col]);
            visited[row, col] = false;

            return Math.Max(Math.Max(upScore, downScore), Math.Max(leftScore, rightScore));
        }
    }
}
