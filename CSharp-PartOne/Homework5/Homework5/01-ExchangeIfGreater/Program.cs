using System;

namespace _01_ExchangeIfGreater
{
    class Program
    {
        static void Main()
        {
            var a = double.Parse(Console.ReadLine());
            var b = double.Parse(Console.ReadLine());

            if (a > b)
            {
                Console.WriteLine(b + " " + a);
            }
            else
            {
                Console.WriteLine(a + " " + b);
            }
        }
    }
}
