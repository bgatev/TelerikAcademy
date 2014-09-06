namespace WolfRaider.DatabaseAccess.Connections
{
    using System.Data.Entity.Infrastructure;
    using WolfRaider.DatabaseAccess.Connections.Contracts;

    public class SqlServerDatabaseConnection : IDatabaseContext
    {
        private IObjectContextAdapter context;

        public SqlServerDatabaseConnection()
            : this(new WolfRaiderContext())
        {
        }

        public SqlServerDatabaseConnection(IObjectContextAdapter context)
        {
            this.context = context;
        }

        public IObjectContextAdapter GetContext()
        {
            return this.context;
        }
    }
}
