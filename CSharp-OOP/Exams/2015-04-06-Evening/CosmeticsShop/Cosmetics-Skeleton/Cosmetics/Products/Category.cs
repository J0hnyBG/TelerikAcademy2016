using System.Linq;

namespace Cosmetics.Products
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Category : ProductContainer, ICategory
    {
        private string _name;

        public Category(string name)
        {
            this.Name = name;
            this.ListOfProducts = new List<IProduct>();
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));
                Validator.CheckIfStringLengthIsValid(value, 15, 2, string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", 2, 15));
                _name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.ListOfProducts.Add(cosmetics);
            this.ListOfProducts = this.ListOfProducts.OrderBy(x => x.Brand).ThenByDescending(x => x.Price).ToList();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.ListOfProducts.Contains(cosmetics))
            {
                throw new ArgumentException(string.Format("Product {0} does not exist in {1}!", cosmetics.Name, this.Name));
            }
            this.ListOfProducts.Remove(cosmetics);
        }

        public string Print()
        {
            var sb = new StringBuilder();
            switch (this.ListOfProducts.Count)
            {
                case 1:
                    sb.Append(string.Format("{0} category - {1} product in total", this.Name, this.ListOfProducts.Count));
                    break;
                default:
                    sb.Append(string.Format("{0} category - {1} products in total", this.Name, this.ListOfProducts.Count));
                    break;
            }
            foreach (var product in ListOfProducts)
            {
                sb.Append(product.Print());
            }

            return sb.ToString();
        }
    }
}
