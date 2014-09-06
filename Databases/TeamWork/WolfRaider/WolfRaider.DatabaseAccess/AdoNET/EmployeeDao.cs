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

    public class EmployeeDao : CommonDao, IGeneralDao<Employee>
    {
        private const string EmployeeId = "EmployeeId";
        private const string EmployeeIdParam = "@employeeId";
        private const string FirstName = "FirstName";
        private const string FirstNameParam = "@firstName";
        private const string LastName = "LastName";
        private const string LastNameParam = "@lastName";
        private const string Age = "Age";
        private const string AgeParam = "@age";
        private const string ManagerId = "ManagerId";
        private const string ManagerIdParam = "@managerId";

        private const string InsertEmployeeFortmat = @"INSERT INTO Employees (EmployeeId, FirstName, LastName, Age, ManagerId) VALUES (@employeeId, @firstName, @lastName, @age, @managerId);";

        private const string UpdateEmployee = "UPDATE Employees SET FirstName= @firstName, LastName= @lastName , Age= @age , ManagerId = @managerId WHERE EmployeeId=@employeeId";

        private const string DeleteEmployee = "DELETE FROM Employees WHERE EmployeeId= @id ";
        private const string ListAllEmployees = "SELECT * FROM Employees";

        private static readonly Type EmployeeType = typeof(Employee);

        public EmployeeDao(IDatabaseConnection databaseConnection, IDatabaseCommandStrategy commandStrategy, IDatabaseParameterStrategy parameterStrategy)
            : base(databaseConnection, commandStrategy, parameterStrategy)
        {
        }

        public void Insert(Employee employee)
        {
            if (employee == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Employee));
                throw new ArgumentException(message);
            }

            IDbConnection connection = this.DatabaseConnection.GetConnection();

            using (connection)
            {
                connection.Open();
                IDbCommand command = this.CommandStrategy.CreateCommand(InsertEmployeeFortmat, connection);

                IDataParameter parameteEmployeeId = this.ParameterStrategy.CreateParameter(EmployeeIdParam, employee.EmployeeId.ToString());
                IDataParameter parameterFirstName = this.ParameterStrategy.CreateParameter(FirstNameParam, employee.FirstName);
                IDataParameter parameterLastName = this.ParameterStrategy.CreateParameter(LastNameParam, employee.LastName);
                IDataParameter parameterAge = this.ParameterStrategy.CreateParameter(AgeParam, employee.Age.ToString());
                IDataParameter parameterManager;

                if (employee.ManagerId == null)
                {
                    parameterManager = this.ParameterStrategy.CreateParameter(ManagerIdParam, DBNull.Value);
                }
                else
                {
                    parameterManager = this.ParameterStrategy.CreateParameter(ManagerIdParam, employee.ManagerId.ToString());
                }

                command.Parameters.Add(parameteEmployeeId);
                command.Parameters.Add(parameterFirstName);
                command.Parameters.Add(parameterLastName);
                command.Parameters.Add(parameterAge);
                command.Parameters.Add(parameterManager);

                int affectedRows = command.ExecuteNonQuery();
                this.CheckAffectedRows(affectedRows, this.GetType(), EmployeeType, ExceptionMessage.InsertFailedFormat);
            }
        }

        public void Delete(Employee employee)
        {
            if (employee == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Employee));
                throw new ArgumentException(message);
            }

            IDbConnection connection = this.DatabaseConnection.GetConnection();
            connection.Open();

            using (connection)
            {
                IDbCommand command = this.CommandStrategy.CreateCommand(DeleteEmployee, connection);
                int affectedRows = command.ExecuteNonQuery();
                this.CheckAffectedRows(affectedRows, this.GetType(), EmployeeType, ExceptionMessage.DeleteFailedFormat);
            }
        }

        public void Update(Employee employee)
        {
            if (employee == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Employee));
                throw new ArgumentException(message);
            }

            IDbConnection connection = this.DatabaseConnection.GetConnection();
            connection.Open();

            using (connection)
            {
                IDbCommand command = this.CommandStrategy.CreateCommand(UpdateEmployee, connection);
                int affectedRows = command.ExecuteNonQuery();
                this.CheckAffectedRows(affectedRows, this.GetType(), EmployeeType, ExceptionMessage.UpdateFailedFormat);
            }
        }

        public IEnumerable<Employee> ListAll()
        {
            IDbConnection connection = this.DatabaseConnection.GetConnection();
            connection.Open();

            ICollection<Employee> employees = new List<Employee>();

            using (connection)
            {
                IDbCommand command = this.CommandStrategy.CreateCommand(ListAllEmployees, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = this.MapEmployee(reader);
                    employees.Add(employee);
                }
            }

            return employees;
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> condition)
        {
            throw new NotImplementedException();
        }

        private Employee MapEmployee(IDataReader reader)
        {
            Guid employeeId = new Guid((string)reader[EmployeeId]);
            string firstName = (string)reader[FirstName];
            string lastName = (string)reader[LastName];
            int age = (int)reader[Age];

            Guid? managerId;
            if (reader[ManagerId] is DBNull)
            {
                managerId = null;
            }
            else
            {
                managerId = new Guid((string)reader[ManagerId]);
            }

            Employee employee = new Employee(employeeId, firstName, lastName, age, managerId);
            return employee;
        }
    }
}
