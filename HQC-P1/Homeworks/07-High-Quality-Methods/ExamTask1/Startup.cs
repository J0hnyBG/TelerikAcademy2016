namespace ExamTask1
{
    using System;
    using System.Numerics;

    internal class Startup
    {
        public static void Main()
        {
            string numberInBase26 = Console.ReadLine();
            string operation = Console.ReadLine();
            string numberInBase7 = Console.ReadLine();

            BigInteger firstNumberInDec = NumericBaseConverter.FromBaseToDecimal(numberInBase26, 26);
            BigInteger secondNumberInDec = NumericBaseConverter.FromBaseToDecimal(numberInBase7, 7);
            BigInteger sumInDecimal = 0;

            switch (operation)
            {
                case "+":
                    sumInDecimal = firstNumberInDec + secondNumberInDec;
                    break;
                case "-":
                    sumInDecimal = firstNumberInDec - secondNumberInDec;
                    break;
            }

            string output = NumericBaseConverter.ConvertToBase(sumInDecimal, 9);

            Console.WriteLine(output);
        }
    }
}
