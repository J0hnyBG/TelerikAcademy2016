using System;

namespace _05_NumberComparer
{
    class Program
    {
        static void Main()
        {

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            if(a>b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
    }
}
