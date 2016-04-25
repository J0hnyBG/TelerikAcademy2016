using System;

namespace _04_ExRugs
{
    internal class Program
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            int width = 1 + 2*n;

            //Top part


            //Console.Write(new string('#', 3));
            //Console.Write(new string('#', 4));
            //Console.Write(new string('#', 5));
            //Console.Write(new string('\\', 1));

            //Console.Write(new string('.', width - 2 - 3*2));
            //Console.Write(new string('.', width - 2 - 4*2));
            //Console.Write(new string('.', width - 2 - 5*2));

            //Console.Write(new string('/', 1));
            //Console.Write(new string('#', 3));
            //Console.Write(new string('#', 4));
            //Console.Write(new string('#', 5));
            //Console.WriteLine();
            int offset = 0;
            //Top quarter
            for (int i = 0; i < width/2; i++)
            {
                if (i < width/4)
                {
                    Console.Write(new string('#', (d/2)+1 + i));
                    Console.Write(new string('\\', 1));
                    Console.Write(new string('.', width/2 - (1 + i*2)));
                    Console.Write(new string('/', 1));
                    Console.WriteLine(new string('#', (d / 2) + 1 + i));
                }
            }
            //Next half
            for (int i = 0; i < width/2; i++)
            {
                
            }
        }
    }
}