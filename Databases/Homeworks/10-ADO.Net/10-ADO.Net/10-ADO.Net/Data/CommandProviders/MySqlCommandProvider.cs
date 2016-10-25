namespace _10_ADO.Net.Data.CommandProviders
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using Contracts;

    using MySql.Data.MySqlClient;

    public class MySqlCommandProvider : ICommandProvider
    {
        public IDbCommand CreateDbCommand(string commandString, IDictionary<string, object> parameters = null)
        {
            if (string.IsNullOrEmpty(commandString))
            {
                throw new ArgumentNullException(nameof(commandString));
            }

            var command = new MySqlCommand(commandString);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            return command;
        }
    }
}
