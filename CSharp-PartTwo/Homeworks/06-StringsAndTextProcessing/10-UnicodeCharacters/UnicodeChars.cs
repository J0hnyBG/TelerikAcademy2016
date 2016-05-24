using System;
using System.Text;

namespace _10_UnicodeCharacters
{
    class UnicodeChars
    {
        static void Main()
        {
            var inputStr = Console.ReadLine();
            inputStr = inputStr.Replace("\\", "");

            for (int i = 0; i < inputStr.Length; i++ )
            {
                Console.Write("\\u" + ((int)inputStr[i]).ToString("X4"));
            }

        }
    }
}