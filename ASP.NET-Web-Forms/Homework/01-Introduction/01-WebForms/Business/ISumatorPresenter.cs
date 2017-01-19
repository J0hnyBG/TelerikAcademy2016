using _01_WebForms.Common.Contracts;

namespace _01_WebForms.Business
{
    public interface ISumatorPresenter : IPresenter<ISumatorPageView>
    {
        void CalculateSum();
    }
}