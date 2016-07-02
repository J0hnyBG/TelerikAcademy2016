namespace Cosmetics.Products
{
    using System.Text;
    using System.Collections.Generic;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private string _ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = ParseIngredients(ingredients);
        }

        public string Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
        }

        public override string Print()
        {
            //return $"\n- {this.Brand} - {this.Name}:\n  * Price: ${this.Price}\n  * For genger: {this.Gender}\n  * Ingredients: {this.Ingredients}";
            return string.Format("\n- {0} - {1}:\n  * Price: ${2}\n  * For gender: {3}\n  * Ingredients: {4}", this.Brand, this.Name, this.Price, this.Gender, this.Ingredients);
        }

        private static string ParseIngredients(IList<string> ingredientList)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < ingredientList.Count; i++)
            {
                Validator.CheckIfStringLengthIsValid(ingredientList[i], 12, 4,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", 4, 12));
                if (i != ingredientList.Count - 1)
                {
                    sb.Append(ingredientList[i] + ", ");
                }
                else
                {
                    sb.Append(ingredientList[i]);
                }
            }
            return sb.ToString();
        }
    }
}