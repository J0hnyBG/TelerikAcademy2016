using System;

using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Repositories.Contracts;

namespace SchoolSystem.Framework.Core
{
    public class Engine : ISchoolSystemEngine
    {
        private const string TerminationCommand = "End";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;
        private readonly ISchoolSystemData data;

        public Engine(
            IReader readerProvider,
            IWriter writerProvider,
            IParser parserProvider,
            ISchoolSystemData data)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException($"Reader {NullProvidersExceptionMessage}");
            }

            if (writerProvider == null)
            {
                throw new ArgumentNullException($"Writer {NullProvidersExceptionMessage}");
            }

            if (parserProvider == null)
            {
                throw new ArgumentNullException($"Parser {NullProvidersExceptionMessage}");
            }

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            this.reader = readerProvider;
            this.writer = writerProvider;
            this.parser = parserProvider;
            this.data = data;
        }

        public ISchoolSystemData Data { get { return this.data; } }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters, this.Data);
            this.writer.WriteLine(executionResult);
        }
    }
}
