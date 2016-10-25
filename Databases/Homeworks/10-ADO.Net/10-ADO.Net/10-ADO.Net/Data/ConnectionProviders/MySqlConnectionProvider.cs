namespace _10_ADO.Net.Data.ConnectionProviders
{
    using System;
    using System.Data;

    using Contracts;

    using MySql.Data.MySqlClient;

    public class MySqlConnectionProvider : IConnectionProvider
    {
        public IDbConnection GetConnection(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}
