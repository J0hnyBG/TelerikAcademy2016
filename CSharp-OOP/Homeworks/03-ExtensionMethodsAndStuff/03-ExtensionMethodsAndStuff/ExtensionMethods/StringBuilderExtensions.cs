namespace _03_ExtensionMethodsAndStuff.ExtensionMethods
{   //Problem 1
    using System;
    using System.Text;
    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > sb.Length)
            {
                throw new ArgumentOutOfRangeException("The specified startIndex cannot be larger than the length of the StringBuilder or smaller than zero!");
            }
            if (length < 0 )
            {
                throw new ArgumentOutOfRangeException("The specified length cannot be less than zero!");
            }
            if (length + startIndex > sb.Length)
            {
                throw new ArgumentOutOfRangeException("StartIndex plus length is greater than the length of the StringBuilder!");
            }

            if ( sb.Length == 0 || length == 0 )
            {
                return new StringBuilder();
            }

            return new StringBuilder(sb.ToString(startIndex, length));
        }
    }
}
