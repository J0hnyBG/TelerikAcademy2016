using System;

namespace _05_ParseTags
{
    internal class ParseTags
    {
        private static string _inputString = string.Empty;
        private const string _openingTag = "<uppercase>";
        private const string _closingTag = "</uppercase>";

        private static void Main()
        {
            _inputString = Console.ReadLine();

            int startIndex = GetIndexOfInner(_inputString, _openingTag) + _openingTag.Length;
            int endIndex = GetIndexOfInner(_inputString, _closingTag);

        }

        private static int GetIndexOfInner(string text, string tag)
        {
            int index = text.IndexOf(tag);
            return index;
        }
    }
}