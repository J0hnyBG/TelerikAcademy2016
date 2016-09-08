class Writer
{
    private const int MaxCount = 6;
    private class ConsoleWriter
    {
        public void WriteBoolToConsole(bool isTrue)
        {
            string boolString = isTrue.ToString();
            Console.WriteLine(boolString);
        }
    }

    public static void WriteTrueToConsole()
    {
        ConsoleWriter consoleWriter = new ConsoleWriter();
        consoleWriter.WriteBoolToConsole(true);
    }
}