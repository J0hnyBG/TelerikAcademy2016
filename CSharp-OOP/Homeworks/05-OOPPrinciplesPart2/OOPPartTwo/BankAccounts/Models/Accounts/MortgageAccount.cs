namespace BankAccounts.Models.Accounts
{
    using System;
    using Customers;
    using Customers.Contracts;

    internal class MortgageAccount : Account
    {
        public MortgageAccount(decimal interestRate, decimal balance, ICustomer customer)
            : base(interestRate, balance, customer)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("Months can not be negative!");
            }

            if (this.Customer is Company)
            {
                if (months <= 12)
                {
                    return balance*(1 + (interestRate/2)*months);
                }

                return (balance*(1 + (interestRate/2)*12)) + base.CalculateInterest(months - 12);
            }
            if (this.Customer is Individual)
            {
                return months >= 6 ? base.CalculateInterest(months - 6) : 0;
            }
            return base.CalculateInterest(months);
        }
    }
}