namespace NorthwindDataModel.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Linq;

    using NorthwindDataModel.Data;

    public class Program
    {
        public static void Main()
        {
            Northwind dbContext = new Northwind();
            Northwind dbContext2 = new Northwind();

            string[] newValues = { "", "", "", "18 Ivan Vazov Str.", "Plovdiv", "Plovdiv", "4000", "", "4567896", "6549874" };
            DateTime startDate = new DateTime(1990, 1, 1);

            using (dbContext)
            {
                //Task 2
                DataAccessObjectsCustomers.AddCustomer("My Company", "Ivan Petrov", "Mr", "1 Moskovska Str.", "Sofia", "Sofia", "1000", "Bulgaria", "1234567", "9876543");
                DataAccessObjectsCustomers.UpdateCustomer("BOLID", newValues);
                DataAccessObjectsCustomers.DeleteCustomer("ANTON");

                //Task 3
                Reports.FindAllCustomersByYearAndCountry(1997, "CANADA");

                //Task 4
                Reports.FindAllCustomersByYearAndCountrySQL(1997, "CANADA");

                //Task 5
                Reports.FindAllSales("NM", startDate, DateTime.Now);

                //Task 7
                using(dbContext2)
                {
                    dbContext.Shippers.Add(new Shipper() { CompanyName = "BGPost1", Phone = "9876543"});
                    dbContext2.Shippers.Add(new Shipper() { CompanyName = "BGPostal1", Phone = "1876543" });

                    dbContext.SaveChanges();
                    dbContext2.SaveChanges();
                }

                //Task 8
                var allEmployees = dbContext.EmployeeExtended.Include("Territories");

                foreach (var employee in allEmployees)
                {
                    var correspondingTerritories = employee.CorrespondingTerritories.Select(t => t.TerritoryID);
                    var correspondingTerritoriesAsString = string.Join(", ", correspondingTerritories);

                    Console.WriteLine("{0} -> Territory IDs: {1}", employee.FirstName, correspondingTerritoriesAsString);
                }

                //Task 9
                List<Order_Detail> allDetails = new List<Order_Detail>()                
                {
                    new Order_Detail
                    {
                        ProductID = 11,
                        UnitPrice = 10,
                        Quantity = 50,
                        Discount = (float)0.03
                    },
                    new Order_Detail
                    {
                        ProductID = 14,
                        UnitPrice = 15,
                        Quantity = 20,
                        Discount = (float)0.14
                    },
                    new Order_Detail
                    {
                        ProductID = 51,
                        UnitPrice = 6,
                        Quantity = 30,
                        Discount = (float)0.3
                    }
                };

                DataAccessObjectsOrders.AddOrder("Santa Maria", "Plovdiv", allDetails);

                //Task 10
                string companyName = "Exotic Liquids";
                var suppliersIncomeForPeriod = dbContext.Suppliers_Income_for_Period(companyName, startDate, DateTime.Now);

                foreach (var item in suppliersIncomeForPeriod)
                {
                    Console.WriteLine("{0} -> {1} -> {2}", companyName, item.ProductName, item.Product_Income);
                }
            }
        }
    }
}
