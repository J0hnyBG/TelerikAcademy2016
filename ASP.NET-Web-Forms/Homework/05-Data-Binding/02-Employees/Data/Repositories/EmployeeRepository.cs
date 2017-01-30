using System.Linq;

using _02_Employees.Data.Contracts;
using _02_Employees.Data.Repositories.Base;
using _02_Employees.Data.Repositories.Contracts;

namespace _02_Employees.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(INorthwindEntities context) 
            : base(context)
        {
        }

        public IQueryable<Employee> AllEmployees()
        {
            return this.All;
        }

        public Employee GetEmployeeById(int id)
        {
            return this.All.FirstOrDefault(e => e.EmployeeID == id);
        }
    }
}