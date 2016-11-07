using System.Collections.Generic;

using Company.DataGeneration.DataGenerators.Contracts;

namespace Company.DataGeneration.DataGenerators
{
    public class ProjectsDataGenerator : IDataGenerator
    {
        public void Generate(CompanyEntities db, IRandomGenerator random, int count)
        {
            var names = new List<string>();

            while (names.Count < count)
            {
                var nameLength = random.GetRandomNumber(5, 50);
                var randomName = random.GetRandomString(nameLength);
                names.Add(randomName);
            }

            foreach (var name in names)
            {
                var project = new Project() { Name = name };
                db.Projects.Add(project);
            }
        }
    }
}
