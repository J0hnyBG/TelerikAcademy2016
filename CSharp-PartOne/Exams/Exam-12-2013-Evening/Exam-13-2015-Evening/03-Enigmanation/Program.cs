using System;
using System.Data;

namespace _03_Enigmanation
{
    internal class Program
    {
        private static void Main()
        {//TODO: Unfinished
            string input = Console.ReadLine();


            bool startBracket = false;
            bool endBracket = true;

            int firstNumber = 0;
            int secondNumber = 0;
            char sign = ' ';
            //Console.WriteLine("{0:F4}", Evaluate(input));
            var result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '(':
                        startBracket = true;
                        break;
                    case ')':
                        endBracket = true;
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        if (firstNumber == 0)
                        {
                            firstNumber = input[i] - '0';
                        }
                        else
                        {
                            secondNumber = input[i] - '0';
                        }
                        break;
                    case '+':
                    case '-':
                    case '%':
                    case '*':
                        sign = input[i];
                        break;
                }
                if (firstNumber != 0 && secondNumber != 0 && sign !=' ')
                {
                    result = Calculate(firstNumber, secondNumber, sign);
                    firstNumber = result;
                    secondNumber = 0;
                    sign = ' ';
                }
                Console.WriteLine(result);
            }
            

            Console.WriteLine();
        }

        public static int Calculate(int firstNumber, int secondNumber, char sign)
        {
            var result = 0;
            switch (sign)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '%':
                    result = firstNumber % secondNumber;
                    break;
                case '*':
                    result = firstNumber*secondNumber;
                    break;
            }
            return result;
        }


        public static double Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof (string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string) row["expression"]);
        }
    }
}