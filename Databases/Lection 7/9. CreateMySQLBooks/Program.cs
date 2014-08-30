using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Globalization;

public class Program
{
    public static void ListAllBooks(MySqlConnection dbConnection)
    {
        dbConnection.Open();

        using (dbConnection)
        {
            MySqlCommand command = new MySqlCommand("Use BooksDB; Select * From Books", dbConnection);
            MySqlDataReader reader = command.ExecuteReader();

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

    public static void FindBook(MySqlConnection dbConnection, string name)
    {
        dbConnection.Open();

        using (dbConnection)
        {
            string findBookStatement = "Use BooksDB; Select * From Books Where title = '" + name + "'";
            MySqlCommand command = new MySqlCommand(findBookStatement, dbConnection);
            MySqlDataReader reader = command.ExecuteReader();

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

    public static void AddBook(MySqlConnection dbConnection, string title, string author, DateTime publishDate, string ISBN)
    {
        dbConnection.Open();

        using (dbConnection)
        {
            string formattedDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", publishDate);
            string insertTableRow = "Use BooksDB; Insert Into Books (title, author, publishDate, ISBN) Values ('" + title + "', '" + author + "', '" + formattedDate + "', '" + ISBN + "')";

            MySqlCommand insertCommand = new MySqlCommand(insertTableRow, dbConnection);
            insertCommand.ExecuteNonQuery();
        }

        dbConnection.Close();
    }

    public static void Main()
    {
        MySqlConnection books = new MySqlConnection();

        Console.Write("Enter root password: ");
        string mySqlRootPassword = Console.ReadLine();
        string connectionString = "Server=localhost" + ";Uid=root" + ";Pwd=" + mySqlRootPassword + ";";
        
        books.ConnectionString = connectionString;
        
        books.Open();

        //Apply Only Once
        using (books)
        {
            string createTableSQL = "CREATE DATABASE IF NOT EXISTS BooksDB; Use BooksDB; Create table Books (title varchar(50), author varchar(50), publishDate datetime, ISBN varchar(10))";

            MySqlCommand createCommand = new MySqlCommand(createTableSQL, books);
            createCommand.ExecuteNonQuery();
        }

        books.Close();

        AddBook(books, "Me", "Ivan Vazov", DateTime.Now, "823456789");
        AddBook(books, "Boat", "Pencho Slaveikov", DateTime.Now, "345345678");
        AddBook(books, "Human", "Petko Slaveikov", DateTime.Now, "123432345");
        AddBook(books, "Sun", "Hristo Botev", DateTime.Now, "987456284");

        ListAllBooks(books);
        FindBook(books, "Me");
    }
}

