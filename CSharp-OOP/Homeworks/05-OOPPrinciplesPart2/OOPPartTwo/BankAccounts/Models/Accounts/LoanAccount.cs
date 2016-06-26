
namespace BankAccounts.Models.Accounts
{
    using Customers;
    using Customers.Contracts;

    internal class LoanAccount : Account
    {
        public LoanAccount(decimal interestRate, decimal balance, ICustomer customer) : base(interestRate, balance, customer)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer is Company)
            {
                months -= 2;
            }
            else if ( this.Customer is Individual )
            {
                months -= 3;
            }
            return base.CalculateInterest(months);
        }
    }
}
