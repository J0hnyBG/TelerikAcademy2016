namespace FactoryMethod.ConnectionProviders
{
    using System.Data;
    using System.Data.SqlClient;

    public class SqlConnectionProvider : AbstractConnectionProvider
    {
        private const string ConnectionString = "Server=.; database=Northwind; Integrated Security=true";
        public override IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
