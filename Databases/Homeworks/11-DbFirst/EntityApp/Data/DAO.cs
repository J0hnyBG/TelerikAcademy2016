namespace DbFirst.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DAO
    {
        public static NorthwindEntities GetDbContext()
        {
            return new NorthwindEntities();
        }

        public static void InsertCustomer(Customer customer)
        {
            CheckForNull(customer);

            var ctx = GetDbContext();
            using (ctx)
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            CheckForNull(customer);

            var ctx = GetDbContext();

            using (ctx)
            {
                var customerToModify = ctx.Customers.First(x => x.CustomerID == customer.CustomerID);

                var valuesToModify = ctx.Entry(customerToModify).CurrentValues;
                valuesToModify.SetValues(customer);
                ctx.SaveChanges();
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            CheckForNull(customer);

            var ctx = GetDbContext();

            using (ctx)
            {
                var match = ctx.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
                ctx.Customers.Remove(match);
                ctx.SaveChanges();
            }
        }

        public static IList<Customer> ListAllCustomers()
        {
            var ctx = GetDbContext();

            using (ctx)
            {
                var customers = ctx.Customers.ToList();

                return customers;
            }
        }

        public static ICollection<Customer> GetCustomersByYearAndCountryOfOrders(int year, string countryName)
        {
            var ctx = GetDbContext();
            using (ctx)
            {
                var customers = ctx.Orders
                                   .Where(
                                          o =>
                                              o.OrderDate != null && o.OrderDate.Value.Year == year &&
                                              o.ShipCountry == countryName)
                                   .Select(o => o.Customer)
                                   .Distinct()
                                   .ToList();

                return customers;
            }
        }

        public static ICollection<Order> GetOrdersByRegionAndTimespan(string shipRegion, DateTime start, DateTime end)
        {
            var ctx = GetDbContext();

            using (ctx)
            {
                var orders =
                    ctx.Orders.Where(o => o.OrderDate > start
                                          && o.OrderDate < end
                                          && o.ShipRegion == shipRegion)
                       .ToList();

                return orders;
            }
        }

        private static void CheckForNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
        }
    }
}
