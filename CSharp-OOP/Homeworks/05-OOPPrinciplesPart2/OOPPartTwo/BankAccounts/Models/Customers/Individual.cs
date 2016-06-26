namespace BankAccounts.Models.Customers
{
    using Contracts;

    internal class Individual: ICustomer
    {
        public Individual(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
