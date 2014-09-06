namespace WolfRaider.DatabaseAccess.Connections.Contracts
{
    using System.Data.Entity.Infrastructure;

    public interface IDatabaseContext
    {
        IObjectContextAdapter GetContext();
    }
}
