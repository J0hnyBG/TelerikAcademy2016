using System;

namespace _04_Cube
{
    class Cube
    {
        static void Main()
        {
            //totalwidth = 2*n - 1
            //widthPerSide = n (::::::)
            //filledtop = n-2 (//////)
            //filledside = currentRow - 1; (XXXXX)
            //filledFront = n - 2; (         )

            var n = int.Parse(Console.ReadLine());

            //Top row
            Console.Write(new string(' ', n - 1));
            Console.Write(new string(':', n));
            Console.WriteLine();
            
            //Top part
            for (int i = 0; n - 2 - i > 0; i++)
            {
                Console.Write(new string(' ', n - 2 - i));
                Console.Write(new string(':', 1));
                Console.Write(new string('/', n - 2));
                Console.Write(new string(':', 1));
                Console.Write(new string('X', i));
                Console.Write(new string(':', 1));
                Console.WriteLine();
            }

            //Middle row
            Console.Write(new string(':', n));
            Console.Write(new string('X', n-2));
            Console.Write(new string(':', 1));
            Console.WriteLine();

            //Bottom part
            for (int i = 0; n - 3 - i >= 0; i++)
            {
                Console.Write(new string(':', 1));
                Console.Write(new string(' ', n - 2));
                Console.Write(new string(':', 1));
                Console.Write(new string('X', n - 3 - i));
                Console.Write(new string(':', 1));
                Console.WriteLine();
            }
            //Last row
            Console.Write(new string(':', n));
            Console.WriteLine();
        }
    }
}
