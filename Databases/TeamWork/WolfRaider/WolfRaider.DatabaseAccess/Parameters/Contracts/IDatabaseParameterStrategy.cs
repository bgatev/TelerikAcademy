namespace WolfRaider.DatabaseAccess.Parameters.Contracts
{
    using System;
    using System.Data;

    public interface IDatabaseParameterStrategy
    {
        IDataParameter CreateParameter(string parameterName, string parameterValue);

        IDataParameter CreateParameter(string parameterName, DBNull parameterValue);

        IDataParameter CreateParameter(string parameterName, int parameterValue);
    }
}
