using System;

namespace _03_CorrectBrakets
{
    class CorrectBrackets
    {
        static void Main()
        {
            var equation = Console.ReadLine();

            var brackets = 0;

            foreach (var t in equation)
            {
                switch (t)
                {
                    case '(':
                        brackets++;
                        break;
                    case ')':
                        brackets--;
                        break;
                }
                if (brackets >= 0) continue;
                Console.WriteLine("Incorrect");
                return;
            }
            Console.WriteLine(brackets == 0 ? "Correct" : "Incorrect");
        }
    }
}
