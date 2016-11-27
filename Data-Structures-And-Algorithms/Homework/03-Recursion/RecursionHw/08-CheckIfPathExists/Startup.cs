using System;
using System.Collections.Generic;

using _07_FindPaths;

namespace _08_CheckIfPathExists
{
    internal class Startup
    {
        private const char Passable = ' ';
        private const char Passed = '-';
        private const char Exit = 'e';
        private const int Size = 100;

        private static readonly IList<Point> Directions = new List<Point>
                                                          {
                                                              // right
                                                              new Point(0, 1),
                                                              // left
                                                              new Point(0, -1),
                                                              // down
                                                              new Point(1, 0),
                                                              // up
                                                              new Point(-1, 0)
                                                          };

        private static readonly char[,] Matrix = new char[Size, Size];
        private static bool pathFound;

        private static void Main(string[] args)
        {
            for (var row = 0; row < Matrix.GetLength(0); row++)
            {
                for (var col = 0; col < Matrix.GetLength(1); col++)
                {
                    Matrix[row, col] = Passable;
                }
            }

            var start = new Point(0, 0);
            Matrix[50, 50] = Exit;
            FindPaths(start);
        }

        private static void FindPaths(Point current)
        {
            if (!IsInside(current.Row, current.Col))
            {
                return;
            }

            if (pathFound)
            {
                return;
            }

            if (Matrix[current.Row, current.Col] == Exit)
            {
                Console.WriteLine("Path found!");
                Console.WriteLine();
                pathFound = true;
            }

            if (Matrix[current.Row, current.Col] == Passable)
            {
                Matrix[current.Row, current.Col] = Passed;

                foreach (var direction in Directions)
                {
                    FindPaths(current + direction);
                }

                Matrix[current.Row, current.Col] = Passable;
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < Matrix.GetLength(0) && col >= 0 && col < Matrix.GetLength(1);
        }
    }
}
