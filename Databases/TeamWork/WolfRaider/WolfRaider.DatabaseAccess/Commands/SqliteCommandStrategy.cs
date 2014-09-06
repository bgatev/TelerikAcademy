namespace WolfRaider.DatabaseAccess.Commands
{
    using System.Data;
    using System.Data.SQLite;
    using WolfRaider.DatabaseAccess.Commands.Contracts;

    public class SqliteCommandStrategy : IDatabaseCommandStrategy
    {
        public IDbCommand CreateCommand(string query, IDbConnection connection)
        {
            SQLiteConnection connectionSqlite = (SQLiteConnection)connection;
            SQLiteCommand command = new SQLiteCommand(query, connectionSqlite);
            return command;
        }
    }
}
