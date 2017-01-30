using System.Web.UI;
using System.Web.UI.WebControls;

using Ninject;

using _02_Employees.Data.Repositories.Contracts;

namespace _02_Employees
{
    public class EmployeeBasePage : Page
    {
        [Inject]
        public IEmployeeRepository Repository { protected get; set; }

        protected void EmployeesDataSource_OnContextCreating(object sender, LinqDataSourceContextEventArgs e)
        {
            e.ObjectInstance = this.Repository;
        }
    }
}