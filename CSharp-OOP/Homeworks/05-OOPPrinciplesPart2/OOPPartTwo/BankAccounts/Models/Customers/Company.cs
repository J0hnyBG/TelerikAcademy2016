namespace BankAccounts.Models.Customers
{
    using Contracts;

    internal class Company : ICustomer
    {
        public Company(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
