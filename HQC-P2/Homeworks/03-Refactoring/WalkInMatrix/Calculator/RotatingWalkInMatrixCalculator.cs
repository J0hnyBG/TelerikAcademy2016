namespace WalkInMatrix.Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Models;

    /// <summary>
    ///     Provides a method to calculate a Rotating Walk in a matrix by given matrix size.
    /// </summary>
    public static class RotatingWalkInMatrixCalculator
    {
        private static readonly IList<Coordinate2D> AllDirections = new List<Coordinate2D>
                                                                    {
                                                                        new Coordinate2D(1, 1),
                                                                        new Coordinate2D(1, 0),
                                                                        new Coordinate2D(1, -1),
                                                                        new Coordinate2D(0, -1),
                                                                        new Coordinate2D(-1, -1),
                                                                        new Coordinate2D(-1, 0),
                                                                        new Coordinate2D(-1, 1),
                                                                        new Coordinate2D(0, 1)
                                                                    };

        /// <summary>
        ///     Calculates the values of a rotating walk for a matrix of given size.
        /// </summary>
        /// <param name="matrixSize"></param>
        /// <returns>The calculated rotating walk matrix.</returns>
        /// <exception cref="ArgumentOutOfRangeException">when matrixSize is less than 0.</exception>
        public static int[,] Calculate(int matrixSize)
        {
            if (matrixSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(matrixSize), "Matrix size must be a positive number!");
            }

            var matrix = new int[matrixSize, matrixSize];
            int stepCount = 0;

            var currentPosition = Coordinate2D.Zero;

            while (TryFindFirstEmptyCellCoordinates(matrix, ref currentPosition))
            {
                FillMatrix(matrix, currentPosition, ref stepCount);
            }

            return matrix;
        }

        /// <summary>
        ///     Returns the next direction clockwise by a given direction.
        /// </summary>
        /// <param name="currentDirection"></param>
        private static Coordinate2D GetNextDirectionOfMovementClockwise(Coordinate2D currentDirection)
        {
            Debug.Assert(currentDirection.Row == -1 || currentDirection.Row == 0 || currentDirection.Row == 1,
                         "Invalid coordinate row passed!");
            Debug.Assert(currentDirection.Col == -1 || currentDirection.Col == 0 || currentDirection.Col == 1,
                         "Invalid coordinate col passed!");

            for (var i = 0; i < AllDirections.Count; i++)
            {
                if (AllDirections[i].Row == currentDirection.Row
                    && AllDirections[i].Col == currentDirection.Col)
                {
                    i = (i + 1) % AllDirections.Count;
                    return new Coordinate2D(AllDirections[i].Row, AllDirections[i].Col);
                }
            }

            throw new ArgumentException("Invalid coordinate deltas passed!");
        }

        /// <summary>
        ///     Asserts whether there are any neighbouring cells of the current coordinates, which have a value of 0.
        /// </summary>
        /// <param name="matrix">The checked matrix.</param>
        /// <param name="coords">The current coordinates.</param>
        /// <returns>True if any neighbouring cell has not been visited, false otherwise.</returns>
        private static bool CanMoveInAnyDirection(int[,] matrix, Coordinate2D coords)
        {
            Debug.Assert(matrix != null, "Null matrix passed!");
            Debug.Assert(coords != null, "Null coordinates passed!");

            foreach (Coordinate2D direction in AllDirections)
            {
                var newCoordinate = coords + direction;

                if (IsInsideMatrix(newCoordinate, matrix.GetLength(0))
                    && matrix[newCoordinate.Row, newCoordinate.Col] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Modifies the provided coordinates to the indexes of the first cell in the matrix, which has a value of 0.
        /// </summary>
        /// <param name="matrix">The checked matrix.</param>
        /// <param name="coords">The current coordinates.</param>
        /// <returns>False if none of the cells in the matrix have a value of 0, false otherwise.</returns>
        /// <remarks>Doesn't change the coordinate values if no empty cell is found.</remarks>
        private static bool TryFindFirstEmptyCellCoordinates(int[,] matrix, ref Coordinate2D coords)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        coords.Row = row;
                        coords.Col = col;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Asserts whether a cell on a specific position has a value different than 0.
        /// </summary>
        /// <param name="coord">The coordinate to perform the check on.</param>
        /// <param name="matrix">The checked matrix.</param>
        /// <returns>True if the cell's value is different than 0, false otherwise.</returns>
        private static bool HasBeenVisited(Coordinate2D coord, int[,] matrix)
        {
            Debug.Assert(matrix != null, "Null matrix passed!");
            Debug.Assert(coord != null, "Null coordinates passed!");

            return matrix[coord.Row, coord.Col] != 0;
        }

        /// <summary>
        ///     Asserts whether the passed coordinate falls within the range of 0 and matrixSize.
        /// </summary>
        /// <param name="coord">The coordinate to perform the check on.</param>
        /// <param name="matrixSize">The upper bound of the range.</param>
        /// <returns>True if values fall within the range, false otherwise.</returns>
        private static bool IsInsideMatrix(Coordinate2D coord, int matrixSize)
        {
            Debug.Assert(coord != null, "Null coordinates passed!");
            Debug.Assert(matrixSize >= 0, "Invalid matrixSize passed!");

            return 0 <= coord.Row && coord.Row < matrixSize
                   && 0 <= coord.Col && coord.Col < matrixSize;
        }

        /// <summary>
        ///     Loops through a given matrix and fills its cells with Rotating Walk values until all neighbouring cells have been
        ///     visited.
        /// </summary>
        /// <param name="matrix">The matrix to fill.</param>
        /// <param name="currentPos">The current position in the matrix.</param>
        /// <param name="stepCount">The current cell value counter.</param>
        private static void FillMatrix(int[,] matrix, Coordinate2D currentPos, ref int stepCount)
        {
            Debug.Assert(matrix != null, "Null matrix passed!");
            Debug.Assert(currentPos != null, "Null coordinates passed!");

            var directionOfMovement = new Coordinate2D(1, 1);
            matrix[currentPos.Row, currentPos.Col] = ++stepCount;

            while (CanMoveInAnyDirection(matrix, currentPos))
            {
                while (!IsInsideMatrix(currentPos + directionOfMovement, matrix.GetLength(0))
                       || HasBeenVisited(currentPos + directionOfMovement, matrix))
                {
                    directionOfMovement = GetNextDirectionOfMovementClockwise(directionOfMovement);
                }

                currentPos.Row += directionOfMovement.Row;
                currentPos.Col += directionOfMovement.Col;
                matrix[currentPos.Row, currentPos.Col] = ++stepCount;
            }
        }
    }
}
