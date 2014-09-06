namespace NorthwindDataModel.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using NorthwindDataModel.Data;

    public class Reports
    {
        public static void FindAllCustomersByYearAndCountry(int year, string country)
        {
            Northwind dbContext = new Northwind();

            using (dbContext)
            {
                var allCustomers =  from order in dbContext.Orders
                                    where order.OrderDate.Value.Year == year && order.ShipCountry == country
                                    select order;

                foreach (var currentCustomer in allCustomers)
                {
                    Console.WriteLine(currentCustomer.Customer.CustomerID + " " + currentCustomer.Customer.CompanyName + " " + currentCustomer.Customer.ContactName + " " +
                        currentCustomer.OrderID + " " + currentCustomer.OrderDate + " " + currentCustomer.RequiredDate + " " + currentCustomer.ShippedDate + " " + currentCustomer.Freight + " " +
                        currentCustomer.ShipAddress + " " + currentCustomer.ShipCity + " " + currentCustomer.ShipRegion + " " + currentCustomer.ShipPostalCode + " " + currentCustomer.ShipCountry);
                }
            }
        }

        public static void FindAllCustomersByYearAndCountrySQL(int year, string country)
        {
            Northwind dbContext = new Northwind();

            using (dbContext)
            {
                string sqlQuery = "SELECT CompanyName " + 
                                  "FROM  Customers inner join Orders on Customers.CustomerID = Orders.CustomerID " +
                                  "WHERE YEAR(OrderDate) = {0} AND ShipCountry = {1}";

                object[] queryParams = { year, country };
                var allCustomers = dbContext.Database.SqlQuery<string>(sqlQuery, queryParams);

                foreach (var currentCustomer in allCustomers)
                {
                    Console.WriteLine(currentCustomer);
                }
            }
        }

        public static void FindAllSales(string region, DateTime startDate, DateTime endDate)
        {
            Northwind dbContext = new Northwind();

            using(dbContext)
            {
                var allSales = from order in dbContext.Orders join orderDetails in dbContext.Order_Details
                               on order.OrderID equals orderDetails.OrderID
                               where order.ShipRegion == region && order.OrderDate.Value > startDate && order.ShippedDate.Value < endDate
                               select new
                               {
                                   Region = order.ShipRegion,
                                   Amount = orderDetails.Quantity * (double)orderDetails.UnitPrice * (double)(1 - orderDetails.Discount)  
                               };

                foreach (var sales in allSales)
                {
                    Console.WriteLine("Region -> Amount: {0} -> {1:0.00}", sales.Region, sales.Amount);
                }
            }
        }
    }
}
