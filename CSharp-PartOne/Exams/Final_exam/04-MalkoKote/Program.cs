using System;

namespace _04_MalkoKote
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine()); //always even
            int height = size;
            int width = 8 + (size - 8)/2;
            char symbol = Console.ReadLine()[0];
            /*
            //ear spacing
            10=1
            14=2
            18=3
            22=4
            26=5
            width/4
            //end whitespace
            10 = 5
            14 = 6
            18 = 7
            22 = 8
            */
            Console.WriteLine(new string('|', width));
            //Topmost row
            Console.Write(new string(' ', 1));
            Console.Write(new string(symbol, 1));
            Console.Write(new string(' ', 3));
            Console.Write(new string(symbol, 1));
            Console.WriteLine(new string('.', width - 2 - width/4));

        }
    }
}
