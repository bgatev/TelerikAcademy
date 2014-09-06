using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class Program
    {
        const string DatabaseHost = "@ds033740.mongolab.com:33740/";
        const string DatabaseName = "telerik";

        static MongoDatabase GetDatabase(string hostName, string databaseName, string username, string password)
        {
            var connectionString = @"mongodb://" + username + ":" + password + hostName + databaseName;

            var mongoClient = new MongoClient(connectionString);
            var server = mongoClient.GetServer();

            return server.GetDatabase(databaseName);
        }

        public static void Main()
        {
            Console.Write("Input Username:");
            string username = Console.ReadLine();

            DateTime loginDateTime = DateTime.Now;
            Console.WriteLine(loginDateTime);

            string password = username;

            var db = GetDatabase(DatabaseHost, DatabaseName, username, password);

            GetAllMessages(db, loginDateTime);

            string messageToPublish = string.Format("This is My Message {0}", loginDateTime.Minute);
            var message = new Messages(messageToPublish, DateTime.Now, new User(username));

            AddMessage(db, message);

            GetAllMessages(db, loginDateTime);
        }

        public static void GetAllMessages(MongoDatabase db, DateTime loginDateTime)
        {
            var messages = db.GetCollection<Messages>("messages");

            var result = messages.FindAll().Where(m => m.Date < loginDateTime);

            foreach (var item in result)
            {
                Console.WriteLine("[{0}] {1} by {2}", item.Date, item.Text, item.User.Username);
            }

            Console.WriteLine("---------------------------------------------------------");
        }

        public static void AddMessage(MongoDatabase db, Messages message)
        {
            var messages = db.GetCollection<Messages>("messages");

            messages.Insert(message);
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
}
