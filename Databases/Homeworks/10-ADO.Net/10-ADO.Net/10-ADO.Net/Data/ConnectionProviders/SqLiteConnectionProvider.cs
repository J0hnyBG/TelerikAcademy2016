namespace _10_ADO.Net.Data.ConnectionProviders
{
    using System;
    using System.Data;
    using System.Data.SQLite;

    using Contracts;

    public class SqLiteConnectionProvider : IConnectionProvider
    {
        public IDbConnection GetConnection(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var connection = new SQLiteConnection(connectionString);
            return connection;
        }
    }
}
