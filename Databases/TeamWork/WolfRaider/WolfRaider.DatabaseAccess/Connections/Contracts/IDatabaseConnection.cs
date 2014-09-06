namespace WolfRaider.DatabaseAccess.Connections.Contracts
{
    using System.Data;

    public interface IDatabaseConnection
    {
        IDbConnection GetConnection();
    }
}