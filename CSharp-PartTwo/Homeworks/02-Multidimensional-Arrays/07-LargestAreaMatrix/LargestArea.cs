using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_LargestAreaMatrix
{
    class LargestArea
    {
        static void Main()
        {
            var inputString = Console.ReadLine();

            int[] arrayLengths = inputString.Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int[,] matrix = new int[arrayLengths[0], arrayLengths[1]];

            for (int i = 0; i < arrayLengths[0]; i++)
            {
                int[] tempArr = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                for (int j = 0; j < arrayLengths[1]; j++)
                {
                    matrix[i, j] = tempArr[j];
                }
            }
            int maxArea = CheckMatrix(matrix, arrayLengths[1], arrayLengths[0]);
            Console.WriteLine(maxArea);

        }

        private static Stack<int> _branchingCellCol;
        private static Stack<int> _branchingCellRow;
        private static int[,] _matrix;
        private static bool[,] _visitedCells;
        private static int _rows;
        private static int _cols;
        private static int _maxAreaSize;
        private static int _currentAreaSize;


        private static void Initialize(int[,] matrix, int cols, int rows)
        {
            _branchingCellCol = new Stack<int>();
            _branchingCellRow = new Stack<int>();
            InitializeVisitedCells(cols, rows);
            _matrix = matrix;
            _cols = cols;
            _rows = rows;
            _maxAreaSize = 0;
            _currentAreaSize = 0;
        }



        private static void InitializeVisitedCells(int cols, int rows)
        {
            _visitedCells = new bool[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    _visitedCells[row, col] = false;
                }
            }
        }



        private static bool IsBranching(int row, int col)
        {
            int currentValue = _matrix[row, col];
            if (col - 1 >= 0 && _matrix[row, col - 1] == currentValue &&
                IsVisited(row, col - 1) == false) //left
            {
                return true;
            }
            if (col + 1 < _cols && _matrix[row, col + 1] == currentValue &&
                IsVisited(row, col + 1) == false)//right
            {
                return true;
            }
            if (row - 1 >= 0 && _matrix[row - 1, col] == currentValue &&
                IsVisited(row - 1, col) == false)//up
            {
                return true;
            }
            if (row + 1 < _rows && _matrix[row + 1, col] == currentValue &&
                IsVisited(row + 1, col) == false)//down
            {
                return true;
            }

            return false;
        }


        private static bool IsVisited(int row, int col)
        {
            return _visitedCells[row, col];
        }


        public static int CheckMatrix(int[,] matrix, int cols, int rows)
        {
            Initialize(matrix, cols, rows);

            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    if (_visitedCells[row, col] == false && IsBranching(row, col))
                    {
                        _branchingCellCol.Push(col);
                        _branchingCellRow.Push(row);
                        Explore(col, row);
                    }
                }
            }

            return _maxAreaSize;
        }


        private static void Explore(int col, int row)
        {
            int currentValue = _matrix[row, col];
            
            while (_branchingCellCol.Count > 0 && _branchingCellRow.Count > 0)
            {
                col = _branchingCellCol.Pop();
                row = _branchingCellRow.Pop();


                int colTemp = col;
                int rowTemp = row;
                while (colTemp - 1 >= 0 && _matrix[rowTemp, colTemp - 1] == currentValue &&
                    IsVisited(rowTemp, colTemp - 1) == false) //left
                {
                    colTemp = colTemp - 1;
                    
                    _branchingCellCol.Push(colTemp);
                    _branchingCellRow.Push(rowTemp);
                    _visitedCells[rowTemp, colTemp] = true;
                    _currentAreaSize++;

                }

                colTemp = col;
                rowTemp = row;
                while (colTemp + 1 < _cols && _matrix[rowTemp, colTemp + 1] == currentValue &&
                    IsVisited(rowTemp, colTemp + 1) == false)//right
                {
                    colTemp = colTemp + 1;
                    
                    _branchingCellCol.Push(colTemp);
                    _branchingCellRow.Push(rowTemp);
                    _visitedCells[rowTemp, colTemp] = true;
                    _currentAreaSize++;
                }

                colTemp = col;
                rowTemp = row;
                while (rowTemp - 1 >= 0 && _matrix[rowTemp - 1, colTemp] == currentValue &&
                   IsVisited(rowTemp - 1, colTemp) == false)//up
                {
                    
                    rowTemp = rowTemp - 1;
                    _branchingCellCol.Push(colTemp);
                    _branchingCellRow.Push(rowTemp);
                    _visitedCells[rowTemp, colTemp] = true;
                    _currentAreaSize++;
                }

                colTemp = col;
                rowTemp = row;
                while (rowTemp + 1 < _rows && _matrix[rowTemp + 1, colTemp] == currentValue &&
                    IsVisited(rowTemp + 1, colTemp) == false)//down
                {
                    
                    rowTemp = rowTemp + 1;
                    _branchingCellCol.Push(colTemp);
                    _branchingCellRow.Push(rowTemp);
                    _visitedCells[rowTemp, colTemp] = true;
                    _currentAreaSize++;
                }
            }

            if (_currentAreaSize > _maxAreaSize)
            {
                _maxAreaSize = _currentAreaSize;
            }
            _currentAreaSize = 0;
        }
    }
}
