using System;

namespace _01_TRES4Numbers
{
    class Tres4
    {
        private static readonly string[] BaseDigitsArray =
{
            "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON"
        };

        static void Main()
        {
            ulong inputNumber = ulong.Parse(Console.ReadLine());

            Console.WriteLine(ConvertToBase(inputNumber, (uint)BaseDigitsArray.Length));
        }


        private static string ConvertToBase(ulong value, uint targetBase)
        {
            var result = string.Empty;

            do
            {
                result = BaseDigitsArray[value % targetBase] + result;
                value = value / targetBase;
            } while ( value != 0 );

            return result;
        }
    }
}
