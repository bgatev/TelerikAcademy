namespace WolfRaider.DatabaseAccess.MongoDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.Contracts;

    public class TeamDaoMongoDB : IGeneralDao<Team>
    {
        private MongoDataInserter mongoInserter;
        private MongoDataRepository mongoRepository;

        public TeamDaoMongoDB()
        {
            this.mongoInserter = new MongoDataInserter();
            this.mongoRepository = new MongoDataRepository();
        }

        public void Insert(Team team)
        {
            this.mongoRepository.Teams.Add(team);
        }

        public void Delete(Team team)
        {
            this.mongoRepository.Teams.Delete(team);
        }

        public void Update(Team team)
        {
            this.mongoRepository.Teams.Update(team);
        }

        public IEnumerable<Team> ListAll()
        {
            return this.mongoRepository.Teams.Select(x => x);
        }

        public IEnumerable<Team> Find(Expression<Func<Team, bool>> condition)
        {
            return this.mongoRepository.Teams.Where(condition);
        }
    }
}
