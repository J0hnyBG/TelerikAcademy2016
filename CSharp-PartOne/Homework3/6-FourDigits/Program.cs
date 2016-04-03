using System;

namespace _6_FourDigits
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += (int)char.GetNumericValue(input[i]); 
            }
            string reversed = SwitchCharacters(input, 0, input.Length - 1);
            reversed = SwitchCharacters(reversed, 1, 2);
            string exchangedLast = SwitchCharacters(input, 1, 2);
            string switchedTwo = SwitchCharacters(input, 0, 3);
            switchedTwo = SwitchCharacters(switchedTwo, 1, 3);
            switchedTwo = SwitchCharacters(switchedTwo, 2, 3);

            Console.WriteLine(sum);
            Console.WriteLine(reversed);
            Console.WriteLine(switchedTwo);
            Console.WriteLine(exchangedLast);
            

        }
        static string SwitchCharacters(string s, int p1, int p2)
        {
            char[] array = s.ToCharArray();
            char temp = array[p1];
            array[p1] = array[p2];
            array[p2] = temp;
            return new string(array);
        }
    }
}
