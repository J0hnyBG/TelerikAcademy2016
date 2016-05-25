using System;

namespace _04_ConsoleJustification
{
    class ConsoleJustification
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int totalWidth = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] words = line.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
