using System;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace _01_Cars.App_Start.Factories
{
    public class MvpPresenterFactory : IPresenterFactory
    {
        private readonly IMvpPresenterFactory factory;

        public MvpPresenterFactory(IMvpPresenterFactory factory)
        {
            this.factory = factory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.factory.GetPresenter(presenterType, viewInstance);
        }

        public void Release(IPresenter presenter)
        {
            var disposable = presenter as IDisposable;
            disposable?.Dispose();
        }
    }
}
