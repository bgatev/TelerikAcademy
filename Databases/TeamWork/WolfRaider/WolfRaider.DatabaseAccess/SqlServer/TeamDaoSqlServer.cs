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

    public class TeamDaoSqlServer : IGeneralDao<Team>
    {
        public void Insert(Team data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Team));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                context.Teams.Add(data);
                int affectedRowns = context.SaveChanges();

                if (affectedRowns == 0)
                {
                    string message = string.Format(ExceptionMessage.InsertFailedFormat, this.GetType(), typeof(Team));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Delete(Team data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Team));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                Team existing = context.Teams.First(x => x.TeamId == data.TeamId);
                context.Teams.Remove(existing);

                int affectedRows = context.SaveChanges();

                if (affectedRows == 0)
                {
                    string message = string.Format(ExceptionMessage.DeleteFailedFormat, this.GetType(), typeof(Team));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Update(Team data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> ListAll()
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Teams.ToList();
                return list;
            }
        }

        public IEnumerable<Team> Find(Expression<Func<Team, bool>> condition)
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Teams.Where(condition).ToList();
                return list;
            }
        }
    }
}
