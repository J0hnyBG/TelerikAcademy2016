namespace SchoolSystem.Framework.Core.Contracts
{
    public interface IKeyedRepository<T>
    {
        int NextId { get; }

        T GetById(int id);

        void Add(T item);

        void Remove(int itemId);
    }
}
