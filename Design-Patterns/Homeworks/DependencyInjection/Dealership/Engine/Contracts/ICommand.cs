using System.Collections.Generic;

namespace Dealership.Engine.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        List<string> Parameters { get; }
    }
}
