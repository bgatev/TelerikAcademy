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

    public class PositionDaoSqlServer : IGeneralDao<Position>
    {
        public void Insert(Position position)
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                context.Positions.Add(position);
                context.SaveChanges();
            }
        }

        public void Delete(Position data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(Position));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                Position existing = context.Positions.First(x => x.PositionId == data.PositionId);
                context.Positions.Remove(existing);
                int affectedRows = context.SaveChanges();

                if (affectedRows == 0)
                {
                    string message = string.Format(ExceptionMessage.DeleteFailedFormat, this.GetType(), typeof(Position));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Update(Position position)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> ListAll()
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Positions.ToList();
                return list;
            }
        }

        public IEnumerable<Position> Find(Expression<Func<Position, bool>> condition)
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.Positions.Where(condition).ToList();
                return list;
            }
        }
    }
}
