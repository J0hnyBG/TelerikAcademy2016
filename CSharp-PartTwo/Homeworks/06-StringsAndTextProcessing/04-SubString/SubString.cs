using System;

namespace _04_SubString
{
    class SubString
    {
        static void Main()
        {
            var pattern = Console.ReadLine().ToLower();
            var inputString = Console.ReadLine().ToLower();

            int index = inputString.IndexOf(pattern);
            int count = 0;
            while (index >= 0)
            {
                count++;
                index = inputString.IndexOf(pattern, index + 1);
            }
            Console.WriteLine(count);
        }

    }
}
