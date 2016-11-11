namespace SchoolSystem.Framework.Core.Contracts
{
    public interface IKeyedRepository<T>
    {
        T GetById(int id);

        void Add(int itemId, T item);

        void Remove(int itemId);
    }
}
