using System;
using System.Collections.Generic;
using System.Linq;

using Company.DataGeneration.DataGenerators.Contracts;

namespace Company.DataGeneration.DataGenerators
{
    public class EmployeesProjectsDataGenerator : IDataGenerator
    {
        public void Generate(CompanyEntities db, IRandomGenerator random, int count)
        {
            var employeeIds = db.Employees.Select(d => d.Id).ToList();
            var projectIds = db.Projects.Select(p => p.Id).ToList();

            var employeeProjects = new List<EmployeesProject>();

            foreach (var employeeId in employeeIds)
            {
                var employeeProjectCount = random.GetRandomNumber((int)(0.5 * count), (int)(1.5 * count));
                var currentProjects = new HashSet<int>();

                while (currentProjects.Count < employeeProjectCount)
                {
                    var projectId = projectIds[random.GetRandomNumber(0, projectIds.Count - 1)];
                    currentProjects.Add(projectId);
                }

                foreach (var projectId in currentProjects)
                {
                    var endDate = random.GetRandomNumber(-500, 1000);
                    var startDate = endDate + random.GetRandomNumber(1, 500);

                    var report = new EmployeesProject()
                                 {
                                     EmployeeId = employeeId,
                                     ProjectId = projectId,
                                     StartDate = DateTime.Now.AddDays(-startDate),
                                     EndDate = DateTime.Now.AddDays(-endDate)
                                 };

                    employeeProjects.Add(report);
                }
            }

            db.EmployeesProjects.AddRange(employeeProjects);
        }
    }
}
