namespace WolfRaider.DatabaseAccess.MongoDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.Contracts;

    public class NationalityDaoMongoDb : IGeneralDao<Nationality>
    {
        private MongoDataInserter mongoInserter;
        private MongoDataRepository mongoRepository;

        public NationalityDaoMongoDb()
        {
            this.mongoInserter = new MongoDataInserter();
            this.mongoRepository = new MongoDataRepository();
        }

        public void Insert(Nationality nationality)
        {
            this.mongoRepository.Nationalities.Add(nationality);
        }

        public void Delete(Nationality nationality)
        {
            this.mongoRepository.Nationalities.Delete(nationality);
        }

        public void Update(Nationality nationality)
        {
            this.mongoRepository.Nationalities.Update(nationality);
        }

        public IEnumerable<Nationality> ListAll()
        {
            return this.mongoRepository.Nationalities.Select(x => x);
        }

        public IEnumerable<Nationality> Find(Expression<Func<Nationality, bool>> condition)
        {
            return this.mongoRepository.Nationalities.Where(condition);
        }
    }
}
