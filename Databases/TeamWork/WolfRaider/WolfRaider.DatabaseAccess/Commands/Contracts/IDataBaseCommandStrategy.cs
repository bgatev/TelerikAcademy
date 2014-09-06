namespace WolfRaider.DatabaseAccess.Commands.Contracts
{
    using System.Data;

    public interface IDatabaseCommandStrategy
    {
        IDbCommand CreateCommand(string query, IDbConnection connection);
    }
}
