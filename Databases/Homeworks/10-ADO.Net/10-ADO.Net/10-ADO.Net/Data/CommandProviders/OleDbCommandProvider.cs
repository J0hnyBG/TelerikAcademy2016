namespace _10_ADO.Net.Data.CommandProviders
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;

    using Contracts;

    public class OleDbCommandProvider : ICommandProvider
    {
        public IDbCommand CreateDbCommand(string query, IDictionary<string, object> parameters = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            var command = new OleDbCommand(query);

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }
            }

            return command;
        }
    }
}
