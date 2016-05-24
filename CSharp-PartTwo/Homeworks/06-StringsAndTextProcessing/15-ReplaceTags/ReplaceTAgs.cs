using System;
using System.Text.RegularExpressions;

namespace _15_ReplaceTags
{
    internal class ReplaceTAgs
    {
        private const string _pattern = "<a[^>]*? href=\"(?<url>[^\"]+)\"[^>]*?>(?<text>.*?)</a>";
        private const RegexOptions _regexOptions = RegexOptions.Singleline;

        //TODO: all
        private static void Main()
        {
            var inputString = Console.ReadLine();
            MatchEvaluator mEvaluator = ReplaceTags;

            inputString = Regex.Replace(inputString, _pattern, mEvaluator, _regexOptions);
            Console.WriteLine(inputString);
        }

        public static string ReplaceTags(Match m)
        {
            return string.Format("[{0}]({1})", m.Groups["text"], m.Groups["url"]);
        }
    }
}