using System.Collections.Generic;

using _01_Cars.Models.Contracts;
using _01_Cars.Models.Enums;

namespace _01_Cars.Models
{
    public class CarModel : ICarModel
    {
        public CarModel(string name, IList<Extra> extras, EngineType engine)
        {
            this.Name = name;
            this.Extras = extras;
            this.Engine = engine;
        }

        public string Name { get; set; }

        public IList<Extra> Extras { get; set; }

        public EngineType Engine { get; set; }
    }
}
