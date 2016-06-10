namespace HW.Matrix
{
    //Problem 8
    using System;
    using System.Text;
    using Version;

    [Version("3.1")]
    public class Matrix<T> where T : struct, IFormattable
    {
        private T[,] _matrix;

        //Problem 9
        public T this[int row, int col]
        {
            get { return this._matrix[row, col]; }
            set { this._matrix[row, col] = value; }
        }

        public Matrix(T[,] matrix)
        {
            this._matrix = matrix;
        }

        public Matrix(int row, int col)
        {
            this._matrix = new T[row, col];
        }

        //Problem 10
        [Version("1.3")]
        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first._matrix.GetLength(0) != second._matrix.GetLength(0)
                || first._matrix.GetLength(1) != second._matrix.GetLength(1))
            {
                throw new ArgumentException("The two matrices must have the same dimensions!");
            }

            var result = new Matrix<T>(first._matrix.GetLength(0), second._matrix.GetLength(1));

            for (int i = 0; i < result._matrix.GetLength(0); i++)
            {
                for (int j = 0; j < result._matrix.GetLength(1); j++)
                {
                    result[i, j] = (dynamic) first[i, j] + (dynamic) second[i, j];
                }
            }

            return result;
        }

        [Version("1.2")]
        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first._matrix.GetLength(0) != second._matrix.GetLength(0)
                || first._matrix.GetLength(1) != second._matrix.GetLength(1))
            {
                throw new ArgumentException("The two matrices must have the same dimensions!");
            }

            var result = new Matrix<T>(first._matrix.GetLength(0), second._matrix.GetLength(1));

            for (int i = 0; i < result._matrix.GetLength(0); i++)
            {
                for (int j = 0; j < result._matrix.GetLength(1); j++)
                {
                    result[i, j] = (dynamic) first[i, j] - (dynamic) second[i, j];
                }
            }

            return result;
        }

        [Version("1.1")]
        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first._matrix.GetLength(1) != second._matrix.GetLength(0))
            {
                throw new ArgumentException("The two matrices can not be multiplied!");
            }

            var result = new Matrix<T>(first._matrix.GetLength(0), second._matrix.GetLength(1));
            for (int i = 0; i < result._matrix.GetLength(0); i++)
            {
                for (int j = 0; j < result._matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < first._matrix.GetLength(1); k++)
                    {
                        result[i, j] += (dynamic) first[i, k]*(dynamic) second[k, j];
                    }
                }
            }
            return result;
        }

        [Version("1.7")]
        public static bool operator true(Matrix<T> matrix)
        {
            var isTrue = true;
            for (int i = 0; i < matrix._matrix.GetLength(0) && isTrue; i++)
            {
                for (int j = 0; j < matrix._matrix.GetLength(1) && isTrue; j++)
                {
                    if ((dynamic) matrix[i, j] == 0)
                    {
                        isTrue = false;
                    }
                }
            }
            return isTrue;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            var isTrue = true;
            for (int i = 0; i < matrix._matrix.GetLength(0) && isTrue; i++)
            {
                for (int j = 0; j < matrix._matrix.GetLength(1) && isTrue; j++)
                {
                    if ((dynamic) matrix[i, j] == 0)
                    {
                        isTrue = false;
                    }
                }
            }
            return !isTrue;
        }

        public static bool operator !(Matrix<T> matrix)
        {
            if (matrix)
            {
                return false;
            }
            return true;
        }

        [Version("1.0")]
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < this._matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this._matrix.GetLength(1); j++)
                {
                    output.Append($"{this._matrix[i, j]} ");
                }
                output.Append("\n");
            }

            return output.ToString();
        }
    }
}