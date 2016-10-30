namespace DbFirst
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Data;

    internal class Startup
    {
        private static void Main()
        {
            //Task 2
            DemonstrateBasicDaoFunctions();

            //Task 3
            Console.WriteLine("Customers who have made orders in 1997 and shipped to Canada:");
            DisplayCustomersWhoHaveOrdersInCanada();

            //Task 4
            Console.WriteLine("Customers who have made orders in 1997 and shipped to Canada with native sql query:");
            DisplayCustomersWhoHaveOrdersInCanadaWithNativeQuery();

            //Task 5
            DisplayOrdersByRegionAndTimespan();

            //Task 6
            var northWindConnectionString = "NorthwindTwin";
            var context = new NorthwindEntities(northWindConnectionString);
            context.Database.CreateIfNotExists();

            //Task 7
            SimultaneousChanges();

            //Task 8
            var ctx = new NorthwindEntities();
            var e = ctx.Employees.ToList();
            foreach (var employee in e)
            {
                foreach (var territory in employee.Territories)
                {
                    Console.WriteLine($"{territory.Region.RegionDescription}: {territory.TerritoryDescription}");
                }
            }
        }

        private static void SimultaneousChanges()
        {
            var firstContext = DAO.GetDbContext();
            var secondContext = DAO.GetDbContext();

            using (firstContext)
            {
                using (secondContext)
                {
                    var firstCustomer = firstContext.Customers.FirstOrDefault();
                    var secondCustomer = secondContext.Customers.FirstOrDefault();

                    firstCustomer.CompanyName = "FirstCompany";
                    secondCustomer.CompanyName = "SecondCompany";

                    firstContext.SaveChanges();
                    secondContext.SaveChanges();
                }
            }

            var customers =
                DAO.ListAllCustomers().Where(x => x.CompanyName == "FirstCompany" || x.CompanyName == "SecondCompany");

            DisplayCustomers(customers);
            Divide();
        }

        private static void DisplayOrdersByRegionAndTimespan()
        {
            var startDate = DateTime.Now.AddYears(-20);
            var endDate = DateTime.Now.AddYears(-15);
            Console.WriteLine($"Orders in region 'SP' and between {startDate} and {endDate}");
            var orders = DAO.GetOrdersByRegionAndTimespan("SP", startDate, endDate);

            foreach (var order in orders)
            {
                Console.WriteLine($"{order.ShipRegion}: {order.OrderDate}");
            }

            Divide();
        }

        private static void DisplayCustomersWhoHaveOrdersInCanadaWithNativeQuery()
        {
            var ctx = new NorthwindEntities();
            using (ctx)
            {
                const string query = 
@"SELECT DISTINCT *
FROM Customers c
INNER JOIN Orders o
	ON c.CustomerID = o.CustomerID
WHERE o.OrderDate IS NOT NULL
AND o.OrderDate > CONVERT(DATETIME, '01/01/97')
AND o.ShipCountry = 'Canada'";

                var customers = ctx.Customers.SqlQuery(query).Distinct();

                DisplayCustomers(customers);
            }
            Divide();
        }

        private static void DisplayCustomersWhoHaveOrdersInCanada()
        {
            var customers = DAO.GetCustomersByYearAndCountryOfOrders(1997, "Canada");
            DisplayCustomers(customers);

            Divide();
        }

        private static void DemonstrateBasicDaoFunctions()
        {
            var customerId = "KASPV";
            var customerToInset = new Customer
                                  {
                                      Address = "Some street",
                                      CustomerID = customerId,
                                      Fax = "084564656",
                                      City = "Kaspichan",
                                      ContactTitle = "Mr.",
                                      ContactName = "Pesho Petrov",
                                      CompanyName = "Kaspichan Inc.",
                                      Country = "Bulgaria",
                                      Region = "Shumen",
                                      Phone = "088456879465",
                                      PostalCode = "12354",
                                      CustomerDemographics = null,
                                      Orders = null
                                  };
            //Insert
            try
            {
                DAO.InsertCustomer(customerToInset);
                Console.WriteLine($"Inserted customer: {customerToInset.CompanyName}: {customerToInset.City}");
            }
            catch (DbUpdateException e)
            {
                //Catch primary key exception
                Console.WriteLine(e.InnerException.InnerException.Message);
            }

            var customers = DAO.ListAllCustomers().Where(c => c.City == customerToInset.City).ToList();
            DisplayCustomers(customers);

            Divide();

            //Update
            var customerToUpdate = customers[0];
            customerToUpdate.CompanyName = "Not kaspichan inc";
            customerToUpdate.City = "Not kaspichan";
            DAO.UpdateCustomer(customerToUpdate);

            var modifiedCustomer =
                DAO.ListAllCustomers().FirstOrDefault(c => c.CustomerID == customerToUpdate.CustomerID);
            Console.WriteLine($"Updated customer to: {modifiedCustomer.CompanyName}: {modifiedCustomer.City}");
            Divide();

            //Delete
            DAO.DeleteCustomer(modifiedCustomer);
            Console.WriteLine($"Deleted customer: {modifiedCustomer.CompanyName}: {modifiedCustomer.City}");
            Divide();
        }

        private static void DisplayCustomers(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CompanyName}: {customer.City}");
            }
        }

        private static void Divide()
        {
            Console.WriteLine(new string('_', 75));
        }
    }
}
