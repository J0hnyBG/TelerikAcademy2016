﻿namespace _10_ADO.Net.Data.CommandProviders
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using Abstract;

    public class SqlCommandProvider : AbstractCommandProvider
    {
        public override IDbCommand CreateDbCommand(string query, IDictionary<string, object> parameters = null)
        {
            this.ValidateCommandString(query);
            var command = new SqlCommand(query);
            this.AddParameters(command, parameters);

            return command;
        }
    }
}
