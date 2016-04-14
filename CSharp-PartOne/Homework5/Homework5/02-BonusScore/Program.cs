using System;

namespace _02_BonusScore
{
    class Program
    {
        static void Main()
        {
            var inputNumber = int.Parse(Console.ReadLine());

            if (inputNumber >= 1 && inputNumber <= 3)
            {
                inputNumber *= 10;
                Console.WriteLine(inputNumber);
            }
            else if (inputNumber >= 4 && inputNumber <= 6)
            {
                inputNumber *= 100;
                Console.WriteLine(inputNumber);
            }
            else if (inputNumber >= 7 && inputNumber <= 9)
            {
                inputNumber *= 1000;
                Console.WriteLine(inputNumber);
            }
            else
            {
                Console.WriteLine("invalid score");
            }
        }
    }
}
