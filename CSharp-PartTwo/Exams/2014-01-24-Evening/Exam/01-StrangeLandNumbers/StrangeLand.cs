using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_StrangeLandNumbers
{
    class StrangeLand
    {
        private static readonly string[] BaseDigitsArray =
        {
            "f",
            "bIN",
            "oBJEC",
            "mNTRAVL",
            "lPVKNQ",
            "pNWE",
            "hT",
        };
        static void Main()
        {
            string strangeNumber = Console.ReadLine();

            Console.WriteLine(GetNumberInDecimal(strangeNumber, 7));


        }

        private static ulong GetNumberInDecimal(string input, uint startingBase)
        {
            var start = 0;
            var index = 0;
            var listOfNumbers = new List<string>();
            while ( start < input.Count() )
            {

                for ( int i = 0; i < BaseDigitsArray.Count(); i++ )
                {
                    index = input.IndexOf(BaseDigitsArray[i], start);
                    if ( index == start )
                    {
                        listOfNumbers.Add(BaseDigitsArray[i]);
                        start = index + BaseDigitsArray[i].Length;
                        break;
                    }
                }

                if ( index > start )
                {
                    start++;
                }

                if ( index >= input.Count() )
                {
                    break;
                }
            }
            ulong result = 0;
            foreach ( var digit in listOfNumbers )
            {
                result = (uint)Array.IndexOf(BaseDigitsArray, digit) + result * startingBase;
            }
            return result;
        }
    }
}
