namespace WolfRaider.DatabaseAccess.AdoNET
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Contracts;

    public class SquadHistoryDao : IGeneralDao<SquadHistory>
    {
        public void Insert(SquadHistory employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(SquadHistory employee)
        {
            throw new NotImplementedException();
        }

        public void Update(SquadHistory employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SquadHistory> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SquadHistory> Find(Expression<Func<SquadHistory, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
