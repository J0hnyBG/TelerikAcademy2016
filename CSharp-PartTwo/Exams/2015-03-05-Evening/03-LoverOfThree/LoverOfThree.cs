using System;
using System.Linq;

namespace _03_LoverOfThree
{
    class LoverOfThree
    {
        private static bool[,] _visitedCells;
        private static int[] _pawnPosition; //= new int[2];

        static void Main()
        {
            //index 0 - rows, 1 - cols
            int[] fieldDimensions = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int totalNumberOfMoves = int.Parse(Console.ReadLine());

            Initialize(fieldDimensions[0], fieldDimensions[1]);
            long totalScore = 0;

            for (int i = 0; i < totalNumberOfMoves; i++)
            {
                string[] userInput = Console.ReadLine().Split(' ');
                //Get direction - UR, UL, DL, DR
                string directionOfMoves = userInput[0];
                //Get the number of moves in the same direction
                int nOfMoves = int.Parse(userInput[1]) - 1;

                //Get the relative difference between current cell and next cell
                int[] coordDiff = GetStep(directionOfMoves);
                for (int j = 0; j < nOfMoves; j++)
                {
                    if (IsMoveOutside(coordDiff))
                    {
                        break;
                    }
                    MovePawn(coordDiff);
                    //if player hasn't visited cell increment total score
                    if (!_visitedCells[_pawnPosition[0], _pawnPosition[1]])
                    {
                        totalScore += CalculateCellScore(_pawnPosition[0], _pawnPosition[1]);
                        //set cell to visited
                        _visitedCells[_pawnPosition[0], _pawnPosition[1]] = true;
                    }
                }
            }

            Console.WriteLine(totalScore);

        }

        //Set starting position of pawn and initialize the array for visited cells
        static void Initialize(int totalRows, int totalCols)
        {
            _pawnPosition = new[] { (totalRows - 1), 0 };
            _visitedCells = new bool[totalRows, totalCols];
        }

        //Check if move is outside
        static bool IsMoveOutside(int[] coordDiff)
        {
            if (coordDiff[0] + _pawnPosition[0] < 0 || coordDiff[1] + _pawnPosition[1] < 0 || 
                coordDiff[0] + _pawnPosition[0] >= _visitedCells.GetLength(0) || coordDiff[1] + _pawnPosition[1] >= _visitedCells.GetLength(1))
            {
                return true;
            }
            return false;
        }

        //increment player position(index 0 affects rows, 1 affects cols
        static void MovePawn(int[] coordDiff)
        {
            _pawnPosition[0] += coordDiff[0];
            _pawnPosition[1] += coordDiff[1];
        }

        //Get the difference in coordinates between current and next cell
        static int[] GetStep(string direction)
        {
            switch (direction)
            {
                case "UR":
                case "RU":
                    return new[] { -1, 1 };
                case "LU":
                case "UL":
                    return new[] { -1, -1 };
                case "DL":
                case "LD":
                    return new[] { 1, -1 };
                case "DR":
                case "RD":
                    return new[] { 1, 1 };
            }
            throw new FormatException();
        }

        //0 score is bottom-left, max score is top-right in matrix
        static int CalculateCellScore(int row, int col)
        {
            return 3 * (_visitedCells.GetLength(0) - row - 1) + col * 3;
        }
    }
}
