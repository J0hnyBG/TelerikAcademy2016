using System.Collections.Generic;

using _01_Cars.Models.Enums;

namespace _01_Cars.Models.Contracts
{
    public interface ICarModel
    {
        string Name { get; set; }

        IList<Extra> Extras { get; set; }

        EngineType Engine { get; set; }
    }
}
