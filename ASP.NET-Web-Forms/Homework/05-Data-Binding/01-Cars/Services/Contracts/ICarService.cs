using System.Collections.Generic;

using _01_Cars.Models.Contracts;
using _01_Cars.Models.Enums;

namespace _01_Cars.Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<ICarModel> FindCars(string producer, string model, EngineType engine, ICollection<Extra> extras);

        IEnumerable<ICarModel> FindModelsForProducer(string producer);

        IEnumerable<string> GetAllProducerNames();

        IEnumerable<string> GetAllModelNames();

        IEnumerable<string> GetAllExtras();

        IEnumerable<string> GetAllEngineTypes();
    }
}
