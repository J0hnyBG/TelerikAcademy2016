namespace BankAccounts.Models.Accounts
{
    using Customers.Contracts;

    internal class DepositAccount : Account
    {
        public DepositAccount(decimal interestRate, decimal balance, ICustomer customer) : base(interestRate, balance, customer)
        {
        }

        public void Withdraw(decimal sum)
        {
            this.Balance -= sum;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            return base.CalculateInterest(months);
        }
    }
}
