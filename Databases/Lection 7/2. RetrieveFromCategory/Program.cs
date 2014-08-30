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
            SqlCommand command = new SqlCommand("Select CategoryName, Description From Categories", northWindDB);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("{0} -> {1}", categoryName, description);
                }
            }

        }
    }
}

