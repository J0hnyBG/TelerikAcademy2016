using Dealership.Common.Contracts;

namespace Dealership.Common
{
    public class ValidatorProvider : IValidatorProvider
    {
        public void ValidateIntRange(int value, int min, int max, string message)
        {
            Validator.ValidateIntRange(value, min, max, message);
        }

        public void ValidateDecimalRange(decimal value, decimal min, decimal max, string message)
        {
            Validator.ValidateDecimalRange(value, min, max, message);
        }

        public void ValidateNull(object value, string message)
        {
            Validator.ValidateNull(value, message);
        }

        public void ValidateSymbols(string value, string pattern, string message)
        {
            Validator.ValidateSymbols(value, pattern, message);
        }
    }
}
