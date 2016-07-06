using System;

namespace FurnitureManufacturer.Models.Common
{
    public static class Validator
    {
        public static void CheckIfStringLengthIsValid(string value, string errorMessage = null, int minLength = 0, int maxLength = int.MaxValue)
        {
            if (value.Length < minLength || value.Length > maxLength)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void CheckIfStringIsExactLength(string value, int targetLength, string errorMessage = null)
        {
            if (value.Length !=  targetLength)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void CheckIfStringIsNullOrEmpty(string value, string errorMessage = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException(errorMessage);
            }
        }
        public static void CheckIfNumberIsLessThanOrEqualToZero(decimal value, string errorMessage = null)
        {
            if ( value <= 0 )
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void CheckIfStringIsNumbersOnly(string value, string errorMessage = null)
        {
            foreach (var ch in value)
            {
                if (ch < '0' || ch > '9')
                {
                    throw new ArgumentException(errorMessage);
                }
            }
        }

        public static void CheckIfNull(object obj, string message = null)
        {
            if ( obj == null )
            {
                throw new NullReferenceException(message);
            }
        }
    }
}