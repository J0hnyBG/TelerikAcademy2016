namespace _10_ADO.Net.Data
{
    using System.Collections.Generic;

    using Abstract;

    using CommandProviders;

    using ConnectionProviders;

    using Models;

    public class OleDbEngine : AbstractDbEngine
    {
        public OleDbEngine(string connectionString)
            : base(connectionString, new OleDbCommandProvider(), new OleDbConnectionProvider())
        {
        }

        /// <summary>
        /// Inserts a row into the PersonScores table.
        /// </summary>
        public void InsertPerson(string name, int score)
        {
            using (this.Connection)
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>
                                                         {
                                                             { "@Name", name },
                                                             { "@Score", score }
                                                         };
                var command = this.GetCommand("INSERT INTO [PersonScores] (Name, Score) VALUES(@Name, @Score)",
                                              parameters);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Lists all rows form the PersonScores table.
        /// </summary>
        public IList<PersonScore> GetPersonScores()
        {
            using (this.Connection)
            {
                var command = this.GetCommand("SELECT Name, Score FROM [PersonScores]");

                var reader = command.ExecuteReader();
                var personScores = this.ParseDataReader<PersonScore>(reader);

                return personScores;
            }
        }
    }
}
