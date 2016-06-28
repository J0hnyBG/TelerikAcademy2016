
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
                if (months >= 2)
                {
                    months -= 2;
                }
                else
                {
                    return this.Balance;
                }
            }
            else if ( this.Customer is Individual )
            {
                if ( months >= 3 )
                {
                    months -= 3;
                }
                else
                {
                    return this.Balance;
                }
            }
            return base.CalculateInterest(months);
        }
    }
}
