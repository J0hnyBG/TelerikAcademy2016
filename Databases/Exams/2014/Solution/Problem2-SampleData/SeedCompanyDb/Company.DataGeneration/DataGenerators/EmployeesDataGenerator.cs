using System.Collections.Generic;
using System.Linq;

using Company.DataGeneration.DataGenerators.Contracts;

namespace Company.DataGeneration.DataGenerators
{
    public class EmployeesDataGenerator : IDataGenerator
    {
        private const int MinEmployeeSalary = 50000;
        private const int MaxEmployeeSalary = 200000;
        private const int MinEmployeeNameLength = 5;
        private const int MaxEmployeeNameLength = 20;

        public void Generate(CompanyEntities db, IRandomGenerator random, int count)
        {
            var departmentIds = db.Departments.Select(d => d.Id).ToList();
            var employees = new List<Employee>();
            for (var i = 0; i < count; i++)
            {
                var min = departmentIds.Min();
                var max = departmentIds.Max();
                var departmentId = departmentIds[random.GetRandomNumber(min, max) - min];

                var salary = random.GetRandomNumber(MinEmployeeSalary, MaxEmployeeSalary);
                var firstName = random.GetRandomString(random.GetRandomNumber(MinEmployeeNameLength, MaxEmployeeNameLength));
                var lastName = random.GetRandomString(random.GetRandomNumber(MinEmployeeNameLength, MaxEmployeeNameLength));
                int? managerId = null;

                var employee = new Employee()
                {
                    DepartmentId = departmentId,
                    FirstName = firstName,
                    LastName = lastName,
                    YearlySalary = salary,
                };

                if (employees.Count > 0 && random.GetRandomNumber(1, 100) <= 95)
                {
                    employee.Employee1 = employees[random.GetRandomNumber(0, employees.Count - 1)];
                }

                employees.Add(employee);
            }

            db.Employees.AddRange(employees);
        }
    }
}
