namespace _10_ADO.Net.Data.CommandProviders
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;

    using Abstract;

    public class OleDbCommandProvider : AbstractCommandProvider
    {
        public override IDbCommand CreateDbCommand(string query, IDictionary<string, object> parameters = null)
        {
            this.ValidateCommandString(query);
            var command = new OleDbCommand(query);
            this.AddParameters(command, parameters);

            return command;
        }
    }
}
