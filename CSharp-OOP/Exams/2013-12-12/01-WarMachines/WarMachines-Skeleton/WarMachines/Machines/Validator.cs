namespace WarMachines.Machines
{
    using System;

    public static class Validator
    {
        public static void CheckIfStringIsNullOrEmpty(string value, string errorMsg = null)
        {
            if (string.IsNullOrEmpty(value) )
            {
                throw new ArgumentNullException(errorMsg);
            }
        }

        public static void CheckIfObjectIsNull(object value, string errorMsg = null)
        {
            if ( value == null )
            {
                throw new ArgumentNullException(errorMsg);
            }
        }

        public static void CheckIfLessThanZero(decimal value, string errorMsg = null)
        {
            if ( value < 0 )
            {
                throw new ArgumentException(errorMsg);
            }
        }
    }
}
