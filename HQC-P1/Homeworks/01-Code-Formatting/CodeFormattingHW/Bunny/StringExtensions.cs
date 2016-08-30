namespace Bunny
{
    using System.Text;

    public static class StringExtensions
    {
        public static string SplitToSeparateWordsByUppercaseLetter(this string sequence)
        {
            const int probableStringMargin = 10;
            const char singleWhitespace = ' ';

            var probableStringSize = sequence.Length + probableStringMargin;
            var builder = new StringBuilder(probableStringSize);

            foreach (var letter in sequence)
            {
                if (char.IsUpper(letter))
                {
                    builder.Append(singleWhitespace);
                }

                builder.Append(letter);
            }

            return builder.ToString().Trim();
        }
    }
}
