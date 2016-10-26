namespace FactoryMethod.ConnectionProviders
{
    using System.Data;
    using MySql.Data.MySqlClient;

    public class MySqlConnectionProvider : AbstractConnectionProvider
    {
        private const string ConnectionString = "Server=localhost;Database=world;Uid=root;Pwd=123456;";
        public override IDbConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
