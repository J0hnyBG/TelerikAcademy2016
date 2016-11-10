namespace SuperheroesUniverse.Data.Common
{
    using System.Linq;

    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> GetAll { get; }

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}