namespace WolfRaider.DatabaseAccess.MongoDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.Contracts;

    public class EmployeeDaoMongoDB : IGeneralDao<Employee>
    {
        private MongoDataInserter mongoInserter;
        private MongoDataRepository mongoRepository;

        public EmployeeDaoMongoDB()
        {
           this.mongoInserter = new MongoDataInserter();
           this.mongoRepository = new MongoDataRepository();
        }

        public void Insert(Employee employee)
        {
            this.mongoRepository.Employees.Add(employee);
        }

        public void Delete(Employee employee)
        {
            this.mongoRepository.Employees.Delete(employee);
        }

        public void Update(Employee employee)
        {
            this.mongoRepository.Employees.Update(employee);
        }

        public IEnumerable<Employee> ListAll()
        {
            return this.mongoRepository.Employees.Select(x => x);
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> condition)
        {
            return this.mongoRepository.Employees.Where(condition);
        }
    }
}
