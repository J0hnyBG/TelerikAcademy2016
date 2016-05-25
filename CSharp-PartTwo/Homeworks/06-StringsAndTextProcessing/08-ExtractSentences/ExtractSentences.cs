using System;
using System.Linq;
using System.Text;

namespace _08_ExtractSentences
{
    internal class ExtractSentences
    {
        //TODO: 20/100
        private static void Main()
        {
            var matchWord = Console.ReadLine().ToUpper();
            var text = Console.ReadLine();
            var sentences = text.Split('.').ToArray();

            var separators = GetSeparators(text);

            var filteredSentences = new StringBuilder();

            foreach (var sentence in sentences)
            {
                var words = sentence.ToUpper().Split(separators).ToArray();
                var isMatchWord = words.Any(x => x == matchWord);

                if (isMatchWord)
                {
                    filteredSentences.Append(sentence + ".");
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