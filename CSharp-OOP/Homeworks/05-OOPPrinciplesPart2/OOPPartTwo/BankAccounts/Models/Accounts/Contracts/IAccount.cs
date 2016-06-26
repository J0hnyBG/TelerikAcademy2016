namespace BankAccounts.Models.Accounts.Contracts
{
   using Customers.Contracts;
   internal interface IAccount
   {
       decimal InterestRate { get; set; }
       decimal Balance { get; }
       ICustomer Customer { get; set; }

       void Deposit(decimal sum);
       decimal CalculateInterest(int months);
   }
}
