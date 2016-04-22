using System;

namespace _02_SecretsOfNumbers
{
    internal class SecretsofNumbers
    {
        private static void Main()
        {
            string n = Console.ReadLine();
            char[] nArray = n.ToCharArray();
            Array.Reverse(nArray);

            int specialSum = 0;
            for (int i = 1; i <= nArray.Length; i++)
            {
                if(nArray[i - 1] == '-') continue;
                if (i % 2 == 0)
                {
                    specialSum += (nArray[i - 1] - '0') * (nArray[i - 1] - '0') * i;
                }
                else
                {
                    specialSum += (nArray[i - 1] - '0') * i * i;
                }
            }
            Console.WriteLine(specialSum);
            var specialString = specialSum.ToString();

            if (specialString[specialString.Length - 1] == '0')
            {
                Console.WriteLine(n + " has no secret alpha-sequence");
            }
            else
            {
                int r = specialSum % 26;
                for (int i = 0; i < specialString[specialString.Length - 1] - '0'; i++)
                {
                    if (r + 65 + i > 90)
                    {
                        r -= 26;
                    }

                    char letter = Convert.ToChar(r + 65 + i);
                    Console.Write(letter);
                }
            }
            Console.WriteLine();
        }
    }
}