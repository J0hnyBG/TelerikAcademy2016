//Write a program that reads from the console a positive integer number N(1 ≤ N ≤ 20) and prints a matrix holding the numbers from 1 to N* N in the form of square spiral like in the examples below.
using System;
namespace _17_SpiralMatrix
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int nSquared = n*n;
            int col = 0;
            int row = 0;
            int direction = 0; //0 - right, 1 - down, 2 - left, 3 - up

            int[,] matrix = new int[n, n];

            for (int i = 1; i <= nSquared; i++)
            {
                //Check if current position is populated or outside of the array and change direction if it is
                if (direction == 0 && (col > n - 1 || matrix[row, col] != 0))
                {
                    direction = 1;
                    col--;
                    row++;
                }
                else if (direction == 1 && (row > n - 1 || matrix[row, col] != 0))
                {
                    direction = 2;
                    row--;
                    col--;
                }
                else if (direction == 2 && (col < 0 || matrix[row, col] != 0))
                {
                    direction = 3;
                    col++;
                    row--;
                }
                else if (direction == 3 && (row < 0 || matrix[row, col] != 0))
                {
                    direction = 0;
                    row++;
                    col++;
                }

                //Populate current position
                matrix[row, col] = i;

                //Increment position according to direction
                switch (direction)
                {
                    case 0:
                        col++;
                        break;
                    case 1:
                        row++;
                        break;
                    case 2:
                        col--;
                        break;
                    case 3:
                        row--;
                        break;
                }
            }

            //Display matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
