namespace Company.DataGeneration.DataGenerators.Contracts
{
    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);
    }
}
