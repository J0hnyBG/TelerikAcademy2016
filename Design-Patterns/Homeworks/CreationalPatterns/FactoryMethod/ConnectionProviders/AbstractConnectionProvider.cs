namespace FactoryMethod.ConnectionProviders
{
    using System.Data;

    public abstract class AbstractConnectionProvider
    {
        public abstract IDbConnection GetConnection();
    }
}
