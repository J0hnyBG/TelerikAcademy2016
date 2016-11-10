namespace Computers.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;

    using DataGenerators;
    using DataGenerators.Contracts;

    public class GeneratorService
    {
        public void InsertAllTableData()
        {
            var db = new ComputersEntitiesDb();

            var random = new RandomGenerator();
            var generators = GetAllGenerators();
            foreach (var dataGenerator in generators)
            {
                dataGenerator.Generate(db, random);
            }
        }

        private static IEnumerable<IDataGenerator> GetAllGenerators()
        {
            var assembly = typeof(IDataGenerator).Assembly;

            IEnumerable<Type> typeInfos = assembly.DefinedTypes
                                                  .Where(type => type.ImplementedInterfaces
                                                                     .Any(inter => inter == typeof(IDataGenerator)));

            var allGenerators =
                typeInfos.Select(t => Activator.CreateInstance(t) as IDataGenerator)
                         .OrderBy(generator => generator.Order);

            return allGenerators;
        }
    }
}
