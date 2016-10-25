namespace _10_ADO.Net.Data.ConnectionProviders.Contracts
{
    using System.Data;

    public interface IConnectionProvider
    {
        IDbConnection GetConnection(string connectionString);
    }
}
