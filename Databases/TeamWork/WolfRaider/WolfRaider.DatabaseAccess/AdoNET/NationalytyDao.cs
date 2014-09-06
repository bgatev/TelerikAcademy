namespace WolfRaider.DatabaseAccess.AdoNET
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq.Expressions;

    using WolfRaider.Common.Config;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Commands.Contracts;
    using WolfRaider.DatabaseAccess.Connections.Contracts;
    using WolfRaider.DatabaseAccess.Contracts;
    using WolfRaider.DatabaseAccess.Parameters.Contracts;

    public class NationalytyDao : CommonDao, IGeneralDao<Nationality>
    {
        private const string PositionId = "PositionId";
        private const string PositionIdParam = "@positionId";
        private const string Name = "Name";
        private const string NameParam = "@name";

        private const string InsertEmployeeFortmat = @"INSERT INTO Positions (PositionId, Name) VALUES (@positionId, @name);";
        private const string ListAllNationalities = @"SELECT * FROM Nationalities";
        private static readonly Type NationalityType = typeof(Nationality);

        public NationalytyDao(IDatabaseConnection databaseConnection, IDatabaseCommandStrategy commandStrategy, IDatabaseParameterStrategy parameterStrategy)
            : base(databaseConnection, commandStrategy, parameterStrategy)
        {
        }

        public void Insert(Nationality nationality)
        {
            if (nationality == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, NationalityType);
                throw new ArgumentException(message);
            }

            IDbConnection connection = this.DatabaseConnection.GetConnection();
            connection.Open();

            using (connection)
            {
                IDbCommand command = this.CommandStrategy.CreateCommand(InsertEmployeeFortmat, connection);

                IDataParameter parameteEmployeeId = this.ParameterStrategy.CreateParameter(PositionIdParam, nationality.NationalityId.ToString());
                IDataParameter parameterFirstName = this.ParameterStrategy.CreateParameter(NameParam, nationality.Name);

                command.Parameters.Add(parameteEmployeeId);
                command.Parameters.Add(parameterFirstName);

                int affectedRows = command.ExecuteNonQuery();
                this.CheckAffectedRows(affectedRows, this.GetType(), NationalityType, ExceptionMessage.InsertFailedFormat);
            }
        }

        public void Delete(Nationality nationality)
        {
            throw new NotImplementedException();
        }

        public void Update(Nationality nationality)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nationality> ListAll()
        {
            IDbConnection connection = this.DatabaseConnection.GetConnection();
            connection.Open();

            ICollection<Nationality> employees = new List<Nationality>();

            using (connection)
            {
                IDbCommand command = this.CommandStrategy.CreateCommand(ListAllNationalities, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Nationality nationality = this.MapNationality(reader);
                    employees.Add(nationality);
                }
            }

            return employees;
        }

        public IEnumerable<Nationality> Find(Expression<Func<Nationality, bool>> condition)
        {
            throw new NotImplementedException();
        }

        private Nationality MapNationality(IDataReader reader)
        {
            Guid id = (Guid)reader["NationalityId"];
            string name = (string)reader["Name"];

            Nationality nationality = new Nationality(id, name);
            return nationality;
        }
    }
}
