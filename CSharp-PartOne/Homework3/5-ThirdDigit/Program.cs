using System;

namespace _5_ThirdDigit
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            int third = 0;

            if (input.Length >= 3)
            {
                third = input[input.Length - 3] - '0';
            }
            
            bool equals7 = false;
            if (third == 7)
            {
                equals7 = true;
                Console.WriteLine(equals7.ToString().ToLower());
            }
            else
            {
                Console.WriteLine(equals7.ToString().ToLower() + " " + third);
            }
            
        }
    }
}
