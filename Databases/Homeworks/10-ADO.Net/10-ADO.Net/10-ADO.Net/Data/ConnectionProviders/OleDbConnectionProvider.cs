namespace _10_ADO.Net.Data.ConnectionProviders
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    using Contracts;

    public class OleDbConnectionProvider : IConnectionProvider
    {
        public IDbConnection GetConnection(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var connection = new OleDbConnection(connectionString);

            return connection;
        }
    }
}
