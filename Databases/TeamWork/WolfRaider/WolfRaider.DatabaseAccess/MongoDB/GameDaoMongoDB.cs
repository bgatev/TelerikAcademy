namespace WolfRaider.DatabaseAccess.MongoDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.Contracts;

    public class GameDaoMongoDB : IGeneralDao<Game>
    {
        private MongoDataInserter mongoInserter;
        private MongoDataRepository mongoRepository;

        public GameDaoMongoDB()
        {
            this.mongoInserter = new MongoDataInserter();
            this.mongoRepository = new MongoDataRepository();
        }

        public void Insert(Game game)
        {
            this.mongoRepository.Games.Add(game);
        }

        public void Delete(Game game)
        {
            this.mongoRepository.Games.Delete(game);
        }

        public void Update(Game game)
        {
            this.mongoRepository.Games.Update(game);
        }

        public IEnumerable<Game> ListAll()
        {
            return this.mongoRepository.Games.Select(x => x);
        }

        IEnumerable<Game> IGeneralDao<Game>.Find(Expression<Func<Game, bool>> condition)
        {
            return this.mongoRepository.Games.Where(condition);
        }
    }
}
