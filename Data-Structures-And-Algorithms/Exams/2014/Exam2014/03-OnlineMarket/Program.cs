using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_OnlineMarket
{
    internal class Program
    {
        private const string AddCommand = "add";
        private const string FilterCommand = "filter";
        private const string EndCommand = "end";
        private static IList<string> Output = new List<string>();

        private static void Main(string[] args)
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

            foreach (var line in Output)
            {
                Console.WriteLine(line);
            }
        }

        private static void HandleFilterCommand(Market market, string[] splitCmd)
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
                    IEnumerable<Product> result;
                    if (splitCmd[3] == "to")
                    {
                        result = market.FindProductsByPrice(max: double.Parse(splitCmd[4]));
                    }
                    else if (splitCmd[3] == "from" && splitCmd.Length < 6)
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

        private static void HandleAddCommand(Market market, string[] splitCmd)
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

        private static void PrintProducts(IEnumerable<Product> products)
        {
            var sb = new StringBuilder("Ok: ");
            if (products != null)
            {
                sb.Append(string.Join(", ", products));
            }
            Console.WriteLine(sb.ToString().TrimEnd(',', ' '));
        }
    }

    internal class Market
    {
        private readonly IComparer<Product> productComparer;
        private readonly HashSet<string> productNames;
        private readonly IDictionary<string, ISet<Product>> productsByType;
        private readonly ISet<Product> productsByPrice;

        public Market()
        {
            this.productComparer = Comparer<Product>.Create((a, b) =>
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

            this.productsByPrice = new SortedSet<Product>(this.productComparer);
            this.productsByType = new Dictionary<string, ISet<Product>>();
            this.productNames = new HashSet<string>();
        }

        public bool AddProduct(Product product)
        {
            if (!this.productNames.Add(product.Name))
            {
                return false;
            }

            if (!this.productsByType.ContainsKey(product.Type))
            {
                this.productsByType[product.Type] = new SortedSet<Product>(this.productComparer);
            }

            this.productsByType[product.Type].Add(product);
            this.productsByPrice.Add(product);

            return true;
        }

        public IEnumerable<Product> FindProductsByType(string type)
        {
            if (this.productsByType.ContainsKey(type))
            {
                return this.productsByType[type].Take(10);
            }

            return null;
        }

        public IEnumerable<Product> FindProductsByPrice(double min = double.MinValue, double max = double.MaxValue)
        {
            var result = this.productsByPrice.Where(p => p.Price >= min && p.Price <= max).Take(10);
            return result;
        }
    }

    internal class Product
    {
        public string Name;
        public string Type;
        public double Price;

        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
