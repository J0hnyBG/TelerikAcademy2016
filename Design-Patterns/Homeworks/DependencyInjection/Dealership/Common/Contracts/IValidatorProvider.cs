namespace Dealership.Common.Contracts
{
    public interface IValidatorProvider
    {
        void ValidateIntRange(int value, int min, int max, string message);

        void ValidateDecimalRange(decimal value, decimal min, decimal max, string message);

        void ValidateNull(object value, string message);

        void ValidateSymbols(string value, string pattern, string message);
    }
}
