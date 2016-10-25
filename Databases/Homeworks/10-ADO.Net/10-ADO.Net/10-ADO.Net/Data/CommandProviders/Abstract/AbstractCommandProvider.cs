namespace _10_ADO.Net.Data.CommandProviders.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using Contracts;

    public abstract class AbstractCommandProvider : ICommandProvider
    {
        public abstract IDbCommand CreateDbCommand(string query, IDictionary<string, object> parameters = null);

        protected void ValidateCommandString(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query));
            }
        }

        protected void AddParameters(IDbCommand command, IDictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                return;
            }

            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            foreach (var parameter in parameters)
            {
                var commandParameter = command.CreateParameter();
                commandParameter.ParameterName = parameter.Key;
                commandParameter.Value = parameter.Value;
                command.Parameters.Add(commandParameter);
            }
        }
    }
}
