namespace WolfRaider.DatabaseAccess.Parameters
{
    using System;
    using System.Data;
    using System.Data.SQLite;
    using WolfRaider.DatabaseAccess.Parameters.Contracts;

    public class SqliteParameterStrategy : IDatabaseParameterStrategy
    {
        public IDataParameter CreateParameter(string parameterName, string parameterValue)
        {
            IDataParameter parameter = new SQLiteParameter { ParameterName = parameterName, Value = parameterValue };
            return parameter;
        }

        public IDataParameter CreateParameter(string parameterName, DBNull parameterValue)
        {
            IDataParameter parameter = new SQLiteParameter { ParameterName = parameterName, Value = parameterValue };
            return parameter;
        }

        public IDataParameter CreateParameter(string parameterName, int parameterValue)
        {
            IDataParameter parameter = new SQLiteParameter { ParameterName = parameterName, Value = parameterValue.ToString() };
            return parameter;
        }
    }
}
