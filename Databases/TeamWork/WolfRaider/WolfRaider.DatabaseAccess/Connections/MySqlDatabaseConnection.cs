namespace WolfRaider.DatabaseAccess.Connections
{
    using System.Data;
    using MySql.Data.MySqlClient;
    using WolfRaider.DatabaseAccess.Connections.Contracts;

    public class MySqlDatabaseConnection : DatabaseConnection, IDatabaseConnection
    {
        private const string MySqlServer = "localhost";
        private const string MySqlPort = "3306";
        private const string MySqlUser = "root1";
        private const string MySqlPassword = "password";
        private const string MySqlDatabaseName = "WolfRaider";

        public MySqlDatabaseConnection()
            : this(MySqlServer, MySqlPort, MySqlUser, MySqlPassword, MySqlDatabaseName)
        {
        }

        public MySqlDatabaseConnection(string server, string port, string user, string password, string databaseName)
            : base(server, port, user, password, databaseName)
        {
        }

        protected override string ConnectionString
        {
            get
            {
                string result = string.Format("Server={0}; Port={1}; Uid={2}; Pwd={3}; pooling=true; Database={4}", this.Server, this.Port, this.User, this.Password, this.DatabaseName);
                return result;
            }
        }

        public IDbConnection GetConnection()
        {
            var connection = new MySqlConnection(this.ConnectionString);
            return connection;
        }
    }
}