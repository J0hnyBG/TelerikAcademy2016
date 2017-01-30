using System;

using WebFormsMvp;

namespace _01_Cars.App_Start.Factories
{
    public interface IMvpPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
