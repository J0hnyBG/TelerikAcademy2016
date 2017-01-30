using System.Collections.Generic;

using _01_Cars.Models.Contracts;

namespace _01_Cars.Models
{
    public class Producer : IProducer
    {
        public Producer(string name, IList<ICarModel> models)
        {
            this.Name = name;
            this.Models = models;
        }

        public string Name { get; set; }

        public IList<ICarModel> Models { get; set; }
    }
}
