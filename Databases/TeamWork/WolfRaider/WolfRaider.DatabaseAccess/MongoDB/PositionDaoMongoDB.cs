namespace WolfRaider.DatabaseAccess.MongoDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.Contracts;

    public class PositionDaoMongoDB : IGeneralDao<Position>
    {
        private MongoDataInserter mongoInserter;
        private MongoDataRepository mongoRepository;

        public PositionDaoMongoDB()
        {
            this.mongoInserter = new MongoDataInserter();
            this.mongoRepository = new MongoDataRepository();
        }

        public void Insert(Position position)
        {
            this.mongoRepository.Positions.Add(position);
        }

        public void Delete(Position position)
        {
            this.mongoRepository.Positions.Delete(position);
        }

        public void Update(Position position)
        {
            this.mongoRepository.Positions.Update(position);
        }

        public IEnumerable<Position> ListAll()
        {
            return this.mongoRepository.Positions.Select(x => x);
        }

        public IEnumerable<Position> Find(Expression<Func<Position, bool>> condition)
        {
            return this.mongoRepository.Positions.Where(condition);
        }
    }
}
