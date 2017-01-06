using System;
using System.Linq;

namespace Doge__
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            var rck = Console.ReadLine()
                             .Split(' ')
                             .Select(int.Parse)
                             .ToArray();

            var rows = rck[0];
            var cols = rck[1];
            var k = rck[2];

            var enemyCoords = Console.ReadLine()
                                 .Split(';');

            var memoTable = new long[rows, cols];
            foreach (var enemyCoordsStr in enemyCoords)
            {
                var coords = enemyCoordsStr.Split(' ')
                                  .Select(int.Parse)
                                  .ToArray();

                memoTable[coords[0], coords[1]] = -1;
            }


            Console.WriteLine(Rec(0, 0, k, memoTable));
        }

        private static long Rec(int currX, int currY, int kRemaining, long[,] memoTable)
        {
            if (currX == memoTable.GetLength(0) - 1
                && currY == memoTable.GetLength(1) - 1)
            {
                return 1;
            }

            if (currX > memoTable.GetLength(0) - 1 || currX < 0
                || currY > memoTable.GetLength(1) - 1 || currY < 0
                || memoTable[currX, currY] < 0)
            {
                return 0;
            }

            if (memoTable[currX, currY] == 0)
            {
                // TODO: Fix
                long kSolutions = 0;
                if (kRemaining > 0)
                {
                    if (currX - 1 >= 0)
                    {
                        memoTable[currX - 1, currY] += Rec(currX - 1, currY, kRemaining - 1, memoTable);
                    }

                    if (currY - 1 >= 0)
                    {
                        memoTable[currX, currY - 1] += Rec(currX, currY - 1, kRemaining - 1, memoTable);
                    }
                }

                memoTable[currX, currY] = Rec(currX + 1, currY, kRemaining, memoTable) +
                                          Rec(currX, currY + 1, kRemaining, memoTable) +
                                          kSolutions;
            }


            return memoTable[currX, currY];
        }
    }
}
