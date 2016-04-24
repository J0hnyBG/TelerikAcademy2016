using System;
using System.Numerics;

namespace _03_ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            int i = 0;
            BigInteger result = 1;
            BigInteger resultGreaterThanTen = 1;
            //Needed if i>10 and inputStrings are only 0
            bool result2Modified = false;

            while (true)
            {
                BigInteger oddTotalProduct = 1;
                string inputString = Console.ReadLine();
                inputString.Trim();

                if (inputString == "END")
                {
                    break;
                }

                if (i%2 == 1)
                {
                    foreach (var ch in inputString)
                    {
                        if (ch != '0')
                        {
                            oddTotalProduct *= (ch - '0');
                        }
                    }
                    if (i <= 10)
                    {
                        result *= oddTotalProduct;
                    }
                    else
                    {
                        result2Modified = true;
                        resultGreaterThanTen *= oddTotalProduct;
                    }
                }
                i++;
            }
            Console.WriteLine(result);
            if (result2Modified)
            {
                Console.WriteLine(resultGreaterThanTen);
            }
        }
    }
}