using System;

namespace _04_MalkoKote
{
    class MalkoKote
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine()); //always even
            char symbol = Console.ReadLine()[0];

            int sizePlusOne = size/4 + 1;
            int sizeMinusOne = size/4 - 1;

            //Topmost row
            Console.Write(new string(' ', 1));
            Console.Write(new string(symbol, 1));
            Console.Write(new string(' ', sizeMinusOne));
            Console.WriteLine(new string(symbol, 1));

            //head
            for (int i = 0; i < sizeMinusOne; i++)
            {
                Console.Write(new string(' ', 1));
                Console.WriteLine(new string(symbol, sizeMinusOne + 2));
            }
            //upper body
            for (int i = 0; i < sizeMinusOne; i++)
            {
                Console.Write(new string(' ', 2));
                Console.WriteLine(new string(symbol, sizeMinusOne));
            }
            //upper lower body
            for (int i = 0; i < sizeMinusOne; i++)
            {
                Console.Write(new string(' ', 1));
                Console.WriteLine(new string(symbol, sizeMinusOne + 2));
            }
            //first tail row
            Console.Write(new string(' ', 1));
            Console.Write(new string(symbol, sizeMinusOne + 2));
            Console.Write(new string(' ', 3));
            Console.WriteLine(new string(symbol, sizeMinusOne + 1));
            //next tail rows
            for (int i = 0; i < sizePlusOne; i++)
            {
                Console.Write(new string(symbol, sizePlusOne + 2));
                Console.Write(new string(' ', 2));
                Console.WriteLine(new string(symbol, 1));
            }
            //last tail row
            Console.Write(new string(symbol, sizePlusOne + 2));
            Console.Write(new string(' ', 1));
            Console.WriteLine(new string(symbol,2));
            //last row
            Console.Write(new string(' ', 1));
            Console.WriteLine(new string(symbol, sizePlusOne + 3));
        }
    }
}
