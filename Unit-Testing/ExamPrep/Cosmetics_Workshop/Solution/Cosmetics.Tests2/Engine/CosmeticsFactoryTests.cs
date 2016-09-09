using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Tests2.Engine
{
    using System;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class CosmeticsFactoryTests
    {
        private ICosmeticsFactory _factory;

        [OneTimeSetUp]
        public void Init()
        {
            this._factory = new CosmeticsFactory();
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_WhenNameIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidName)
        {
            Assert.Throws<NullReferenceException>(
                () => this._factory.CreateShampoo(invalidName, "Brand", 0.5M, GenderType.Men, 500, UsageType.EveryDay));
        }

        [TestCase("1")]
        [TestCase("I am too long to be a shampoo name!")]
        public void CreateShampoo_WhenNameIsInvalid_ShouldThrowIndexOutOfRangeException(string invalidName)
        {
            Assert.Throws<IndexOutOfRangeException>(
                () => this._factory.CreateShampoo(invalidName, "Brand", 0.5M, GenderType.Men, 500, UsageType.EveryDay));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_WhenBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidBrand)
        {
            Assert.Throws<NullReferenceException>(
                () => this._factory.CreateShampoo("Name", invalidBrand, 0.5M, GenderType.Men, 500, UsageType.EveryDay));
        }

        [TestCase("1")]
        [TestCase("I am too long to be a brand name!")]
        public void CreateShampoo_WhenBrandIsInvalid_ShouldThrowIndexOutOfRangeException(string invalidBrand)
        {
            Assert.Throws<IndexOutOfRangeException>(
                () => this._factory.CreateShampoo("Name", invalidBrand, 0.5M, GenderType.Men, 500, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_WhenParamsAreValid_ShouldReturnNewShampoo()
        {
            var expectedName = "Name";
            var expectedBrand = "Brand";
            var expectedPrice = 0.5m;
            var expectedGender = GenderType.Men;
            var expectedMilliliters = 500u;
            var expectedUsage = UsageType.EveryDay;

            var result = this._factory.CreateShampoo(expectedName, expectedBrand, expectedPrice, expectedGender,
                expectedMilliliters, expectedUsage);

            Assert.IsInstanceOf(typeof(IShampoo), result);
            Assert.AreEqual(expectedName, result.Name);
            Assert.AreEqual(expectedBrand, result.Brand);
            Assert.AreEqual(expectedPrice * expectedMilliliters, result.Price);
            Assert.AreEqual(expectedGender, result.Gender);
            Assert.AreEqual(expectedMilliliters, result.Milliliters);
            Assert.AreEqual(expectedUsage, result.Usage);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateCategory_WhenNameIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidName)
        {
            Assert.Throws<NullReferenceException>(() => this._factory.CreateCategory(invalidName));
        }

        [TestCase("1")]
        [TestCase("I am too long to be a category name!")]
        public void CreateCategory_WhenNameIsInvalid_ShouldThrowIndexOutOfRangeException(string invalidName)
        {
            Assert.Throws<IndexOutOfRangeException>(() => this._factory.CreateCategory(invalidName));
        }

        [Test]
        public void CreateCategory_WhenParamsAreValid_ShouldReturnNewCategory()
        {
            var expectedName = "Category";

            var result = this._factory.CreateCategory(expectedName);

            Assert.IsInstanceOf(typeof(ICategory), result);
            Assert.AreEqual(expectedName, result.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_WhenNameIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidName)
        {
            Assert.Throws<NullReferenceException>(() => this._factory.CreateToothpaste(invalidName, "Brand", 0.5m, GenderType.Men, new List<string>() {"ingredient"}));
        }

        [TestCase("1")]
        [TestCase("I am too long to be a toothpaste name!")]
        public void CreateToothpaste_WhenNameIsInvalid_ShouldThrowIndexOutOfRangeException(string invalidName)
        {
            Assert.Throws<IndexOutOfRangeException>(() => this._factory.CreateToothpaste(invalidName, "Brand", 0.5m, GenderType.Men, new List<string>() { "ingredient" }));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_WhenBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string invalidBrand)
        {
            Assert.Throws<NullReferenceException>(() => this._factory.CreateToothpaste("Name", invalidBrand, 0.5m, GenderType.Men, new List<string>() { "ingredient" }));
        }

        [TestCase("1")]
        [TestCase("I am too long to be a brand name!")]
        public void CreateToothpaste_WhenBrandIsInvalid_ShouldThrowIndexOutOfRangeException(string invalidBrand)
        {
            Assert.Throws<IndexOutOfRangeException>(() => this._factory.CreateToothpaste("Name", invalidBrand, 0.5m, GenderType.Men, new List<string>() { "ingredient" }));
        }

        [Test]
        public void CreateToothpaste_WhenParamsAreValid_ShouldReturnNewToothpaste()
        {
            var expectedName = "Name";
            var expectedBrand = "Brand";
            var expectedPrice = 0.5m;
            var expectedGender = GenderType.Men;
            var ingredients = new List<string>() {"sugar", "spice"};
            var expectedIngredients = string.Join(", ", ingredients);

            var result = this._factory.CreateToothpaste(expectedName, expectedBrand, expectedPrice, expectedGender, ingredients);

            Assert.IsInstanceOf(typeof(IToothpaste), result);
            Assert.AreEqual(expectedName, result.Name);
            Assert.AreEqual(expectedBrand, result.Brand);
            Assert.AreEqual(expectedPrice, result.Price);
            Assert.AreEqual(expectedGender, result.Gender);
            Assert.AreEqual(expectedIngredients, result.Ingredients);
        }

        [TestCase( "TooLongToBeAnIngredient", "spice")]
        [TestCase( "sugar", "e")]
        [TestCase("TooLongToBeAnIngredient", "e")]
        public void CreateToothpaste_WhenIngredientsParamsAreInvalid_ShouldIndexOutOfRangeException(params string[] invalidIngredients)
        {
            var name = "Name";
            var brand = "Brand";
            var price = 0.5m;
            var gender = GenderType.Men;
            var ingredients = invalidIngredients.ToList();

            Assert.Throws<IndexOutOfRangeException>( () => this._factory.CreateToothpaste(name, brand, price, gender, ingredients));
        }

        [Test]
        public void CreateShoppingCart_ShouldReturnNewShoppingCart()
        {
            var result = this._factory.CreateShoppingCart();

            Assert.IsInstanceOf(typeof(IShoppingCart), result);
        }
    }
}