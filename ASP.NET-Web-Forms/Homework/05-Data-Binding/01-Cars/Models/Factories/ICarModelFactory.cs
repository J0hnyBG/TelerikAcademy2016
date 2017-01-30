using System.Collections.Generic;

using _01_Cars.Models.Contracts;
using _01_Cars.Models.Enums;

namespace _01_Cars.Models.Factories
{
    public interface ICarModelFactory
    {
        ICarModel CreateCarModel(string name, IList<Extra> extras, EngineType engine);
    }
}
