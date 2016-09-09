namespace Cosmetics.Tests2.Engine
{
    using System.Collections.Generic;
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Tests2.Engine.Mocks;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_WhenInputStringIsValidCreateCategoryCommand_CategoryShouldBeAddedToList()
        {
            var categoryName = "ForMale";

            var mockedCommand = new Mock<ICommand>();
            mockedCommand.SetupGet(x => x.Name).Returns("CreateCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            var mockedCategory = new Mock<ICategory>();
            mockedCategory.SetupGet((x) => x.Name).Returns(categoryName);
            var mockedFactory = new Mock<ICosmeticsFactory>();
            mockedFactory.Setup(x => x.CreateCategory(categoryName)).Returns(mockedCategory.Object);
            var mockedCommandParser = new Mock<ICommandParser>();
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });
            var mockedShoppingCart = new Mock<IShoppingCart>();

            var mockedEngine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            mockedEngine.Start();

            Assert.IsTrue(mockedEngine.Categories.ContainsKey(categoryName));
            Assert.AreSame(mockedCategory.Object, mockedEngine.Categories[categoryName]);
        }

        [Test]
        public void Start_WhenInputStringIsValidAddToCategoryCommand_ShouldCallAddToCategoryMethodOnce()
        {
            var categoryName = "ForMale";
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("AddToCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() {categoryName, productName});
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedProduct.Object);

            engine.Start();

            mockedCategory.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValidRemoveFromCategoryCommand_ShouldCallRemoveProductMethodOnce()
        {
            var categoryName = "ForMale";
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("RemoveFromCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName, productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedProduct.Object);

            engine.Start();

            mockedCategory.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValidShowCategoryCommand_ShouldCallCategoryPrintMethodOnce()
        {
            var categoryName = "ForMale";
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCategory = new Mock<ICategory>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("ShowCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName, mockedCategory.Object);

            engine.Start();

            mockedCategory.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValid_CreateShampooCommand_ShouldAddNewShampooToListOfProducts()
        {
            var shampooName = "White+";
            var shampooBrand = "Nivea";
            var shampooPrice = "0.5";
            var shampooGender = "men";
            var shampooMilliliters = "500";
            var shampooUsage = "everyday";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();
            var mockedShampoo = new Mock<IShampoo>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateShampoo");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { shampooName, shampooBrand, shampooPrice, shampooGender, shampooMilliliters, shampooUsage });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });
            mockedFactory.Setup(
                x => x.CreateShampoo(shampooName, shampooBrand, 0.5M, GenderType.Men, 500, UsageType.EveryDay))
                .Returns(mockedShampoo.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Start();

            mockedFactory.Verify(
                x => x.CreateShampoo(shampooName, shampooBrand, 0.5M, GenderType.Men, 500, UsageType.EveryDay), Times.Once);

            Assert.IsTrue(engine.Products.ContainsKey(shampooName));
            Assert.AreSame(mockedShampoo.Object, engine.Products[shampooName]);
        }

        [Test]
        public void Start_WhenInputStringIsValid_CreateToothpasteCommand_ShouldAddNewToothpasteToListOfProducts()
        {
            var toothpasteName = "White+";
            var toothpasteBrand = "Nivea";
            var toothpastePrice = "0.5";
            var toothpasteGender = "men";
            var toothpasteIngredients = "fluor,bqla,golqma";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();
            var mockedtoothpaste = new Mock<IToothpaste>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateToothpaste");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { toothpasteName, toothpasteBrand, toothpastePrice, toothpasteGender,  toothpasteIngredients});
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });
            mockedFactory.Setup(
                x => x.CreateToothpaste(toothpasteName, toothpasteBrand, 0.5M, GenderType.Men, new List<string>() { "fluor", "bqla" , "golqma" }))
                .Returns(mockedtoothpaste.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Start();

            mockedFactory.Verify(
                x => x.CreateToothpaste(toothpasteName, toothpasteBrand, 0.5M, GenderType.Men, new List<string>() { "fluor", "bqla", "golqma" }), 
                Times.Once);

            Assert.IsTrue(engine.Products.ContainsKey(toothpasteName));
            Assert.AreSame(mockedtoothpaste.Object, engine.Products[toothpasteName]);
        }

        [Test]
        public void Start_WhenInputStringIsValid_AddToShoppingCartCommand_ShouldCallAddProductMethodOnce()
        {
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();
            var mockedProduct = new Mock<IToothpaste>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("AddToShoppingCart");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Products.Add(productName, mockedProduct.Object);

            engine.Start();

            mockedShoppingCart.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValid_RemoveFromShoppingCartCommand_ShouldCallRemoveProductMethodOnce()
        {
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();
            var mockedProduct = new Mock<IToothpaste>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("RemoveFromShoppingCart");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            mockedShoppingCart.Setup(x => x.ContainsProduct(mockedProduct.Object)).Returns(true);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Products.Add(productName, mockedProduct.Object);

            engine.Start();

            mockedShoppingCart.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once);
        }
    }
}