using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void InsertNorthWindProduct(SqlConnection dbConnection, string productName, int? supplierID, int? categoryID, string quantityPerUnit, double? unitPrice, int? unitsInStock, int? unitsOnOrder, int? reorderLevel, bool discontinued)
    {
        SqlCommand command = new SqlCommand("INSERT INTO Products " +
          "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES " +
          "(@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", dbConnection);
        command.Parameters.AddWithValue("@productName", productName);
        command.Parameters.AddWithValue("@supplierID", supplierID);
        command.Parameters.AddWithValue("@categoryID", categoryID);
        command.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
        command.Parameters.AddWithValue("@unitPrice", unitPrice);
        command.Parameters.AddWithValue("@unitsInStock", unitsInStock);
        command.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
        command.Parameters.AddWithValue("@reorderLevel", reorderLevel);

        SqlParameter sqlParameterDiscontinued = new SqlParameter("@discontinued", discontinued);
        if (discontinued) sqlParameterDiscontinued.Value = "True";
        else sqlParameterDiscontinued.Value = "False";
        command.Parameters.Add(sqlParameterDiscontinued);

        command.ExecuteNonQuery();
    }


    public static void Main()
    {
        SqlConnection northWindDB = new SqlConnection();
        northWindDB.ConnectionString = "Server=localhost; Database=Northwind; Integrated Security=true";

        northWindDB.Open();

        using (northWindDB)
        {
            InsertNorthWindProduct(northWindDB, "Green Tea",1 ,1, "10 boxes x 20 bags", 23, 100, 20, 20, false);
        }
    }
}

