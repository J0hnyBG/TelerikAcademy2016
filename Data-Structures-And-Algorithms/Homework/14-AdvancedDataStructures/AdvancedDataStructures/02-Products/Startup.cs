using System;
using System.Collections.Generic;
using System.Diagnostics;

using _02_Products.Collections;
using _02_Products.Models;

namespace _02_Products
{
    internal class Startup
    {
        private const int MinPrice = 1;
        private const int MaxPrice = 50000;
        private const int TotalRanges = 100;
        private const int NumberOfProducts = 500000;
        private const int NumberOfSearches = 10000;

        private static readonly Random random = new Random();

        private static void Main()
        {
            var products = GetRandomProducts();

            var rangedCollection = new RangedCollection<Product>(TotalRanges, MinPrice, MaxPrice);

            foreach (var product in products)
            {
                rangedCollection.Add(product, product.Price);
            }

            Console.WriteLine("Collection and products have been initialized.");

            var st = new Stopwatch();
            var foundProducts = 0;
            for (var i = 0; i < NumberOfSearches; i++)
            {
                var minPrice = random.Next(MinPrice, MaxPrice - 1000);
                var maxPrice = random.Next(MinPrice, MaxPrice);
                while (minPrice >= maxPrice)
                {
                    minPrice = random.Next(MinPrice - 1000, MaxPrice);
                }

                st.Start();
                var result = rangedCollection.Find(minPrice, maxPrice, 20);
                st.Stop();

                foreach (var product in result)
                {
                    Debug.Assert(product.Price >= minPrice && product.Price < maxPrice, "Search is bugged!");
                }

                foundProducts += result.Count;
            }

            Console.WriteLine(
                              $"{NumberOfSearches} searches took {st.ElapsedMilliseconds}ms. Found a total of {foundProducts} products.");
        }

        private static IEnumerable<Product> GetRandomProducts()
        {
            var products = new List<Product>();
            for (var i = 0; i < NumberOfProducts; i++)
            {
                var pr = new Product(random.Next(MinPrice, MaxPrice), "Pesho");
                products.Add(pr);
            }

            return products;
        }
    }
}
