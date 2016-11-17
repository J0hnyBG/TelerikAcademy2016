namespace SchoolSystem.Framework.Core.Repositories.Contracts
{
    public interface IRepository<T>
    {
        T GetById(int id);

        int Add(T item);

        void Remove(int itemId);
    }
}
