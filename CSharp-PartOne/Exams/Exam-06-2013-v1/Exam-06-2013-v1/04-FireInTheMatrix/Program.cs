using System;
using System.Diagnostics;
namespace _04_FireInTheMatrix
{
    internal class Program
    {
        private static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int offset = 0;
            int offset2 = 0;
            int c = 0;
            bool exit = true;

            while (exit) //numberoflines
            {
                if (c < width / 2)
                {
                    offset++;
                }
                else if (c > width / 2)
                {
                    offset--;
                }

                for (int i = 1; i <= width; i++)
                {

                    //--------- Line
                    if (c == width * 3 / 4)
                    {
                        Console.Write("-");
                        offset2 = 0;
                    }
                    // \\\/// lines
                    else if (c > width * 3 / 4)
                    {
                        if (i < offset2 || i > width - offset2 + 1)
                        {
                            Console.Write(".");
                        }
                        else
                        {
                            if (i <= width / 2)
                            {
                                Console.Write("\\");

                            }
                            else if (i > width / 2)
                            {
                                Console.Write("/");
                            }
                        }
                        if (offset2 == width / 2)
                        {
                            exit = false;
                        }
                    }

                    // ...##... lines
                    else
                    {

                        if (i == width / 2 + offset || i == width / 2 + 1 - offset)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write(".");
                        }

                    }

                }
                offset2++;
                Console.WriteLine();

                c++;
            }

            //Alternative better solution
            //int N = int.Parse(Console.ReadLine());

            //// Top part of fire
            //for (int i = 1; i <= N / 2; i++)
            //{
            //    Console.Write(new string('.', N / 2 - i));
            //    Console.Write('#');
            //    Console.Write(new string('.', (i - 1) * 2));
            //    Console.Write('#');
            //    Console.WriteLine(new string('.', N / 2 - i));
            //}

            //// Bottom part of fire
            //for (int i = 1; i <= N / 4; i++)
            //{
            //    Console.Write(new string('.', i - 1));
            //    Console.Write('#');
            //    Console.Write(new string('.', (N / 2 - i) * 2));
            //    Console.Write('#');
            //    Console.WriteLine(new string('.', i - 1));
            //}

            //// Top part of torch
            //Console.WriteLine(new string('-', N));

            //// Torch
            //for (int i = 1; i <= N / 2; i++)
            //{
            //    Console.Write(new string('.', i - 1));
            //    Console.Write(new string('\\', N / 2 - (i - 1)));
            //    Console.Write(new string('/', N / 2 - (i - 1)));
            //    Console.WriteLine(new string('.', i - 1));
            //}
        }
    }
}
