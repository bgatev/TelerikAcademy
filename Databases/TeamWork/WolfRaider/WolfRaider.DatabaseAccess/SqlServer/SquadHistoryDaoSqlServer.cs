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

    public class SquadHistoryDaoSqlServer : IGeneralDao<SquadHistory>, IDisposable
    {
        private readonly WolfRaiderContext context;

        public SquadHistoryDaoSqlServer()
        {
            this.context = new WolfRaiderContext();
        }

        public void Insert(SquadHistory data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(SquadHistory));
                throw new ArgumentException(message);
            }

            this.context.SquadHistories.Add(data);
            int affectedRowns = this.context.SaveChanges();

            if (affectedRowns == 0)
            {
                string message = string.Format(ExceptionMessage.InsertFailedFormat, this.GetType(), typeof(SquadHistory));
                throw new DbUpdateException(message);
            }
        }

        public void Delete(SquadHistory data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(SquadHistory));
                throw new ArgumentException(message);
            }

            SquadHistory existing = this.context.SquadHistories.First(x => x.SquadHistoryId == data.SquadHistoryId);

            this.context.SquadHistories.Remove(existing);
            int affectedRows = this.context.SaveChanges();

            if (affectedRows == 0)
            {
                string message = string.Format(ExceptionMessage.DeleteFailedFormat, this.GetType(), typeof(SquadHistory));
                throw new DbUpdateException(message);
            }
        }

        public void Update(SquadHistory data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(SquadHistory));
                throw new ArgumentException(message);
            }

            SquadHistory existing = this.context.SquadHistories.First(x => x.SquadHistoryId == data.SquadHistoryId);

            existing.RedCards = data.RedCards;
            existing.YellowCards = data.YellowCards;
            existing.Goals = data.Goals;
            existing.EmpoyeeId = data.EmpoyeeId;
            existing.PositionId = data.PositionId;
            existing.GameId = data.GameId;

            int affectedRows = this.context.SaveChanges();

            if (affectedRows == 0)
            {
                string message = string.Format(ExceptionMessage.UpdateFailedFormat, this.GetType(), typeof(SquadHistory));
                throw new DbUpdateException(message);
            }
        }

        public IEnumerable<SquadHistory> ListAll()
        {
            var list = this.context.SquadHistories.ToList();
            return list;
        }

        public IEnumerable<SquadHistory> Find(Expression<Func<SquadHistory, bool>> condition)
        {
            var list = this.context.SquadHistories.Where(condition).ToList();
            return list;
        }

        public void Dispose()
        {
            this.context.Database.Connection.Close();
        }
    }
}
