using System;

namespace _01_SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            try
            {
                var input = double.Parse(Console.ReadLine());
                var sqrt = Math.Sqrt(input).ToString("F3");

                if ( sqrt == "NaN" )
                {
                    throw new FormatException();
                }
                Console.WriteLine(sqrt);
            }
            catch ( FormatException )
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
