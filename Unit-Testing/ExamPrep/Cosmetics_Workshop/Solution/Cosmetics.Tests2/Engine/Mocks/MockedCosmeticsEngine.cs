﻿using System.Collections.Generic;
using Cosmetics.Contracts;
using Cosmetics.Engine;

namespace Cosmetics.Tests2.Engine.Mocks
{
    internal class MockedCosmeticsEngine : CosmeticsEngine
    {
        public MockedCosmeticsEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser)
            : base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get { return base.categories; }
        }
        public IDictionary<string, IProduct> Products
        {
            get { return base.products; }
        }

    }
}
