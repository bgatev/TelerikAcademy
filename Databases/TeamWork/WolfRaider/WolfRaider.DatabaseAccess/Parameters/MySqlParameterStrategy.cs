namespace WolfRaider.DatabaseAccess.Parameters
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using WolfRaider.DatabaseAccess.Parameters.Contracts;

    public class MySqlParameterStrategy : IDatabaseParameterStrategy
    {
        public IDataParameter CreateParameter(string parameterName, string parameterValue)
        {
            return new MySqlParameter() { ParameterName = parameterName, Value = parameterValue };
        }

        public IDataParameter CreateParameter(string parameterName, DBNull parameterValue)
        {
            return new MySqlParameter() { ParameterName = parameterName, Value = parameterValue };
        }

        public IDataParameter CreateParameter(string parameterName, int parameterValue)
        {
            return new MySqlParameter() { ParameterName = parameterName, Value = parameterValue };
        }
    }
}
