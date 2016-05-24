using System;

namespace _05_ParseTags
{
    internal class ParseTags
    {
        private static string _inputString = string.Empty;
        private const string _openingTag = "<upcase>";
        private const string _closingTag = "</upcase>";

        private static void Main()
        {
            _inputString = Console.ReadLine();

            var startIndex = GetIndexOf(_openingTag);
            var endIndex = GetIndexOf(_closingTag);
            while (startIndex >= 0 || endIndex >= 0)
            {
                var upperCaseStr = _inputString.Substring(startIndex + _openingTag.Length, endIndex - startIndex - _openingTag.Length).ToUpper();
                _inputString = _inputString.Remove(startIndex, endIndex - startIndex + _closingTag.Length);

                _inputString = _inputString.Insert(startIndex, upperCaseStr);

                startIndex = GetIndexOf(_openingTag);
                endIndex = GetIndexOf(_closingTag);
            }

            Console.WriteLine(_inputString);
        }

        private static int GetIndexOf(string tag)
        {
            return _inputString.IndexOf(tag);
        }
    }
}