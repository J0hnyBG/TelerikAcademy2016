

namespace FastAndFurious.ConsoleApplication.Common
{
    using System;

    public static class Validator
    {
        public static void CheckIfObjectsIsNull(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
