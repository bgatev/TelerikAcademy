namespace WolfRaider.DatabaseAccess.Commands
{
    using System.Data;

    using MySql.Data.MySqlClient;
    using WolfRaider.DatabaseAccess.Commands.Contracts;

    public class MySqlCommandStategy : IDatabaseCommandStrategy
    {
        public IDbCommand CreateCommand(string query, IDbConnection connection)
        {
            MySqlConnection sqlConnection = (MySqlConnection)connection;
            MySqlCommand command = new MySqlCommand(query, sqlConnection);
            return command;
        }
    }
}
