using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    private const string EXCEL_FILE = @"..\..\Score.xlsx;";

    public static void InsertRow(OleDbConnection dbConnection, string name, double score)
    {
        OleDbCommand command = new OleDbCommand("INSERT INTO [Sheet1$] " + "(Name, Score) VALUES " + "(@name, @score)", dbConnection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@score", score);

        command.ExecuteNonQuery();
    }

    public static void Main()
    {
        OleDbConnection excelConnection = new OleDbConnection();
        excelConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + EXCEL_FILE + "Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

        excelConnection.Open();

        using (excelConnection)
        {
            InsertRow(excelConnection, "Bonboncheto", 22);
        }
    }
}

