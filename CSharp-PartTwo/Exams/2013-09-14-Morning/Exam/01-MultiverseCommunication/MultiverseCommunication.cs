using System;
using System.Collections.Generic;

namespace _01_MultiverseCommunication
{
    class MultiverseCommunication
    {
        private static readonly string[] BaseDigitsArray =
        {
            "CHU",
            "TEL",
            "OFT",
            "IVA",
            "EMY",
            "VNB",
            "POQ",
            "ERI",
            "CAD",
            "K-A",
            "IIA",
            "YLO",
            "PLA"
        };

        private static void Main()
        {
            var inputNumber = Console.ReadLine();

            var numbers = SplitInParts(inputNumber, 3);

            var numberInDecimal = GetNumberInDecimal(numbers, (uint)BaseDigitsArray.Length);
            Console.WriteLine(numberInDecimal);
        }

        private static ulong GetNumberInDecimal(IEnumerable<string> input, uint startingBase)
        {
            ulong result = 0;
            foreach (var digit in input )
            {
                result = (uint)Array.IndexOf(BaseDigitsArray, digit) + result * startingBase;
            }
            return result;
        }

        public static IEnumerable<string> SplitInParts(string s, int partLength)
        {
            if ( s == null )
                throw new ArgumentNullException("s");
            if ( partLength <= 0 )
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for ( var i = 0; i < s.Length; i += partLength )
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
    }
}