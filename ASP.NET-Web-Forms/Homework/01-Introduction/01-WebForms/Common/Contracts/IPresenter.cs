namespace _01_WebForms.Common.Contracts
{
    public interface IPresenter<T>
    {
        T View { get; set; }
    }
}
