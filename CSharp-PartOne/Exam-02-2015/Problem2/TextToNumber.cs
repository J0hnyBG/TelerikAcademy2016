using System;

namespace TextToNumber
{
    class TextToNumber
    {
        static void Main()
        {
            int m = Convert.ToInt32(Console.ReadLine());
            char[] charArray = Console.ReadLine().ToCharArray();
            long result = 0;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == '@')
                {
                    Console.WriteLine(result);
                    break;
                }
                else if (char.IsDigit(charArray[i]))
                {
                    result = result * (int)char.GetNumericValue(charArray[i]);//charArray[i] - 48;
                }
                else if (char.IsLetter(charArray[i]))
                {
                    result = result + char.ToUpper(charArray[i]) - 65;
                }
                else
                {
                    result = result % m;
                }
            }
        }

    }
}
