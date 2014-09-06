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

    public class NationalityDaoSqlServer : IGeneralDao<Nationality>
    {
        public void Insert(Nationality data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Nationality));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                context.Nationalities.Add(data);
                int affectedRowns = context.SaveChanges();

                if (affectedRowns == 0)
                {
                    string message = string.Format(ExceptionMessage.InsertFailedFormat, this.GetType(), typeof(Nationality));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Delete(Nationality data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Nationality));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                Nationality existing = context.Nationalities.First(x => x.NationalityId == data.NationalityId);
                context.Nationalities.Remove(existing);
                int affectedRows = context.SaveChanges();

                if (affectedRows == 0)
                {
                    string message = string.Format(ExceptionMessage.DeleteFailedFormat, this.GetType(), typeof(Nationality));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Update(Nationality nationality)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nationality> ListAll()
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Nationalities.ToList();
                return list;
            }
        }

        public IEnumerable<Nationality> Find(Expression<Func<Nationality, bool>> condition)
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Nationalities.Where(condition).ToList();
                return list;
            }
        }
    }
}
