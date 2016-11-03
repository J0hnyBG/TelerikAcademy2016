namespace Dealership.Engine.ConsoleProviders
{
    public interface IInputOutputProvider
    {
        string ReadInput();

        void WriteOutput(string value);
    }
}