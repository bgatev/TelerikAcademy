namespace WolfRaider.DatabaseAccess.AdoNET
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Contracts;

    public class WorkHistoryDaoMySql : IGeneralDao<WorkHistory>
    {
        public void Insert(WorkHistory employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(WorkHistory employee)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkHistory employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkHistory> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkHistory> Find(Expression<Func<WorkHistory, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
