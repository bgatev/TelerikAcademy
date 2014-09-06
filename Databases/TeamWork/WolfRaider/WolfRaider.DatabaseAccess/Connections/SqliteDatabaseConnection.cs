namespace WolfRaider.DatabaseAccess.Connections
{
    using System.Data;
    using System.Data.SQLite;
    using WolfRaider.DatabaseAccess.Connections.Contracts;

    public class SqliteDatabaseConnection : DatabaseConnection, IDatabaseConnection
    {
        private const string ConnectionFormat = "Data Source={0};Version=3;New=True;Compress=True;";
        private const string SqliteDataBase = "wolfraider.sqlite";

        public SqliteDatabaseConnection()
            : this(SqliteDataBase)
        {
        }

        public SqliteDatabaseConnection(string databaseName)
            : base(null, null, null, null, databaseName)
        {
        }

        protected override string ConnectionString
        {
            get
            {
                string result = string.Format(ConnectionFormat, this.DatabaseName);
                return result;
            }
        }

        public IDbConnection GetConnection()
        {
            IDbConnection connection = new SQLiteConnection(this.ConnectionString);
            return connection;
        }
    }
}
