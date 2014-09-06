namespace WolfRaider.DatabaseAccess.MongoDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.Contracts;

    public class SquadHistoryDaoMongoDB : IGeneralDao<SquadHistory>
    {
        private MongoDataInserter mongoInserter;
        private MongoDataRepository mongoRepository;

        public SquadHistoryDaoMongoDB()
        {
            this.mongoInserter = new MongoDataInserter();
            this.mongoRepository = new MongoDataRepository();
        }

        public void Insert(SquadHistory squadHistory)
        {
            this.mongoRepository.SquadHistories.Add(squadHistory);
        }

        public void Delete(SquadHistory squadHistory)
        {
            this.mongoRepository.SquadHistories.Delete(squadHistory);
        }

        public void Update(SquadHistory squadHistory)
        {
            this.mongoRepository.SquadHistories.Update(squadHistory);
        }

        public IEnumerable<SquadHistory> ListAll()
        {
            return this.mongoRepository.SquadHistories.Select(x => x);
        }

        public IEnumerable<SquadHistory> Find(Expression<Func<SquadHistory, bool>> condition)
        {
            return this.mongoRepository.SquadHistories.Where(condition);
        }
    }
}
