using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace _02_Employees.Data.Contracts
{
    public interface INorthwindEntities
    {
        IDbSet<Employee> Employees { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}