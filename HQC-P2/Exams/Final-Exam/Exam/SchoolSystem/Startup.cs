namespace SchoolSystem
{
    using System.Collections.Generic;

    using Contracts;

    using Core;
    using Core.Commands;

    internal class Startup
    {
        private static void Main()
        {
            var consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();
            var students = new Dictionary<int, IStudent>();
            var teachers = new Dictionary<int, ITeacher>();
            var commandFactory = new CommandFactory();
            var engine = new SchoolSystemEngine(consoleReader, consoleWriter, teachers, students, commandFactory);

            engine.Start();
        }
    }
}
