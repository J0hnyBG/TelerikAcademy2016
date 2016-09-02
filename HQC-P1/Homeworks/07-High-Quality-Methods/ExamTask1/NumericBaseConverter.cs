namespace ExamTask1
{
    using System;
    using System.Numerics;

    internal static class NumericBaseConverter
    {
        private static readonly char[] NumericDigitArray = "0123456789".ToCharArray();

        private static readonly char[] LetterDigitArray = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static readonly char[] HexDigitArray = "0123456789abcdef".ToCharArray();

        /// <summary>
        /// Converts a number in an arbitraty base to a decimal value.
        /// </summary>
        /// <param name="input">A string with the number to convert.</param>
        /// <param name="startingBase">The base the input number is in.</param>
        /// <returns></returns>
        public static BigInteger FromBaseToDecimal(string input, uint startingBase)
        {
            char[] digitsArray = GetDigitArray(startingBase);

            BigInteger result = 0;

            input = input.ToLower();
            foreach (var digit in input)
            {
                result = (uint)Array.IndexOf(digitsArray, digit) + result * startingBase;
            }

            return result;
        }

        /// <summary>
        /// Converts a decimal number to an arbitrary base.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <param name="targetBase">The base to convert the number to.</param>
        /// <returns>The converted number</returns>
        public static string ConvertToBase(BigInteger value, uint targetBase)
        {
            var result = string.Empty;

            char[] digitsArray = GetDigitArray(targetBase);

            do
            {
                result = digitsArray[(int)(value % targetBase)] + result;
                value = value / targetBase;
            } while (value != 0);

            return result;
        }

        /// <summary>
        /// Returns a set of chars for a target base.
        /// </summary>
        /// <param name="radix">The target numerical system.</param>
        /// <returns>A set of chars for a target base.</returns>
        private static char[] GetDigitArray(uint radix)
        {
            switch (radix)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return NumericDigitArray;
                case 16:
                    return HexDigitArray;
                case 26:
                    return LetterDigitArray;
                default:
                    throw new NotImplementedException("The conversion from base " + radix +
                                                      " has not been implemented!");
            }
        }
    }
}
