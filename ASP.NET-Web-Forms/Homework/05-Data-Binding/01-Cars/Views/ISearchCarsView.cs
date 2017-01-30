using System;

using WebFormsMvp;

using _01_Cars.CustomEventArgs.Contracts;
using _01_Cars.CustomEventArgs.Factories;
using _01_Cars.ViewModels;

namespace _01_Cars.Views
{
    public interface ISearchCarsView : IView<SearchCarsViewModel>
    {
        event EventHandler<ICarSearchEventArgs> OnFormSubmit;

        event EventHandler<IProducerSelectionEventArgs> OnProducerSelectionChanged;

        event EventHandler<EventArgs> OnInitialize;

        ICustomEventArgsFactory EventArgsFactory { set; }
    }
}
