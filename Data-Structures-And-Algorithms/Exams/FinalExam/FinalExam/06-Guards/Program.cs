using System;
using System.Linq;

namespace _06_Guards
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rc = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rows = rc[0];
            var cols = rc[1];
            var nGuards = int.Parse(Console.ReadLine());
            var maze = new long[rows, cols];
            var memo = new long[rows, cols];

            for (var i = 0; i < maze.GetLength(0); i++)
            {
                for (var j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = 1;
                }
            }

            for (var i = 0; i < nGuards; i++)
            {
                var guardInfo = Console.ReadLine().Split(' ');
                var gRow = int.Parse(guardInfo[0]);
                var gCol = int.Parse(guardInfo[1]);
                var direction = guardInfo[2];

                maze[gRow, gCol] = 3000000;
                switch (direction)
                {
                    case "U":
                        if (gRow - 1 >= 0)
                        {
                            maze[gRow - 1, gCol] = 3;
                        }
                        break;
                    case "D":
                        if (gRow + 1 < maze.GetLength(0))
                        {
                            maze[gRow + 1, gCol] = 3;
                        }
                        break;
                    case "L":
                        if (gCol - 1 >= 0)
                        {
                            maze[gRow, gCol - 1] = 3;
                        }
                        break;
                    case "R":
                        if (gCol + 1 < maze.GetLength(1))
                        {
                            maze[gRow, gCol + 1] = 3;
                        }
                        break;
                }
            }

            var result = Find(maze);

            if (result >= 3000000)
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(result);
            }
        }

        public static long Find(long[,] maze)
        {
            var solution = new long[maze.GetLength(0), maze.GetLength(1)];

            solution[0, 0] = maze[0, 0];
            // fill the first row
            for (var i = 1; i < maze.GetLength(0); i++)
            {
                solution[i, 0] = maze[i, 0] + solution[i - 1, 0];
            }

            // fill the first col
            for (var i = 1; i < maze.GetLength(1); i++)
            {
                solution[0, i] = maze[0, i] + solution[0, i - 1];
            }

            // path will be either from top or left, choose which ever is minimum
            for (var i = 1; i < maze.GetLength(0); i++)
            {
                for (var j = 1; j < maze.GetLength(1); j++)
                {
                    solution[i, j] = maze[i, j]
                                     + Math.Min(solution[i - 1, j], solution[i, j - 1]);
                }
            }

            return solution[maze.GetLength(0) - 1, maze.GetLength(1) - 1];
        }
    }
}
