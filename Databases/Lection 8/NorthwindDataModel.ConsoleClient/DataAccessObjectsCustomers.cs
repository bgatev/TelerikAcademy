namespace NorthwindDataModel.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    using NorthwindDataModel.Data;

    public class DataAccessObjectsCustomers
    {
        public static void AddCustomer(string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax)
        {
            Northwind dbContext = new Northwind();

            using (dbContext)
            {
                Customer currentCustomer = new Customer();

                currentCustomer.CompanyName = CompanyName;
                currentCustomer.ContactName = ContactName;
                currentCustomer.ContactTitle = ContactTitle;
                currentCustomer.Address = Address;
                currentCustomer.City = City;
                currentCustomer.Region = Region;
                currentCustomer.PostalCode = PostalCode;
                currentCustomer.Country = Country;
                currentCustomer.Phone = Phone;
                currentCustomer.Fax = Fax;

                dbContext.Customers.Add(currentCustomer);
                dbContext.SaveChanges();
            }
        }

        public static void UpdateCustomer(string CustomerID, string[] newValues) 
        {
            Northwind dbContext = new Northwind();

            using (dbContext)
            {
                Customer currentCustomer = dbContext.Customers.First(c => c.CustomerID == CustomerID);

                dbContext.Entry(currentCustomer).State = EntityState.Modified;

                if (!string.IsNullOrEmpty(newValues[0])) currentCustomer.CompanyName = newValues[0];
                if (!string.IsNullOrEmpty(newValues[1])) currentCustomer.ContactName = newValues[1];
                if (!string.IsNullOrEmpty(newValues[2])) currentCustomer.ContactTitle = newValues[2];
                if (!string.IsNullOrEmpty(newValues[3])) currentCustomer.Address = newValues[3];
                if (!string.IsNullOrEmpty(newValues[4])) currentCustomer.City = newValues[4];
                if (!string.IsNullOrEmpty(newValues[5])) currentCustomer.Region = newValues[5];
                if (!string.IsNullOrEmpty(newValues[6])) currentCustomer.PostalCode = newValues[6];
                if (!string.IsNullOrEmpty(newValues[7])) currentCustomer.Country = newValues[7];
                if (!string.IsNullOrEmpty(newValues[8])) currentCustomer.Phone = newValues[8];
                if (!string.IsNullOrEmpty(newValues[9])) currentCustomer.Fax = newValues[9];

                dbContext.SaveChanges();
            }
        }

        public static void DeleteCustomer(string CustomerID)
        {
            Northwind dbContext = new Northwind();

            using (dbContext)
            {
                Customer currentCustomer = dbContext.Customers.First(c => c.CustomerID == CustomerID);

                dbContext.Entry(currentCustomer).State = EntityState.Deleted;
                dbContext.Customers.Remove(currentCustomer);
                dbContext.SaveChanges();
            }
        }
    }
}
