namespace SchoolSystem.Models.Const
{
    internal class Constants
    {
        internal const string InvalidLengthErrorMessage = "{0} must be between {1} and {2} characters long!";
        internal const string StringContainsInvalidCharsErrorMessage = "{0} contains invalid characters!";
        internal const string NullObjectErrorMessage = "{0} doesnt exist!";
        internal const string OutOfRangeErrorMessage = "{0} must be between {1} and {2}!";

        internal const int MinNameLength = 2;
        internal const int MaxNameLength = 31;
    }
}
