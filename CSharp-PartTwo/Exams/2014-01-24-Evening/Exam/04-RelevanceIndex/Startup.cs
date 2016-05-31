using System;
using System.Linq;

namespace _04_RelevanceIndex
{
    internal class Startup
    {
        private static readonly string[] SplitChars = {" ", ",", ".", "(", ")", ";", "-", "!", "?"};

        private static void Main()
        {
            var searchWord = Console.ReadLine().ToLower();

            var n = int.Parse(Console.ReadLine());

            var paragraphs = new string[n];
            var searchWordCount = new int[n];

            for (var i = 0; i < n; i++)
            {
                paragraphs[i] = Console.ReadLine();

                var words = paragraphs[i].Split(SplitChars, StringSplitOptions.RemoveEmptyEntries);
                for (var j = 0; j < words.Length; j++)
                {
                    if (words[j].ToLower() != searchWord)
                        continue;

                    searchWordCount[i]++;
                    words[j] = words[j].ToUpper();
                }
                paragraphs[i] = string.Join(" ", words);
            }

            for (var i = 0; i < n; i++)
            {
                var maxValue = searchWordCount.Max();
                var maxIndex = Array.IndexOf(searchWordCount, maxValue);
                Console.WriteLine(paragraphs[maxIndex]);

                searchWordCount[maxIndex] = int.MinValue;
            }
        }
    }
}