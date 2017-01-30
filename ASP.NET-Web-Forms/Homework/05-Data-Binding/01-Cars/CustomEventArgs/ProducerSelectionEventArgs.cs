using System;

using _01_Cars.CustomEventArgs.Contracts;

namespace _01_Cars.CustomEventArgs
{
    public class ProducerSelectionEventArgs : EventArgs, IProducerSelectionEventArgs
    {
        public ProducerSelectionEventArgs(string selectedProducer)
        {
            this.SelectedProducer = selectedProducer;
        }

        public string SelectedProducer { get; set; }
    }
}
