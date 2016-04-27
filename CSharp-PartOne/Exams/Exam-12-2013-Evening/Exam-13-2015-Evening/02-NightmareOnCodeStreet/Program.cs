using System;

namespace _02_NightmareOnCodeStreet
{
    class Program
    {
        static void Main()
        {
            string inputNumber = Console.ReadLine();
            long result = 0;
            int count = 0;
            for (int i = 1; i < inputNumber.Length; i += 2)
            {
                if (Char.IsDigit(inputNumber[i]))
                {
                    result += inputNumber[i] - '0';
                    count++;
                }
               
            }

            Console.WriteLine(count + " " + result);
        }
    }
}
