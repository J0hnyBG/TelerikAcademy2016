namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    public interface IProductContainer
    {
        IList<IProduct> ListOfProducts { get; }
    }
}
