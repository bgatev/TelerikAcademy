using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    private const string EXCEL_FILE =  @"..\..\Score.xlsx;";

    public static void Main()
    {
        OleDbConnection excelConnection = new OleDbConnection();
        excelConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + EXCEL_FILE + "Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

        excelConnection.Open();

        using (excelConnection)
        {
            OleDbCommand command = new OleDbCommand("Select * From [Sheet1$]", excelConnection);
            OleDbDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];

                    Console.WriteLine("{0} -> {1}", name, score);
                }
            }
        }
    }
}

