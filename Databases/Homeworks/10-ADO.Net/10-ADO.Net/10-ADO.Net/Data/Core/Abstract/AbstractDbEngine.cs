namespace _10_ADO.Net.Data.Core.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using CommandProviders.Contracts;

    using ConnectionProviders.Contracts;

    public class AbstractDbEngine
    {
        private readonly ICommandProvider _commandProvider;
        private readonly IConnectionProvider _connectionProvider;
        private readonly string _connectionString;
        private IDbConnection _connection;

        protected AbstractDbEngine(string connectionString,
                                   ICommandProvider cmdProvider,
                                   IConnectionProvider connectionProvider)
        {
            if (cmdProvider == null)
            {
                throw new ArgumentNullException(nameof(cmdProvider));
            }

            if (connectionProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionProvider));
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            this._commandProvider = cmdProvider;
            this._connectionProvider = connectionProvider;
            this._connectionString = connectionString;
        }

        protected IDbConnection Connection => this._connection;

        protected IList<TModel> ParseDataReader<TModel>(IDataReader dataReader)
            where TModel : new()
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException(nameof(dataReader));
            }

            var result = new List<TModel>();
            var properties = typeof(TModel).GetProperties();

            while (dataReader.Read())
            {
                var item = new TModel();
                foreach (var property in properties)
                {
                    var propertyName = property.Name;
                    var propertyValue = dataReader[propertyName];
                    if (propertyValue == DBNull.Value)
                    {
                        continue;
                    }

                    property.SetValue(item, propertyValue);
                }

                result.Add(item);
            }

            return result;
        }

        protected IDbCommand GetCommand(string query, IDictionary<string, object> parameters = null)
        {
            var command = this._commandProvider.CreateDbCommand(query, parameters);
            this.AssignOpenConnection(command);
            return command;
        }

        private void AssignOpenConnection(IDbCommand command)
        {
            this._connection = this._connectionProvider.GetConnection(this._connectionString);
            this._connection.Open();
            command.Connection = this._connection;
        }
    }
}
