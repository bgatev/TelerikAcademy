namespace WolfRaider.DatabaseAccess.AdoNET
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Contracts;

    public class GameDaoSql : IGeneralDao<Game>
    {
        public void Insert(Game employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(Game employee)
        {
            throw new NotImplementedException();
        }

        public void Update(Game employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> Find(Expression<Func<Game, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
