using System;

namespace _23_SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main()
        {
            var inputStr = Console.ReadLine();
            var repeatCount = 0;

            for (int index = 1; index < inputStr.Length; index++)
            {
                if (inputStr[index] == inputStr[index - 1])
                {
                    repeatCount++;
                }
                else
                {
                    if (repeatCount > 0)
                    {
                        inputStr = inputStr.Remove(index - repeatCount, repeatCount);
                        index = index - repeatCount - 0;
                        repeatCount = 0;
                    }
                }

                if (index != inputStr.Length - 1) continue;

                inputStr = inputStr.Remove(index - repeatCount, repeatCount);
                index = index - repeatCount - 0;
                repeatCount = 0;
            }

            Console.WriteLine(inputStr);
        }
    }
}
