namespace Company.DataGeneration.DataGenerators.Contracts
{
    public interface IDataGenerator
    {
        void Generate(CompanyEntities db, IRandomGenerator random, int count);
    }
}
