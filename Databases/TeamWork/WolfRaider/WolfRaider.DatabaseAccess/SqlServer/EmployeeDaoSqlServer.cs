namespace WolfRaider.DatabaseAccess.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    using WolfRaider.Common.Config;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.Contracts;

    public class EmployeeDaoSqlServer : IGeneralDao<Employee>, IDisposable
    {
        private readonly WolfRaiderContext context;

        public EmployeeDaoSqlServer()
        {
            this.context = new WolfRaiderContext();
        }

        public void Insert(Employee data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Employee));
                throw new ArgumentException(message);
            }

            this.context.Employees.Add(data);
            int affectedRows = this.context.SaveChanges();

            if (affectedRows == 0)
            {
                string message = string.Format(ExceptionMessage.InsertFailedFormat, this.GetType(), typeof(Employee));
                throw new DbUpdateException(message);
            }
        }

        public void Delete(Employee data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Employee));
                throw new ArgumentException(message);
            }

            Employee existing = this.context.Employees.First(x => x.EmployeeId == data.EmployeeId);
            this.context.Employees.Remove(existing);
            int affectedRows = this.context.SaveChanges();

            if (affectedRows == 0)
            {
                string message = string.Format(ExceptionMessage.DeleteFailedFormat, this.GetType(), typeof(Employee));
                throw new DbUpdateException(message);
            }
        }

        public void Update(Employee data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Employee));
                throw new ArgumentException(message);
            }

            Employee existing = this.context.Employees.First(x => x.EmployeeId == data.EmployeeId);

            existing.FirstName = data.FirstName;
            existing.LastName = data.LastName;
            existing.Age = data.Age;
            existing.ManagerId = existing.ManagerId;
            existing.ManagedEmployees = data.ManagedEmployees;

            int affectedRows = this.context.SaveChanges();

            if (affectedRows == 0)
            {
                string message = string.Format(ExceptionMessage.UpdateFailedFormat, this.GetType(), typeof(Employee));
                throw new DbUpdateException(message);
            }
        }

        public IEnumerable<Employee> ListAll()
        {
            var list = this.context.Employees.ToList();
            return list;
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> condition)
        {
            var list = this.context.Employees.Where(condition).ToList();
            return list;
        }

        public void Dispose()
        {
            this.context.Database.Connection.Close();
        }
    }
}
