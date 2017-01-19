using _01_WebForms.Common.Contracts;

namespace _01_WebForms.Business
{
    public interface ISumatorPresenter : IView<ISumatorPageView>
    {
        void CalculateSum();
    }
}