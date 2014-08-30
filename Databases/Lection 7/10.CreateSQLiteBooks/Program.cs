using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void ListAllBooks(SQLiteConnection dbConnection)
    {
        dbConnection.Open();

        using (dbConnection)
        {
            SQLiteCommand command = new SQLiteCommand("Use BooksDB; Select * From Books", dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string title = (string)reader["title"];
                    string author = (string)reader["author"];
                    DateTime publishDate = (DateTime)reader["publishDate"];
                    string ISBN = (string)reader["ISBN"];

                    Console.WriteLine("{0} - {1} published on {2} as {3} ", title, author, publishDate, ISBN);
                }
            }
        }

        dbConnection.Close();
    }

    public static void FindBook(SQLiteConnection dbConnection, string name)
    {
        dbConnection.Open();

        using (dbConnection)
        {
            string findBookStatement = "Use BooksDB; Select * From Books Where title = '" + name + "'";
            SQLiteCommand command = new SQLiteCommand(findBookStatement, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string title = (string)reader["title"];
                    string author = (string)reader["author"];
                    DateTime publishDate = (DateTime)reader["publishDate"];
                    string ISBN = (string)reader["ISBN"];

                    Console.WriteLine("{0} - {1} published on {2} as {3} ", title, author, publishDate, ISBN);
                }
            }
        }

        dbConnection.Close();
    }

    public static void AddBook(SQLiteConnection dbConnection, string title, string author, DateTime publishDate, string ISBN)
    {
        dbConnection.Open();

        using (dbConnection) 
        {
            string formattedDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", publishDate);
            string insertTableRow = "Use BooksDB; Insert Into Books (title, author, publishDate, ISBN) Values ('" + title + "', '" + author + "', '" + formattedDate + "', '" + ISBN + "')";

            SQLiteCommand insertCommand = new SQLiteCommand(insertTableRow, dbConnection);
            insertCommand.ExecuteNonQuery();
        }

        dbConnection.Close();
    }

    public static void Main()
    {
        SQLiteConnection books = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");

        books.Open();

        using (books)
        {
            string createTableSQL = "CREATE DATABASE IF NOT EXISTS BooksDB; Use BooksDB; Create table Books (title text, author text, publishDate text, ISBN text)";

            SQLiteCommand createCommand = new SQLiteCommand(createTableSQL, books);
            createCommand.ExecuteNonQuery();     

            books.Close();
        }

        AddBook(books, "Me", "Ivan Vazov", DateTime.Now, "123456789");
        AddBook(books, "Boat", "Pencho Slaveikov", DateTime.Now, "345345678");
        AddBook(books, "Human", "Petko Slaveikov", DateTime.Now, "123432345");
        AddBook(books, "Sun", "Hristo Botev", DateTime.Now, "987456284");

        ListAllBooks(books);
        FindBook(books, "Me");
    }
}

