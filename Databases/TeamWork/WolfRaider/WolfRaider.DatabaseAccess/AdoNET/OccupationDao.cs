namespace WolfRaider.DatabaseAccess.AdoNET
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Contracts;

    public class OccupationDao : IGeneralDao<Occupation>
    {
        public void Insert(Occupation employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(Occupation employee)
        {
            throw new NotImplementedException();
        }

        public void Update(Occupation employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Occupation> ListAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Occupation> Find(Expression<Func<Occupation, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
