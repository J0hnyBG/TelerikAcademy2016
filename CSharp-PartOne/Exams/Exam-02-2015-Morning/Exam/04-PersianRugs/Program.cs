using System;

namespace _04_PersianRugs
{
    internal class Program
    {
        private static void Main()
        {
            //width= height = 2*n+1
            int n = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            int width = (2*n) + 1;

            //Top part
            for (int i = 0; i < (width/2); i++)
            {
                DrawLine(width, i, d, true);
            }
            //Middle row
            Console.Write(new string('#', n));
            Console.Write("X");
            Console.WriteLine(new string('#', n));

            //Bottom part
            for (int i = width/2 - 1; i >= 0; i--)
            {
                DrawLine(width, i, d, false);
            }
        }

        public static void DrawLine(int width, int i, int d, bool drawTop)
        {
            char slash1 = '/';
            char slash2 = '\\';

            if (drawTop)
            {
                slash1 = '\\';
                slash2 = '/';
            }

            Console.Write(new string('#', i));
            Console.Write(new string(slash1, 1));
            if (d >= (width/2) - 1)
            {
                Console.Write(new string(' ', width - (2*i) - 2));
            }
            else
            {
                if (width - (2 * i + 2 * d + 4) > 0)
                {
                    Console.Write(new string(' ', d));
                    Console.Write(new string(slash1, 1));
                    Console.Write(new string('.', width - (2 * i + 2 * d + 4)));
                    Console.Write(new string(slash2, 1));
                    Console.Write(new string(' ', d));
                }
                else
                {
                   Console.Write(new string(' ', width - (2 * i + 2)));
                }
            }
            Console.Write(new string(slash2, 1));
            Console.Write(new string('#', i));
            Console.WriteLine();
        }
    }
}