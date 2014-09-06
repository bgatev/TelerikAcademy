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

    public class WorkHistoryDaoSqlServer : IGeneralDao<WorkHistory>
    {
        public void Insert(WorkHistory data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(WorkHistory));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                context.WorkHistories.Add(data);
                int affectedRowns = context.SaveChanges();

                if (affectedRowns == 0)
                {
                    string message = string.Format(ExceptionMessage.InsertFailedFormat, this.GetType(), typeof(WorkHistory));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Delete(WorkHistory data)
        {
            if (data == null)
            {
                string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(WorkHistory));
                throw new ArgumentException(message);
            }

            var context = new WolfRaiderContext();

            using (context)
            {
                WorkHistory existing = context.WorkHistories.First(x => x.WorkHistoryId == data.WorkHistoryId);
                context.WorkHistories.Remove(existing);

                int affectedRows = context.SaveChanges();

                if (affectedRows == 0)
                {
                    string message = string.Format(ExceptionMessage.DeleteFailedFormat, this.GetType(), typeof(WorkHistory));
                    throw new DbUpdateException(message);
                }
            }
        }

        public void Update(WorkHistory data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkHistory> ListAll()
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.WorkHistories.ToList();
                return list;
            }
        }

        public IEnumerable<WorkHistory> Find(Expression<Func<WorkHistory, bool>> condition)
        {
            var context = new WolfRaiderContext();

            using (context)
            {
                var list = context.WorkHistories.Where(condition).ToList();
                return list;
            }
        }
    }
}
