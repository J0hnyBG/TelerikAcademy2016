using System;
using System.Collections.Generic;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int>[] triangle = new List<int>[n + 1];

            triangle[0] = new List<int>();
            triangle[0].Add(1);

            for (int row = 1; row <= n; row++)
            {
                triangle[row] = new List<int>();

                for (int col = 0; col < row + 1; col++)
                {
                    int left = col - 1 < 0 ? 0 : triangle[row - 1][col - 1];
                    int right = col >= triangle[row - 1].Count ? 0 : triangle[row - 1][col];

                    triangle[row].Add(left + right);
                }
            }
            for (int row = 0; row <= n; row++)
            {
                Console.Write("".PadLeft((n - row) * 2));
                for (int col = 0; col <= row; col++)
                {
                    Console.Write("{0, 3} ", triangle[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
