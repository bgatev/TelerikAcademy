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

    public class OccupationDaoSqlServer : IGeneralDao<Occupation>
    {
        public void Insert(Occupation data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Occupation data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Occupation));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                Occupation existing = context.Occupations.First(x => x.OccupationId == data.OccupationId);
                context.Occupations.Remove(existing);
                int affectedRows = context.SaveChanges();

                if (affectedRows == 0)
                {
                    string message = string.Format(ExceptionMessage.DeleteFailedFormat, this.GetType(), typeof(Occupation));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Update(Occupation data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Occupation> ListAll()
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Occupations.ToList();
                return list;
            }
        }

        public IEnumerable<Occupation> Find(Expression<Func<Occupation, bool>> condition)
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Occupations.Where(condition).ToList();
                return list;
            }
        }
    }
}
