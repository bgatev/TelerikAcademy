namespace WolfRaider.DatabaseAccess.MongoDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.Contracts;

    public class WorkHistoryDaoMongoDB : IGeneralDao<WorkHistory>
    {
        private MongoDataInserter mongoInserter;
        private MongoDataRepository mongoRepository;

        public WorkHistoryDaoMongoDB()
        {
            this.mongoInserter = new MongoDataInserter();
            this.mongoRepository = new MongoDataRepository();
        }

        public void Insert(WorkHistory workHistory)
        {
            this.mongoRepository.WorkHistories.Add(workHistory);
        }

        public void Delete(WorkHistory workHistory)
        {
            this.mongoRepository.WorkHistories.Delete(workHistory);
        }

        public void Update(WorkHistory workHistory)
        {
            this.mongoRepository.WorkHistories.Update(workHistory);
        }

        public IEnumerable<WorkHistory> ListAll()
        {
            return this.mongoRepository.WorkHistories.Select(x => x);
        }

        public IEnumerable<WorkHistory> Find(Expression<Func<WorkHistory, bool>> condition)
        {
            return this.mongoRepository.WorkHistories.Where(condition);
        }
    }
}
