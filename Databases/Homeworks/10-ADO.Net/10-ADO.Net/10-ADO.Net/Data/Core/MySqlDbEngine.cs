namespace _10_ADO.Net.Data.Core
{
    using System;
    using System.Collections.Generic;

    using Abstract;

    using CommandProviders;

    using ConnectionProviders;

    using Models;

    public class MySqlDbEngine : AbstractDbEngine
    {
        public MySqlDbEngine(string connectionString)
            : base(connectionString, new MySqlCommandProvider(), new MySqlConnectionProvider())
        {
        }

        /// <summary>
        ///     Returns all results from the books table.
        /// </summary>
        public IList<Book> ListAllBooks()
        {
            using (this.Connection)
            {
                var command = this.GetCommand("SELECT * FROM books");
                var reader = command.ExecuteReader();
                var result = this.ParseDataReader<Book>(reader);
                return result;
            }
        }

        /// <summary>
        ///     Returns all results from the books table containing a specified name.
        /// </summary>
        public IList<Book> SearchForBooksByName(string name)
        {
            using (this.Connection)
            {
                var parameters = new Dictionary<string, object>
                                 {
                                     { "@Name", "%" + name + "%" }
                                 };

                var command = this.GetCommand("SELECT * FROM books WHERE Name LIKE @Name;", parameters);
                var reader = command.ExecuteReader();
                var result = this.ParseDataReader<Book>(reader);
                return result;
            }
        }

        /// <summary>
        ///     Adds a new book to the books table.
        /// </summary>
        public int AddBook(string name, string author, string isbn, DateTime publishDate)
        {
            using (this.Connection)
            {
                var parameters = new Dictionary<string, object>
                                 {
                                     { "@Name", name },
                                     { "@Author", author },
                                     { "@ISBN", isbn },
                                     { "@PublishDate", publishDate }
                                 };

                var command =
                    this.GetCommand(
                                    @"INSERT INTO books (Name, Author, ISBN, PublishDate) VALUES(@Name, @Author, @ISBN, @PublishDate);",
                                    parameters);
                var result = command.ExecuteNonQuery();
                return result;
            }
        }
    }
}
