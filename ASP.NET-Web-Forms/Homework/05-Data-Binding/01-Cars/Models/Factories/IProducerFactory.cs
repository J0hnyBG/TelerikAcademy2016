using System.Collections.Generic;

using _01_Cars.Models.Contracts;

namespace _01_Cars.Models.Factories
{
    public interface IProducerFactory
    {
        IProducer CreateProducer(string name, IList<ICarModel> models);
    }
}
