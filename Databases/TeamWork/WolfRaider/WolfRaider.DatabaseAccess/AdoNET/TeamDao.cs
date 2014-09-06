namespace WolfRaider.DatabaseAccess.AdoNET
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Contracts;

    public class TeamDao : IGeneralDao<Team>
    {
        public void Insert(Team employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(Team employee)
        {
            throw new NotImplementedException();
        }

        public void Update(Team employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> Find(Expression<Func<Team, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
