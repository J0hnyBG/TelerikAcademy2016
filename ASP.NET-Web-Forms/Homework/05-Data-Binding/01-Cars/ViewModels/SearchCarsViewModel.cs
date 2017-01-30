using System.Collections.Generic;

using _01_Cars.Models.Contracts;

namespace _01_Cars.ViewModels
{
    public class SearchCarsViewModel
    {
        public IEnumerable<string> Producers { get; set; }

        public IEnumerable<string> Models { get; set; }

        public IEnumerable<string> Extras { get; set; }

        public IEnumerable<string> EngineTypes { get; set; }

        public IEnumerable<ICarModel> FoundCars { get; set; }
    }
}
