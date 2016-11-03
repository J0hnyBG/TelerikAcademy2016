namespace Memento
{
    using System;

    using Documents;

    internal class Startup
    {
        private static void Main()
        {
            var history = new DocumentHistory();
            Document document = new Document("Content 1");
            Console.WriteLine("Original document:");
            Console.WriteLine(document.Content);

            var currentState = document.GetState();
            history.History.Push(currentState);

            document.Content = "Content 2";
            Console.WriteLine("Modified document:");
            Console.WriteLine(document.Content);

            var previousState = history.History.Pop();
            document.Undo(previousState);

            Console.WriteLine("Restored document:");
            Console.WriteLine(document.Content);
        }
    }
}
