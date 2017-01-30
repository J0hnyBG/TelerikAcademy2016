using _02_Employees.Data.Contracts;
using _02_Employees.Data.Repositories.Contracts;

namespace _02_Employees.Data.Repositories.Factories
{
    public interface IRepositoryFactory
    {
        IEmployeeRepository CreateEmployeeRepository(INorthwindEntities context);
    }
}