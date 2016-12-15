namespace _02_Products.Models
{
    public struct Product
    {
        public Product(int price, string name)
        {
            this.Price = price;
            this.Name = name;
        }

        public int Price { get; set; }

        public string Name { get; set; }
    }
}
