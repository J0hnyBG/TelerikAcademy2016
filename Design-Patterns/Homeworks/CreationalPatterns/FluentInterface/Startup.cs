namespace FluentInterface
{
    using Data;

    internal class Startup
    {
        private const string ConnectionString = "Server=.; database=Northwind; Integrated Security=true";
        private const string SqlCommand = "INSERT INTO Categories VALUES('Beverages');";

        private static void Main()
        {
            var db = new MsSqlDbEngine();

            db.Connect(ConnectionString)
                .ExecuteNonQuery(SqlCommand)
                .ExecuteNonQuery(SqlCommand);
        }
    }
}
