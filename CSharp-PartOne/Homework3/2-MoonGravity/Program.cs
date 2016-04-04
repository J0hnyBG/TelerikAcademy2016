using System;
namespace _2_MoonGravity
{
    class Program
    {
        static void Main()
        {
            double w = double.Parse(Console.ReadLine());

            w = 0.17 * w;

            Console.WriteLine(string.Format("{0:0.000}", Math.Round(w, 3)));
            
            
        }
    }
}
