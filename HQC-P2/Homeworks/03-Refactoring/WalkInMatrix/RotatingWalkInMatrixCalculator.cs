namespace WalkInMatrix
{
    using System;

    public static class RotatingWalkInMatrixCalculator
    {
        public static int[,] Calculate(int matrixSize)
        {
            if (matrixSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(matrixSize), "Matrix size must be a positive number!");
            }

            var matrix = new int[matrixSize, matrixSize];
            int stepCount = 0,
                row = 0,
                col = 0;

            while (FindFirstEmptyCellCoordinates(matrix, ref row, ref col))
            {
                FillMatrix(ref row, ref col, ref stepCount, matrix);
            }

            return matrix;
        }

        private static void ChangeDirectionOfMovementClockwise(ref int rowDelta, ref int colDelta)
        {
            int[] directionsX = {1, 1, 1, 0, -1, -1, -1, 0};
            int[] directionsY = {1, 0, -1, -1, -1, 0, 1, 1};

            var currentDirectionIndex = 0;

            for (var count = 0; count < directionsX.Length; count++)
                if (directionsX[count] == rowDelta
                    && directionsY[count] == colDelta)
                {
                    currentDirectionIndex = count;
                    break;
                }

            if (currentDirectionIndex == 7)
            {
                rowDelta = directionsX[0];
                colDelta = directionsY[0];
                return;
            }

            rowDelta = directionsX[currentDirectionIndex + 1];
            colDelta = directionsY[currentDirectionIndex + 1];
        }

        private static bool CanMoveInAnyDirection(int[,] matrix, int row, int col)
        {
            int[] directionsX = {1, 1, 1, 0, -1, -1, -1, 0};
            int[] directionsY = {1, 0, -1, -1, -1, 0, 1, 1};

            for (var i = 0; i < 8; i++)
            {
                if (row + directionsX[i] >= matrix.GetLength(0) || row + directionsX[i] < 0)
                {
                    directionsX[i] = 0;
                }

                if (col + directionsY[i] >= matrix.GetLength(0) || col + directionsY[i] < 0)
                {
                    directionsY[i] = 0;
                }
            }

            for (var i = 0; i < 8; i++)
            {
                if (matrix[row + directionsX[i], col + directionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool FindFirstEmptyCellCoordinates(int[,] matrix, ref int row, ref int col)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool HasBeenVisited(int row, int col, int[,] matrix)
        {
            return matrix[row, col] != 0;
        }

        private static bool IsOutsideMatrix(int row, int col, int matrixSize)
        {
            return row >= matrixSize
                   || row < 0
                   || col >= matrixSize
                   || col < 0;
        }

        private static void FillMatrix(ref int row, ref int col, ref int stepCount, int[,] matrix)
        {
            var rowDelta = 1;
            var colDelta = 1;
            matrix[row, col] = ++stepCount;

            while (CanMoveInAnyDirection(matrix, row, col))
            {
                while (IsOutsideMatrix(row + rowDelta, col + colDelta, matrix.GetLength(0))
                       || HasBeenVisited(row + rowDelta, col + colDelta, matrix))
                {
                    ChangeDirectionOfMovementClockwise(ref rowDelta, ref colDelta);
                }

                row += rowDelta;
                col += colDelta;
                stepCount++;
                matrix[row, col] = stepCount;
            }
        }
    }
}
