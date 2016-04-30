using System;

namespace _05_Conductors
{
    class Program
    {
        static void Main(string[] args)
        {
            int pattern = int.Parse(Console.ReadLine());
            string patternString = Convert.ToString(pattern, 2);
            char[] array2 = patternString.ToCharArray();
            Array.Reverse(array2);
            patternString = new string(array2);

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                string inputString = Convert.ToString(inputNumber, 2);
                char[] array = inputString.ToCharArray();
                Array.Reverse(array);
                string result = new string(array);

                result = result.Replace(patternString, new string('0', patternString.Length));

                array = result.ToCharArray();

                Array.Reverse(array);
                result = new string(array);

                int output = Convert.ToInt32(result, 2);
                Console.WriteLine(output);
            }
        }
    }
}
