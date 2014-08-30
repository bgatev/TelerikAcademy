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

        using(northWindDB)
        {
            SqlCommand command = new SqlCommand("Select Count(*) From Categories", northWindDB);
            int categoriesCount = (int)command.ExecuteScalar();
            Console.WriteLine("Categories count: {0} ", categoriesCount);
        }
    }
}

