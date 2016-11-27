using System;
using System.Collections.Generic;

namespace _07_FindPaths
{
    internal class Startup
    {
        private const char Passable = ' ';
        private const char Blocked = '*';
        private const char Exit = 'e';
        private const char Start = 's';
        private const char Passed = '-';

        private static readonly IList<Point> Directions = new List<Point>
                                                          {
                                                              // left
                                                              new Point(0, -1),
                                                              // right
                                                              new Point(0, 1),
                                                              // down
                                                              new Point(1, 0),
                                                              // up
                                                              new Point(-1, 0),
                                                          };

        private static readonly char[,] Matrix =
        {
            { ' ', 's', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', ' ', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', 'e' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
        };

        private static readonly IList<Point> Path = new List<Point>();

        private static void Main()
        {
            var start = FindStart();

            FindPath(start);
        }

        private static Point FindStart()
        {
            for (var row = 0; row < Matrix.GetLength(0); row++)
            {
                for (var col = 0; col < Matrix.GetLength(1); col++)
                {
                    if (Matrix[row, col] == Start)
                    {
                        return new Point(row, col);
                    }
                }
            }

            return new Point(0, 0);
        }

        private static void FindPath(Point current)
        {
            if (!IsInside(current.Row, current.Col))
            {
                return;
            }

            if (Matrix[current.Row, current.Col] == Blocked)
            {
                return;
            }

            if (Matrix[current.Row, current.Col] == Exit)
            {
                Path.Add(new Point(current.Row, current.Col));
                Print(Path);
                Path.RemoveAt(Path.Count - 1);
            }

            if (Matrix[current.Row, current.Col] != Passable && Matrix[current.Row, current.Col] != Start)
            {
                return;
            }

            Path.Add(new Point(current.Row, current.Col));
            Matrix[current.Row, current.Col] = Passed;

            foreach (var direction in Directions)
            {
                FindPath(current + direction);
            }

            Matrix[current.Row, current.Col] = Passable;
            Path.RemoveAt(Path.Count - 1);
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < Matrix.GetLength(0) && col >= 0 && col < Matrix.GetLength(1);
        }

        private static void Print(IEnumerable<Point> path)
        {
            Console.WriteLine("Path: ");
            Console.WriteLine(string.Join(", ", path));
        }
    }
}
