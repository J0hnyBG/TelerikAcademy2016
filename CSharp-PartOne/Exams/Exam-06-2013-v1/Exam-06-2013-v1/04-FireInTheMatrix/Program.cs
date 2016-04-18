using System;

namespace _04_FireInTheMatrix
{
    internal class Program
    {
        private static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int offset = 0;
            int c = 0;

            while (c < 15)
            {
                if (c < width / 2)
                {
                    offset++;
                }
                else if (c > width/2)
                {
                    offset--;
                }
                for (int i = 1; i <= width; i++)
                {
                    if (i == width/2 + offset || i == width/2 + 1 - offset)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();

                c++;
            }
        }
    }
}
