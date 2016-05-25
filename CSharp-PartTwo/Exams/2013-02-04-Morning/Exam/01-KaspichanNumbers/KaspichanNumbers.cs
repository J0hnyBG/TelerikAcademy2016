using System;

namespace _01_KaspichanNumbers
{
    class KaspichanNumbers
    {
        private static string[] _baseDigitsArray;

        private static void Main()
        {
            Initialize();
            var inputNumber = ulong.Parse(Console.ReadLine());

            Console.WriteLine(ConvertToBase(inputNumber, 256));
        }

        private static string ConvertToBase(ulong value, uint targetBase)
        {
            var result = string.Empty;

            do
            {
                result = _baseDigitsArray[value % targetBase] + result;
                value = value / targetBase;
            } while ( value != 0 );

            return result;
        }

        private static void Initialize()
        {
            _baseDigitsArray = new string[256];
            char firstChar = (char)('a' - 1);
            var count = 0;
            for (int j = 0; j <= 9; j++)
            {
                for ( int i = 0; i < 26; i++ )
                {
                    count++;
                    if (j == 0)
                    {
                        _baseDigitsArray[i] = (((char)( 'A' + i ) )).ToString();
                    }
                    else
                    {
                        _baseDigitsArray[i + j*26] = firstChar + (((char) ('A' + i))).ToString();
                    }
                    if (count == 256)
                    {
                        break;
                    }
                    
                }
                firstChar++;
            }
        }
    }
}
