using System;
using System.Numerics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main()
        {
            BigInteger result = 1;
            BigInteger resultWhenMoreThanTen = 1;

            bool moreThanTenCalculated = false;
            int numberCount = 0;

            while (true)
            {
                string inputString = Console.ReadLine();
                BigInteger evenTotalProduct = 1;

                if (inputString == "END")
                {
                    break;
                }
                if (numberCount % 2 ==0)
                {
                    foreach (var ch in inputString)
                    {
                        if (ch != '0')
                        {
                            evenTotalProduct *= (ch - '0');
                        }
                    }
                    if (numberCount < 10)
                    {
                        result *= evenTotalProduct;
                    }
                    else
                    {
                        moreThanTenCalculated = true;
                        resultWhenMoreThanTen *= evenTotalProduct;
                    }
                }

                numberCount++;
            }

            Console.WriteLine(result);
            if (moreThanTenCalculated)
            {
                Console.WriteLine(resultWhenMoreThanTen);
            }
        }
    }
}
