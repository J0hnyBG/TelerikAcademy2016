namespace Facade.Data
{
    using System;
    using System.Collections.Generic;

    using Models;

    public class MockDbContext : IDisposable
    {
        public ICollection<TotalRevenueByDealer> GetTotalRevenueByDealers()
        {
            return new List<TotalRevenueByDealer>()
                   {
                       new TotalRevenueByDealer() { Dealer = "Dealer 1", TotalOrders = 20, TotalRevenue = 1000, Town = "Sofia" },
                       new TotalRevenueByDealer() { Dealer = "Dealer 2", TotalOrders = 20, TotalRevenue = 2000, Town = "Sofia" },
                       new TotalRevenueByDealer() { Dealer = "Dealer 3", TotalOrders = 20, TotalRevenue = 3000, Town = "Sofia" },
                       new TotalRevenueByDealer() { Dealer = "Dealer 4", TotalOrders = 20, TotalRevenue = 4000, Town = "Sofia" }
                   };
        }

        public void Dispose()
        {
        }
    }
}
