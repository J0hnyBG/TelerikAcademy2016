using System;

namespace _02_Decoding
{
    class Program
    {
        static void Main()
        {
            int salt = int.Parse(Console.ReadLine());
            string inputString = Console.ReadLine();
            //long result = 1;

            for (int i = 0; i < inputString.Length; i++)
            {
                var result = 0;
                double output = 0;
                if (inputString[i]=='@')
                {
                    break;
                }
                if (Char.IsLetter(inputString[i]))
                {
                    result = (inputString[i]*salt) + 1000;
                }
                else if (Char.IsDigit(inputString[i]))
                {
                    result = (inputString[i] + salt) + 500;
                }
                else
                {
                    result = (inputString[i] - salt);
                }
                if (i%2 == 0)
                {
                    output = (double) result/100;
                    Console.WriteLine("{0:F2}", output);
                }
                else
                {
                    output = result*100;
                    Console.WriteLine(output);
                }
            }

        }
    }
}
