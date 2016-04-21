using System;

namespace _05_Bittris
{
    class Bittris
    {
        static void Main()
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands / 4; i++)
            {
                uint currentNumber = uint.Parse(Console.ReadLine());
                char[] commands = new char[3];
                for (int j = 0; j < 3; j++)
                {
                    commands[j] = Console.ReadLine()[0];
                }


            }

        }
    }
}
