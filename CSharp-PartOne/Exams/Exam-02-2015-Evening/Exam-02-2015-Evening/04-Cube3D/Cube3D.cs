using System;

namespace _04_Cube3D
{
    class Cube3D
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            //TopmostRow
            Console.WriteLine(new string(':', n));

            //Top part
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(":");
                Console.Write(new string(' ', n - 2));
                Console.Write(":");
                Console.Write(new string('|', i));
                Console.Write(":");
                Console.WriteLine();
            }
            //Middle row
            Console.Write(new string(':', n));
            Console.Write(new string('|', n - 2));
            Console.WriteLine(":");
            //bottom part 
            for (int i = 1; i < n  - 1; i++)
            {
                Console.Write(new string(' ', i));
                Console.Write(":");
                Console.Write(new string('-', n-2));
                Console.Write(":");
                Console.Write(new string('|', n - i - 2));
                Console.WriteLine(":");
            }
            //Bottommost row 
            Console.Write(new string(' ', n - 1));
            Console.WriteLine(new string(':', n));


        }
    }
}
