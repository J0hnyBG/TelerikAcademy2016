namespace FactoryMethod
{
    using System;
    using ConnectionProviders;

    internal class Startup
    {
        private static void Main()
        {
            var providers = new AbstractConnectionProvider[2];
            providers[0] = new SqlConnectionProvider();
            providers[1] = new MySqlConnectionProvider();

            foreach (var provider in providers)
            {
                var connection = provider.GetConnection();
                Console.WriteLine($"Created a {connection.GetType().Name}.");
            }
        }
    }
}
