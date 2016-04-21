using System;

namespace _04_BatGoikoTower
{
    class BatGoikoTower
    {
        static void Main()
        {
            int h = int.Parse(Console.ReadLine());
            int row = 1;
            int offset = 2;

            for (int i = 0; i < h; i++)
            {
                Console.Write(new string('.', h - i - 1));
                Console.Write("/");
                if (row == i)
                {
                    Console.Write(new string('-', 2*i ));
                    row = row + offset;
                    offset++;
                }
                else
                {
                    Console.Write(new string('.', 2*i ));
                }

                Console.Write("\\");
                Console.WriteLine(new string('.', h - i - 1));
            }
        }
    }
}
//1 3 6 10 15
//1 = 0 + 1
//3 = 1 + 2
//6 = 3 + 3
//10 = 6 + 4
//15 = 10 + 5