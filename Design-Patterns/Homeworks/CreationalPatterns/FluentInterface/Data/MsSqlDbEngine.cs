namespace FluentInterface.Data
{
    using System;

    public class MsSqlDbEngine
    {
        public MsSqlDbEngine Connect(string connectionString)
        {
            Console.WriteLine($"Connected to '{connectionString}'.");
            return this;
        }

        public MsSqlDbEngine ExecuteNonQuery(string command)
        {
            Console.WriteLine($"Executed '{command}'.");
            return this;
        }
    }
}
