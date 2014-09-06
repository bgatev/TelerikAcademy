namespace NorthwindDataModel.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using System.Data.Entity;
    using System.Transactions;

    using NorthwindDataModel.Data;

    public class DataAccessObjectsOrders
    {
        public static void AddOrder(string ShipName, string ShipCity, List<Order_Detail> allItems)
        {
            Northwind dbContext = new Northwind();
            Northwind dbContext2 = new Northwind();

            using (dbContext)
            {
                TransactionScope currentTransaction = new TransactionScope();

                using (currentTransaction)
                {
                    Order currentOrder = new Order();

                    currentOrder.ShipName = ShipName;
                    currentOrder.ShipCity = ShipCity;

                    dbContext.Orders.Add(currentOrder);
                    dbContext.SaveChanges();
                    
                    int insertedID = currentOrder.OrderID;

                    var currentOrderAllDetails = dbContext.Orders.Where(o => o.OrderID == insertedID);
                    
                    using (dbContext2)
                    {
                        foreach (var item in allItems)
                        {
                            Order_Detail currentDetail = new Order_Detail
                            {
                                OrderID = insertedID,
                                ProductID = item.ProductID,
                                UnitPrice = item.UnitPrice,
                                Quantity = item.Quantity,
                                Discount = item.Discount
                            };

                            dbContext2.Order_Details.Add(currentDetail);
                            dbContext2.SaveChanges();
                        }
                    }

                    currentTransaction.Complete();
                }
            }
        }
    }
}
