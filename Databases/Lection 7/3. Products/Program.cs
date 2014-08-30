using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        SqlConnection northWindDB = new SqlConnection();
        northWindDB.ConnectionString = "Server=localhost; Database=Northwind; Integrated Security=true";

        northWindDB.Open();

        using (northWindDB)
        {
            SqlCommand command = new SqlCommand("Select Categories.CategoryName, Products.ProductName From Categories Inner Join Products On Categories.CategoryID = Products.CategoryID Order by Categories.CategoryName", northWindDB);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0} -> {1}", categoryName, productName);
                }
            }

        }
    }
}

