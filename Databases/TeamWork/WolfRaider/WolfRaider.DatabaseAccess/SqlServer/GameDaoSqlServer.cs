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

    public class GameDaoSqlServer : IGeneralDao<Game>
    {
        public void Insert(Game data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Game));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                context.Games.Add(data);
                int affectedRowns = context.SaveChanges();

                if (affectedRowns == 0)
                {
                    string message = string.Format(ExceptionMessage.InsertFailedFormat, this.GetType(), typeof(Game));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Delete(Game data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Game));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                Game existing = context.Games.First(x => x.GameId == data.GameId);
                context.Games.Remove(existing);
                int affectedRows = context.SaveChanges();

                if (affectedRows == 0)
                {
                    string message = string.Format(ExceptionMessage.DeleteFailedFormat, this.GetType(), typeof(Game));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Update(Game data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> ListAll()
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Games.ToList();
                return list;
            }
        }

        public IEnumerable<Game> Find(Expression<Func<Game, bool>> condition)
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Games.Where(condition).ToList();
                return list;
            }
        }
    }
}
