using System.Collections.Generic;

using _01_Cars.CustomEventArgs.Contracts;

namespace _01_Cars.CustomEventArgs.Factories
{
    public interface ICustomEventArgsFactory
    {
        IProducerSelectionEventArgs CreateProducerSelectionEventArgs(string selectedProducer);

        ICarSearchEventArgs CreateCarSearchEventArgs(string selectedProducer,
                                                     string selectedModel,
                                                     string selectedEngine,
                                                     ICollection<string> selectedExtras);
    }
}
