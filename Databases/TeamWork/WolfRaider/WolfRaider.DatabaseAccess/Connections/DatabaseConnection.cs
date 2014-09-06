namespace WolfRaider.DatabaseAccess.Connections
{
    public abstract class DatabaseConnection 
    {
        protected DatabaseConnection(string server, string port, string user, string password, string databaseName)
        {
            this.Server = server;
            this.Port = port;
            this.User = user;
            this.Password = password;
            this.DatabaseName = databaseName;
        }

        protected string Server { get; private set; }

        protected string User { get; private set; }

        protected string Port { get; private set; }

        protected string Password { get; private set; }

        protected object DatabaseName { get; private set; }

        protected abstract string ConnectionString { get; }
    }
}
