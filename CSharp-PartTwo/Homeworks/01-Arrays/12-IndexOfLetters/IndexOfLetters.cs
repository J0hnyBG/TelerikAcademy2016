using System;

namespace _12_IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main()
        {
            string inputString = Console.ReadLine();
            char[] arrayOfLetters = new char[26];

            for (int i = 0; i < 26; i++)
            {
                arrayOfLetters[i] = (char)('a' + i);
            }

            for (int i = 0; i < inputString.Length; i++)
            {
                Console.WriteLine(Array.IndexOf(arrayOfLetters, inputString[i]));
            }

        }
    }
}
