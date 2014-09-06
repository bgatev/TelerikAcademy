using MongoDB.Driver;

namespace WolfRaider.DatabaseAccess.Connections
{
    public class MongoDataInserter
    {
        private const string MongoServer = "mongodb://localhost/";
        private const string DatabaseName = "WolfRaider";

        private MongoDatabase database;        

        public MongoDataInserter()
        {
            var connection = new MongoClient(MongoServer);
            var server = connection.GetServer();
            this.database = server.GetDatabase(DatabaseName);
        }

        public MongoDatabase Database
        {
            get { return this.database; }
            set { this.database = value; }
        }
    }
}
