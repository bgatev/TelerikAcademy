using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string DatabaseHost = "@ds033740.mongolab.com:33740/";
        const string DatabaseName = "telerik";
        
        MongoDatabase db;
        string username = string.Empty;
        DateTime loginDateTime = DateTime.Now;

        public static MongoDatabase GetDatabase(string hostName, string databaseName, string username, string password)
        {
            var connectionString = @"mongodb://" + username + ":" + password + hostName + databaseName;

            var mongoClient = new MongoClient(connectionString);
            var server = mongoClient.GetServer();

            return server.GetDatabase(databaseName);
        }

        public MainWindow()
        {
            InitializeComponent();   
        }

        private void GetAllMessagesBtn_Click(object sender, RoutedEventArgs e)
        {
            var messages = db.GetCollection<Messages>("messages");

            var result = messages.FindAll().Where(m => m.Date < loginDateTime);
            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendLine(string.Format("[{0}] {1} by {2}", item.Date, item.Text, item.User.Username));
            }

            MessageTb.Text = sb.ToString();
        }

        private void AddMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            var message = new Messages(MessageTb.Text, DateTime.Now, new User(username));

            var messages = db.GetCollection<Messages>("messages");

            messages.Insert(message);
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            username = UsernameTb.Text;

            loginDateTime = DateTime.Now;

            string password = username;

            try
            {
                db = GetDatabase(DatabaseHost, DatabaseName, username, password);
                UsernameTb.Text = "Wellcome " + username;
            }
            catch 
            { 

            }
        }
    }
}

public class Messages
{
    public Messages(string messageText, DateTime messageDateTime, User username)
    {
        this.Text = messageText;
        this.Date = messageDateTime;
        this.User = username;
    }

    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Text { get; set; }

    public DateTime Date { get; set; }

    public User User { get; set; }
}

public class User
{
    public User(string username)
    {
        this.Username = username;
    }

    public string Username { get; set; }
}