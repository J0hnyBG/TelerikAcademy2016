using System.Linq;

namespace _02_Employees.Data.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> AllEmployees();

        Employee GetEmployeeById(int id);
    }
}