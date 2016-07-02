namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using Cosmetics.Contracts;

    public class ProductContainer : IProductContainer
    {
        public IList<IProduct> ListOfProducts { get; protected set; }
    }
}
