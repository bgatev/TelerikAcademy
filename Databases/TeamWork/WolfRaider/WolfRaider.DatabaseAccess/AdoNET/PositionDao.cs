namespace WolfRaider.DatabaseAccess.AdoNET
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Commands.Contracts;
    using WolfRaider.DatabaseAccess.Connections.Contracts;
    using WolfRaider.DatabaseAccess.Contracts;
    using WolfRaider.DatabaseAccess.Parameters.Contracts;

    public class PositionDao : CommonDao, IGeneralDao<Position>
    {
        private const string InsertThePositionCannotBeNull = "INSERT: The position cannot be null.";
        private const string InsertThePositionWasNotInserted = "INSERT: The position was not inserted.";

        private const string PositionId = "PositionId";
        private const string PositionIdParam = "@positionId";
        private const string Name = "Name";
        private const string NameParam = "@name";

        private const string InsertEmployeeFortmat = @"INSERT INTO Positions (PositionId, Name) VALUES (@positionId, @name);";

        public PositionDao(IDatabaseConnection databaseConnection, IDatabaseCommandStrategy commandStrategy, IDatabaseParameterStrategy parameterStrategy)
            : base(databaseConnection, commandStrategy, parameterStrategy)
        {
        }

        public void Insert(Position position)
        {
            if (position == null)
            {
                throw new ArgumentException(InsertThePositionCannotBeNull);
            }

            IDbConnection connection = this.DatabaseConnection.GetConnection();

            using (connection)
            {
                connection.Open();
                IDbCommand command = this.CommandStrategy.CreateCommand(InsertEmployeeFortmat, connection);

                IDataParameter parameteEmployeeId = this.ParameterStrategy.CreateParameter(PositionIdParam, position.PositionId.ToString());
                IDataParameter parameterFirstName = this.ParameterStrategy.CreateParameter(NameParam, position.Name);

                command.Parameters.Add(parameteEmployeeId);
                command.Parameters.Add(parameterFirstName);

                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    throw new DbUpdateException(InsertThePositionWasNotInserted);
                }
            }
        }

        public void Delete(Position employee)
        {
            throw new NotImplementedException();
        }

        public void Update(Position employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> Find(Expression<Func<Position, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
