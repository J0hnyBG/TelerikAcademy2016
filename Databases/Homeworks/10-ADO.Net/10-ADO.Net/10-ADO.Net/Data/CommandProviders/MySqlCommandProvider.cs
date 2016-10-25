namespace _10_ADO.Net.Data.CommandProviders
{
    using System.Collections.Generic;
    using System.Data;

    using Abstract;

    using MySql.Data.MySqlClient;

    public class MySqlCommandProvider : AbstractCommandProvider
    {
        public override IDbCommand CreateDbCommand(string commandString, IDictionary<string, object> parameters = null)
        {
            this.ValidateCommandString(commandString);
            var command = new MySqlCommand(commandString);
            this.AddParameters(command, parameters);

            return command;
        }
    }
}
