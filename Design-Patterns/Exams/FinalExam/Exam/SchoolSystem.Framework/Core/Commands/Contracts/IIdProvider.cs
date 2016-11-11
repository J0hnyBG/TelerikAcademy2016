namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    public interface IIdProvider
    {
        int Current { get; }

        int GetNext();
    }
}
