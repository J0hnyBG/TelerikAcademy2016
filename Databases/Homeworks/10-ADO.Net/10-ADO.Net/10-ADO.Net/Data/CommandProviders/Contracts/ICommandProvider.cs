namespace _10_ADO.Net.Data.CommandProviders.Contracts
{
    using System.Collections.Generic;
    using System.Data;

    public interface ICommandProvider
    {
        IDbCommand CreateDbCommand(string query, IDictionary<string, object> parameters = null);
    }
}
