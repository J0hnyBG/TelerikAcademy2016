
namespace BankAccounts.Models.Accounts
{
    using System;
    using Customers.Contracts;
    using Contracts;

    internal abstract class Account : IAccount
    {
        protected decimal interestRate;
        protected decimal balance;
        protected ICustomer customer;

        protected Account(decimal interestRate, decimal balance, ICustomer customer)
        {
            this.InterestRate = interestRate;
            this.Balance = balance;
            this.Customer = customer;
        }

        public decimal InterestRate
        {
            //Returns user-friendly percent value, but stores it as a fraction for easier calculations
            get { return interestRate * 100; }
            set {
                if (value < 0 )
                {
                    throw new ArgumentException("Invalid interest rate!");
                }
                interestRate = value/100; }
        }

        public decimal Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        public ICustomer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("Months can not be negative!");
            }
            return balance*(1 + interestRate*months);
        }
    }
}
