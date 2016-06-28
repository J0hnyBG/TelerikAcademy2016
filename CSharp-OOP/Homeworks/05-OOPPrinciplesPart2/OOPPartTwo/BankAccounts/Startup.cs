using System;

namespace BankAccounts
{
    using Models.Accounts;
    using Models.Customers;

    internal class Startup
    {
        
        static void Main()
        {
            var individual = new Individual("Petar Petrov");
            var company = new Company("Mobiltel EAD");

            var depositAccountInd = new DepositAccount(3, 600, individual);
            var depositAccountComp = new DepositAccount(2, 6000, company);

            depositAccountInd.Deposit(50);
            depositAccountComp.Withdraw(1000);
            Console.WriteLine($"Individual balance in deposit account before interest: {depositAccountInd.Balance:F2}.");
            Console.WriteLine($"Company balance in deposit account before interest: {depositAccountComp.Balance:F2}.");

            var individualInterest = depositAccountInd.CalculateInterest(12);
            var companyInterest = depositAccountComp.CalculateInterest(12);
            Divide();
            Console.WriteLine($"Individual balance after 12 months interest in deposit account: {individualInterest:F2}. (less than 1000 balance => no interest)");
            Console.WriteLine($"Company balance after 12 months interest in deposit account: {companyInterest:F2}.");
            var loanAcccountInd = new LoanAccount(7, 650, individual);
            var loanAcccountComp = new LoanAccount(9, 5000, company);

            individualInterest = loanAcccountInd.CalculateInterest(12);
            companyInterest = loanAcccountComp.CalculateInterest(12);
            Divide();
            Console.WriteLine($"Individual balance after 12 months interest in loan account: {individualInterest:F2}.");
            Console.WriteLine($"Company balance after 12 months interest in loan account: {companyInterest:F2}.");

            var mortageAccountInd = new MortgageAccount(7, 650, individual);
            var mortageAccountComp = new MortgageAccount(9, 5000, company);

            individualInterest = mortageAccountInd.CalculateInterest(12);
            companyInterest = mortageAccountComp.CalculateInterest(12);
            Divide();
            Console.WriteLine($"Individual balance after 12 months interest in mortage account: {individualInterest:F2}.");
            Console.WriteLine($"Company balance after 12 months interest in mortage account: {companyInterest:F2}.");
        }

        static void Divide()
        {
            Console.WriteLine(string.Empty.PadLeft(75, '='));
        }
    }
}
