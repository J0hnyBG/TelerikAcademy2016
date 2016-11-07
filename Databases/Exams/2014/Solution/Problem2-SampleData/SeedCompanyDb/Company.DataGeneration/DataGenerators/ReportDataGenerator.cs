using System;
using System.Collections.Generic;
using System.Linq;

using Company.DataGeneration.DataGenerators.Contracts;

namespace Company.DataGeneration.DataGenerators
{
    public class ReportDataGenerator : IDataGenerator
    {
        public void Generate(CompanyEntities db, IRandomGenerator random, int count)
        {
            var employeeIds = db.Employees.Select(d => d.Id).ToList();
            var reports = new List<Report>();

            foreach (var employeeId in employeeIds)
            {
                var employeeReportsCount = random.GetRandomNumber((int)(0.5 * count), (int)(1.5 * count));

                for (var i = 0; i < employeeReportsCount; i++)
                {
                    var reportTime = random.GetRandomNumber(0, 24 * 60 * 60 * 1000);

                    var report = new Report()
                                 {
                                     EmployeeId = employeeId,
                                     ReportTime = DateTime.Now.AddSeconds(-reportTime)
                                 };

                    reports.Add(report);
                }
            }

            db.Reports.AddRange(reports);
        }
    }
}
