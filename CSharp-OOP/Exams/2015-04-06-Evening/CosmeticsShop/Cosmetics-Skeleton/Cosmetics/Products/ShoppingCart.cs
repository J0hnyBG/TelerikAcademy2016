using Cosmetics.Common;

namespace Cosmetics.Products
{
    using System.Linq;
    using System.Collections.Generic;

    using Cosmetics.Contracts;

    public class ShoppingCart : ProductContainer, IShoppingCart
    {
        public ShoppingCart()
        {
            this.ListOfProducts = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.ListOfProducts.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.ListOfProducts.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.ListOfProducts.Contains(product);
        }

        public decimal TotalPrice()
        {
            return ListOfProducts.Sum(product => product.Price);
        }
    }
}
