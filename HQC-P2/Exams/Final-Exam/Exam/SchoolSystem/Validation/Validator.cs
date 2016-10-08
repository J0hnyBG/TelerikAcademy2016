namespace SchoolSystem.Validation
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides methods for data validation.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Asserts whether a given string length fall within a specified range.
        /// </summary>
        /// <param name="str">The string to assert.</param>
        /// <param name="min">The start of the range.</param>
        /// <param name="max">The end of the range.</param>
        /// <returns>True if the string falls within the range, false otherwise.</returns>
        public static bool IsStringLengthValid(string str, int min, int max)
        {
            if (str.Length < min || str.Length > max)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Asserts whether a string contains only Latin letters.
        /// </summary>
        /// <param name="str">The string to assert.</param>
        /// <returns>True when all characters are Latin letters, false otherwise.</returns>
        public static bool AreAllStringCharsLatin(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }
    }
}
