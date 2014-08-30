using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    private static SQLiteConnection books = null;

    public static void ListAllBooks()
    {
        SQLiteCommand command = new SQLiteCommand("Select * From Books", books);
        SQLiteDataReader reader = command.ExecuteReader();

        using (reader)
        {
            while (reader.Read())
            {
                string title = (string)reader["title"];
                string author = (string)reader["author"];
                var publishDate = reader["publishDate"];
                string ISBN = (string)reader["ISBN"];

                Console.WriteLine("{0} - {1} published on {2} as {3} ", title, author, publishDate, ISBN);
            }
        }
    }

    public static void FindBook(string name)
    {
        string findBookStatement = "Select * From Books Where title = '" + name + "'";
        SQLiteCommand command = new SQLiteCommand(findBookStatement, books);
        SQLiteDataReader reader = command.ExecuteReader();

        using (reader)
        {
            while (reader.Read())
            {
                string title = (string)reader["title"];
                string author = (string)reader["author"];
                var publishDate = reader["publishDate"];
                string ISBN = (string)reader["ISBN"];

                Console.WriteLine("{0} - {1} published on {2} as {3} ", title, author, publishDate, ISBN);
            }
        }
    }

    public static void AddBook(string title, string author, DateTime publishDate, string ISBN)
    {
        string formattedDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", publishDate);
        string insertTableRow = "Insert Into Books (title, author, publishDate, ISBN) Values ('" + title + "', '" + author + "', '" + formattedDate + "', '" + ISBN + "')";

        SQLiteCommand insertCommand = new SQLiteCommand(insertTableRow, books);
        insertCommand.ExecuteNonQuery();
    }

    public static void Main()
    {
        books = new SQLiteConnection("Data Source=../../books.sqlite;Version=3;New=True;");

        books.Open();

        using (books)
        {
            //Start Once
            /*string createTableSQL = "Create table Books (title text, author text, publishDate text, ISBN text)";

            SQLiteCommand createCommand = new SQLiteCommand(createTableSQL, books);
            createCommand.ExecuteNonQuery();*/

            AddBook("Me", "Ivan Vazov", DateTime.Now, "123456789");
            AddBook("Boat", "Pencho Slaveikov", DateTime.Now, "345345678");
            AddBook("Human", "Petko Slaveikov", DateTime.Now, "123432345");
            AddBook("Sun", "Hristo Botev", DateTime.Now, "987456284");

            ListAllBooks();
            FindBook("Me");

            books.Close();
        }
    }
}