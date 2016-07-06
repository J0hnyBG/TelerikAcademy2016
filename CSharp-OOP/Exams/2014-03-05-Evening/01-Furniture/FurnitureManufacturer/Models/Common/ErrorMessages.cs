namespace FurnitureManufacturer.Models.Common
{
    public static class ErrorMessages
    {
        public const string InvalidStringLengthErrorMessage = "{0} can not be less than {1} symbols long!";
        public const string NullorEmptyErrorMessage = "{0} can not be empty or null!";
        public const string NumberLessThanOrEqualToErrorMessage = "{0} can not be less than or equal to {1}!";
        public const string StringNotOnlyNumericsErrorMessage = "{0} contains symbols other than numbers!";
        public const string StringNotExactLength = "{0} must be exactly {1} characters long!";

    }
}
