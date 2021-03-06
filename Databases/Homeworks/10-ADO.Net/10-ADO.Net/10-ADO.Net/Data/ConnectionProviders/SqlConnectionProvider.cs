﻿namespace _10_ADO.Net.Data.ConnectionProviders
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    using Contracts;

    public class SqlConnectionProvider: IConnectionProvider
    {
        public IDbConnection GetConnection(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
