using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_OnlineMarket
{
    internal class Program
    {
        private const string AddCommand = "add";
        private const string FilterCommand = "filter";
        private const string EndCommand = "end";

        private static void Main()
        {
            var market = new Market();
            var command = Console.ReadLine();
            while (command != EndCommand)
            {
                var splitCmd = command.Split(' ');
                switch (splitCmd[0])
                {
                    case AddCommand:
                        HandleAddCommand(market, splitCmd);
                        break;
                    case FilterCommand:
                        HandleFilterCommand(market, splitCmd);
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void HandleFilterCommand(Market market, IReadOnlyList<string> splitCmd)
        {
            switch (splitCmd[2])
            {
                case "type":
                    var products = market.FindProductsByType(splitCmd[3]);
                    if (products == null)
                    {
                        Console.WriteLine("Error: Type " + splitCmd[3] + " does not exists");
                        break;
                    }

                    PrintProducts(products);
                    break;
                case "price":
                    IEnumerable<IProduct> result;
                    if (splitCmd[3] == "to")
                    {
                        result = market.FindProductsByPrice(max: double.Parse(splitCmd[4]));
                    }
                    else if (splitCmd[3] == "from" && splitCmd.Count < 6)
                    {
                        result = market.FindProductsByPrice(min: double.Parse(splitCmd[4]));
                    }
                    else
                    {
                        result = market.FindProductsByPrice(min: double.Parse(splitCmd[4]),
                                                            max: double.Parse(splitCmd[6]));
                    }

                    PrintProducts(result);
                    break;
            }
        }

        private static void HandleAddCommand(Market market, IReadOnlyList<string> splitCmd)
        {
            var name = splitCmd[1];
            var price = double.Parse(splitCmd[2]);
            var type = splitCmd[3];
            var product = new Product(name, price, type);
            if (market.AddProduct(product))
            {
                Console.WriteLine("Ok: Product " + product.Name + " added successfully");
            }
            else
            {
                Console.WriteLine("Error: Product " + product.Name + " already exists");
            }
        }

        private static void PrintProducts(IEnumerable<IProduct> products)
        {
            var result = "Ok: ";
            if (products != null)
            {
                result = result + string.Join(", ", products);
            }

            Console.WriteLine(result);
        }
    }

    internal class Market
    {
        private readonly IComparer<IProduct> productComparer;
        private readonly ISet<string> productNames;
        private readonly IDictionary<string, ISet<IProduct>> productsByType;
        private readonly ISet<IProduct> productsByPrice;

        public Market()
        {
            this.productComparer = Comparer<IProduct>.Create((a, b) =>
                                                            {
                                                                var result = a.Price.CompareTo(b.Price);
                                                                if (result == 0)
                                                                {
                                                                    result = string.Compare(a.Name, b.Name, StringComparison.Ordinal);
                                                                }

                                                                if (result == 0)
                                                                {
                                                                    result = string.Compare(a.Type, b.Type, StringComparison.Ordinal);
                                                                }

                                                                return result;
                                                            });

            this.productsByPrice = new SortedSet<IProduct>(this.productComparer);
            this.productsByType = new Dictionary<string, ISet<IProduct>>();
            this.productNames = new HashSet<string>();
        }

        public bool AddProduct(IProduct product)
        {
            if (!this.productNames.Add(product.Name))
            {
                return false;
            }

            if (!this.productsByType.ContainsKey(product.Type))
            {
                this.productsByType[product.Type] = new SortedSet<IProduct>(this.productComparer);
            }

            this.productsByType[product.Type].Add(product);
            this.productsByPrice.Add(product);

            return true;
        }

        public IEnumerable<IProduct> FindProductsByType(string type)
        {
            if (this.productsByType.ContainsKey(type))
            {
                return this.productsByType[type].Take(10);
            }

            return null;
        }

        public IEnumerable<IProduct> FindProductsByPrice(double min = double.MinValue, double max = double.MaxValue)
        {
            var result = this.productsByPrice.Where(p => p.Price >= min && p.Price <= max).Take(10);
            return result;
        }
    }

    internal class Product : IProduct
    {
        public string name;
        public string type;
        public double price;

        public Product(string name, double price, string type)
        {
            this.name = name;
            this.type = type;
            this.price = price;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Type
        {
            get { return this.type; }
        }

        public double Price
        {
            get { return this.price; }
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }

    internal interface IProduct
    {
        string Name { get; }
        string Type { get; }
        double Price { get; }

    }
}
