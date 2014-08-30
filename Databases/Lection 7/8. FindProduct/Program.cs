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

        string input = Console.ReadLine();
        
        northWindDB.Open();

        using (northWindDB)
        {
            SqlCommand command = new SqlCommand("Select ProductName From Products", northWindDB);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string productName = (string)reader["ProductName"];
                    int index = productName.IndexOf(input);
                    if (index != -1) Console.WriteLine("{0}", productName);
                }
            }

        }
    }
}

