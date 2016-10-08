namespace SchoolSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    internal class SchoolSystemEngine
    {
        private const string EndCommand = "End";
        private const string CannotBeLessThanZeroErrorMessage = "{0} cannot be less than 0!";
        private const string NullOrEmptyErrorMessage = "{0} cannot be null or empty!";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandFactory commandFactory;

        public SchoolSystemEngine(IReader reader, IWriter writer, IDictionary<int, ITeacher> teachers, IDictionary<int, IStudent> students, ICommandFactory commandFactory)
        {
            this.reader = reader;
            this.commandFactory = commandFactory;
            this.writer = writer;
            Teachers = teachers;
            Students = students;
        }

        internal static IDictionary<int, ITeacher> Teachers { get; private set; }

        internal static IDictionary<int, IStudent> Students { get; private set; }

        public static void AddStudent(int id, IStudent student)
        {
            ValidatePerson(id, student, "Student");

            if (Students == null)
            {
                Students = new Dictionary<int, IStudent>();
            }

            Students.Add(id, student);
        }

        public static bool RemoveStudent(int id)
        {
            return Students.Remove(id);
        }

        public static void AddTeacher(int id, ITeacher teacher)
        {
            ValidatePerson(id, teacher, "Teacher");

            if (Teachers == null)
            {
                Teachers = new Dictionary<int, ITeacher>();
            }

            Teachers.Add(id, teacher);
        }

        public static bool RemoveTeacher(int id)
        {
            return Teachers.Remove(id);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandString = this.reader.ReadLine();
                    if (commandString == EndCommand)
                    {
                        break;
                    }

                    var commandName = commandString.Split(' ')[0];
                    var command = this.commandFactory.CreateCommand(commandName);
                    var commandParameters = commandString.Split(' ').ToList();
                    commandParameters.RemoveAt(0);
                    var commandResult = command.Execute(commandParameters);
                    this.writer.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private static void ValidatePerson(int id, IPerson person, string personTypeName)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), string.Format(CannotBeLessThanZeroErrorMessage, $"{personTypeName} id"));
            }

            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), string.Format(NullOrEmptyErrorMessage, personTypeName));
            }
        }
    }
}