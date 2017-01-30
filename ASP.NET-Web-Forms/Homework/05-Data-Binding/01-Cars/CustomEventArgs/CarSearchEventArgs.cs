using System.Collections.Generic;

using _01_Cars.CustomEventArgs.Contracts;

namespace _01_Cars.CustomEventArgs
{
    public class CarSearchEventArgs : ProducerSelectionEventArgs, ICarSearchEventArgs
    {
        public CarSearchEventArgs(
            string selectedProducer,
            string selectedModel,
            string selectedEngine,
            ICollection<string> selectedExtras)
            : base(selectedProducer)
        {
            this.SelectedModel = selectedModel;
            this.SelectedExtras = selectedExtras;
            this.SelectedEngine = selectedEngine;
        }

        public string SelectedModel { get; set; }

        public ICollection<string> SelectedExtras { get; set; }

        public string SelectedEngine { get; set; }
    }
}
