using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_ConsoleJustification2
{
    internal class Justification
    {
        //TODO: 40/100
        private static List<string> _allWords = new List<string>();

        private static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int totalWidthOfLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] words = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                _allWords.AddRange(words);
            }
            var listOfLines = Wrap(_allWords, totalWidthOfLine);

            foreach (var line in listOfLines)
            {
                Console.WriteLine(line);
            }
        }


        public static List<string> Wrap(List<string> words, int maxLength)
        {
            var lines = new List<string>();
            var currentLine = new StringBuilder();

            foreach (var currentWord in words)
            {
                if ((currentLine.Length >= maxLength) || ((currentLine.Length + currentWord.Length) >= maxLength))
                {
                    lines.Add(PadWords(currentLine.ToString(), maxLength));
                    currentLine.Clear();
                }

                if (currentLine.Length > 0)
                {
                    currentLine.Append(" " + currentWord);
                }
                else
                {
                    currentLine.Append(currentWord);
                }
            }
            if (currentLine.Length > 0)
            {
                lines.Add(currentLine.ToString());
            }
            return lines;
        }

        public static string PadWords(string line, int maxlength)
        {
            var words = line.Split();

            var index = 0;
            if (line.Length == maxlength || words.Count() == 1)
            {
                return line;
            }
            int lineCount = words.Sum(word => word.Length);
            while (lineCount < maxlength)
            {
                words[index] += " ";
                index++;
                if (index > words.Count() - 2)
                {
                    index = 0;
                }
                lineCount = words.Sum(word => word.Length);
            }
            return words.Aggregate("", (current, word) => current + word);
        }
    }
}