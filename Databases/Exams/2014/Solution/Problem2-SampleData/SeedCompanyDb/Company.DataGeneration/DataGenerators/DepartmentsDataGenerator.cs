using System.Collections.Generic;

using Company.DataGeneration.DataGenerators.Contracts;

namespace Company.DataGeneration.DataGenerators
{
    public class DepartmentsDataGenerator : IDataGenerator
    {
        private const int MinNameLength = 10;
        private const int MaxNameLength = 50;

        public void Generate(CompanyEntities db, IRandomGenerator random, int count)
        {
            var names = new HashSet<string>();

            while (names.Count < count)
            {
                var nameLength = random.GetRandomNumber(MinNameLength, MaxNameLength);
                var randomString = random.GetRandomString(nameLength);
                names.Add(randomString);
            }

            foreach (var name in names)
            {
                var department = new Department() { Name = name };
                db.Departments.Add(department);
            }
        }
    }
}
