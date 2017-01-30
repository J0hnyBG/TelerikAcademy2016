using System.Collections.Generic;

namespace _01_Cars.Models.Contracts
{
    public interface IProducer
    {
        string Name { get; set; }

        IList<ICarModel> Models { get; set; }
    }
}
