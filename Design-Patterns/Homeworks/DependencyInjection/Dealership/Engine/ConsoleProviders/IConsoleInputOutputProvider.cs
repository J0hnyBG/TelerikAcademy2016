using System;

namespace Dealership.Engine.ConsoleProviders
{
    public interface IConsoleInputOutputProvider : IInputOutputProvider
    {
        ConsoleColor BackgroundColor { get; set; }

        ConsoleColor ForegroundColor { get; set; }

        void ResetColor();
    }
}