using System;
using System.Linq;

namespace _04_RelevanceIndex
{
    class Startup
    {
        private static string[] splitChars = {" ", ",", ".", "(", ")", ";", "-", "!", "?"};
        static void Main()
        {
            string searchWord = Console.ReadLine().ToLower();

            int n = int.Parse(Console.ReadLine());

            string[] paragraphs = new string[n];
            int[] searchWordCount = new int[n];

            for (int i = 0; i < n; i++)
            {
                paragraphs[i] = Console.ReadLine();
                
                var words = paragraphs[i].Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].ToLower() == searchWord)
                    {
                        searchWordCount[i]++;
                        words[j] = words[j].ToUpper();
                    }
                }
                paragraphs[i] = string.Join(" ", words);
            }

            for (int i = 0; i < n; i++)
            {
                int maxValue = searchWordCount.Max();
                int maxIndex = Array.IndexOf(searchWordCount, maxValue);
                Console.WriteLine(paragraphs[maxIndex]);

                searchWordCount[maxIndex] = int.MinValue;
            }
        }
    }
}
