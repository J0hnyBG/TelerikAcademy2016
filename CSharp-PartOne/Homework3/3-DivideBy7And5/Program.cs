using System;

namespace _3_DivideBy7And5
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            bool divisibleBy3and5 = false;

            if(input%7 == 0 && input%5 == 0)
            {
                divisibleBy3and5 = true;
            }

            Console.WriteLine("{0} {1}", divisibleBy3and5.ToString().ToLower(), input);

        }
    }
}
