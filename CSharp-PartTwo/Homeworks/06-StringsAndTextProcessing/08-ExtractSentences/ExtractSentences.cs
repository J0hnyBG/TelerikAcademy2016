using System;
using System.Linq;
using System.Text;

namespace _08_ExtractSentences
{
    internal class ExtractSentences
    {
        //TODO: 90/100
        private static void Main()
        {
            var matchWord = Console.ReadLine().ToUpper();
            var text = Console.ReadLine();
            var sentences = text.Split('.').ToArray();

            var separators = GetSeparators(text);

            var filteredSentences = new StringBuilder();

            for (var i = 0; i < sentences.Length; i++)
            {
                var words = sentences[i].ToUpper().Split(separators).ToArray();
                var isMatchWord = words.Any(x => x == matchWord);

                if (isMatchWord)
                {
                    filteredSentences.Append(sentences[i] + ".");
                }
            }
            Console.WriteLine(string.Join(" ", filteredSentences));
        }

        private static char[] GetSeparators(string text)
        {
            return text.Where(x => !char.IsLetter(x) && x != '.').Distinct().ToArray();
        }
    }
}