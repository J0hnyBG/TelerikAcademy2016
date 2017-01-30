using System;
using System.Collections.Generic;
using System.Linq;

using Ploeh.AutoFixture;

using _01_Cars.Models.Contracts;
using _01_Cars.Models.Enums;
using _01_Cars.Models.Factories;
using _01_Cars.Services.Contracts;

namespace _01_Cars.Services
{
    public class CarService : ICarService
    {
        private const string ProducerPrefix = "P: ";
        private const string ModelPrefix = "M: ";

        private const int NumberOfProducers = 10;
        private const int NumberOfModels = 50;
        private const int NumberOfCars = 5000;

        private readonly IList<string> modelNames;

        private readonly ICarModelFactory carFactory;
        private readonly IEnumerable<ICarModel> cars;

        private readonly IProducerFactory producerFactory;
        private readonly IDictionary<string, IEnumerable<ICarModel>> producers;

        public CarService(ICarModelFactory carFactory, IProducerFactory producerFactory)
        {
            this.carFactory = carFactory;
            this.producerFactory = producerFactory;
            this.modelNames = new List<string>();

            this.cars = this.GetCars();
            this.producers = this.GetProducers();
        }

        public IEnumerable<ICarModel> FindCars(string producer,
                                               string model,
                                               EngineType engine,
                                               ICollection<Extra> extras)
        {
            if (this.producers.ContainsKey(producer))
            {
                var foundModels = this.producers[producer].Where(c => c.Name == model && c.Engine == engine);
                foreach (var extra in extras)
                {
                    foundModels = foundModels.Where(car => car.Extras.Any(e => e == extra));
                }

                return foundModels;
            }

            return new List<ICarModel>();
        }

        public IEnumerable<ICarModel> FindModelsForProducer(string producer)
        {
            if (this.producers.ContainsKey(producer))
            {
                return this.producers[producer];
            }

            return new List<ICarModel>();
        }

        public IEnumerable<string> GetAllProducerNames()
        {
            return this.producers.Keys;
        }

        public IEnumerable<string> GetAllModelNames()
        {
            return this.cars.GroupBy(x => x.Name)
                       .Select(g => g.First())
                       .Select(y => y.Name);
        }

        public IEnumerable<string> GetAllExtras()
        {
            return (from Extra p in Enum.GetValues(typeof(Extra)) select p.ToString()).ToList();
        }

        public IEnumerable<string> GetAllEngineTypes()
        {
            return (from EngineType p in Enum.GetValues(typeof(EngineType)) select p.ToString()).ToList();
        }

        private IDictionary<string, IEnumerable<ICarModel>> GetProducers()
        {
            var createdProducers = new Dictionary<string, IEnumerable<ICarModel>>();
            var f = new Fixture();

            for (var i = 0; i < NumberOfProducers; i++)
            {
                var name = f.Create(ProducerPrefix);
                var models = this.modelNames
                                 .Skip(i * NumberOfModels / NumberOfProducers)
                                 .Take(NumberOfModels / NumberOfProducers);

                var producerCars = new List<ICarModel>();
                foreach (var modelName in models)
                {
                    producerCars.AddRange(this.cars.Where(m => m.Name == modelName));
                }

                var p = this.producerFactory.CreateProducer(name, producerCars);
                createdProducers.Add(p.Name, p.Models);
            }

            return createdProducers;
        }

        private IEnumerable<ICarModel> GetCars()
        {
            var carModels = new List<ICarModel>();
            var f = new Fixture();
            var r = new Random();
            var extraCount = this.GetAllExtras().ToList().Count;
            for (var i = 0; i < NumberOfModels; i++)
            {
                var modelName = f.Create(ModelPrefix);
                this.modelNames.Add(modelName);

                for (var j = 0; j < NumberOfCars / NumberOfModels; j++)
                {
                    var extras = new List<Extra>();
                    f.AddManyTo(extras, r.Next(1, extraCount));
                    extras.Sort();

                    var car = this.carFactory.CreateCarModel(modelName, extras, f.Create<EngineType>());
                    carModels.Add(car);
                }
            }

            return carModels;
        }
    }
}
