using System.Collections.Generic;

namespace _01_Cars.CustomEventArgs.Contracts
{
    public interface ICarSearchEventArgs : IProducerSelectionEventArgs
    {
        string SelectedModel { get; set; }

        ICollection<string> SelectedExtras { get; set; }

        string SelectedEngine { get; set; }
    }
}
