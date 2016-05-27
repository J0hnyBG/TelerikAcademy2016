using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08_ExtractSentences
{
    internal class ExtractSentences
    {
        //TODO: 80/100

        private static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            string[] splitSentences = text.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
            char[] separators = text.Where(c => !char.IsLetter(c))
                .Distinct()
                .ToArray();

            foreach (var sentence in splitSentences)
            {
                string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words.Length; i++)
                {
                    if (word == words[i].Trim())
                    {
                        Console.Write(sentence.Trim() + ". ");
                        break;
                    }
                }
            }
        }

        //private static void Main()
        //{
        //    var matchWord = Console.ReadLine().ToUpper();
        //    var text = Console.ReadLine();
        //    var sentences = text.Split('.').ToArray();

        //    var separators = GetSeparators(text);

        //    var filteredSentences = new StringBuilder();

        //    foreach (var sentence in sentences)
        //    {
        //        var words = sentence.ToUpper().Split(separators).ToArray();
        //        var isMatchWord = words.Any(x => x == matchWord);

        //        if (isMatchWord)
        //        {
        //            filteredSentences.Append(sentence + ".");
        //        }
        //    }
        //    Console.WriteLine(string.Join(" ", filteredSentences));
        //}

        //private static char[] GetSeparators(string text)
        //{
        //    return text.Where(x => !char.IsLetter(x) && x != '.').Distinct().ToArray();
        //}

    }
}