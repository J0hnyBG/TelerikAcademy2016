using System;
using System.Data;

namespace _01_FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char inputChar = char.ToLower(Console.ReadLine()[0]);

            int[,] matrix = new int[n, n];
            int startingNumber = 1;

            switch (inputChar)
            {
                case 'a':
                    FillA(matrix, n);
                    break;
                case 'b':
                    FillB(matrix, n);
                    break;
                case 'c':
                    FillC(matrix, n);
                    break;
                case 'd':
                    FillD(matrix, n - 1);
                    break;
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col== n-1)
                    {
                        Console.Write("{0}", matrix[row, col]);
                    }
                    else
                    {
                        Console.Write("{0} ", matrix[row, col]);
                    }
                }
                Console.WriteLine();
            }
        }

        static void FillA(int[,] matrix, int n, int startingNumber = 1)
        {
            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = startingNumber;
                    startingNumber++;
                }
            }
        }

        static void FillB(int[,] matrix, int n, int startingNumber = 1)
        {
            for (int col = 0; col < n; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = startingNumber;
                        startingNumber++;
                    }
                }
                else
                {
                    for (int row = n - 1; row >= 0; row--)
                    {
                        matrix[row, col] = startingNumber;
                        startingNumber++;
                    }
                }
            }
        }
        static void FillC(int[,] matrix, int n, int startingNumber = 1)
        {
            for (int row = n - 1; row >= 0; row--)
            {
                for (int col = 0; col < n - row; col++)
                {
                    matrix[row + col, col] = startingNumber++;
                }
            }
            for (int col = 1; col < n; col++)
            {
                for (int row = 0; row < n - col; row++)
                {
                    matrix[row, col + row] = startingNumber++;
                }
            }
        }

        static void FillD(int[,] matrix, int n, int startingNumber = 1)
        {
            for (int i = 0; i <= n / 2; i++)
            {
                for (int row = i; row < n - i; row++)
                {
                    matrix[row, i] = startingNumber++;
                }
                for (int col = i; col < n - i; col++)
                {
                    matrix[n - i, col] = startingNumber++;
                }
                for (int row = n - i; row > i; row--)
                {
                    matrix[row, n - i] = startingNumber++;
                }
                for (int col = n - i; col > i; col--)
                {
                    matrix[i, col] = startingNumber++;
                }
            }
            if ((n & 1) == 0)
            {
                matrix[n / 2, n / 2] = startingNumber;
            }
        }
    }
}
