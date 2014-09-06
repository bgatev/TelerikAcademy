namespace WolfRaider.DatabaseAccess.MongoDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.Contracts;

    public class OccupationDaoMongoDB : IGeneralDao<Occupation>
    {
        private MongoDataInserter mongoInserter;
        private MongoDataRepository mongoRepository;

        public OccupationDaoMongoDB()
        {
            this.mongoInserter = new MongoDataInserter();
            this.mongoRepository = new MongoDataRepository();
        }

        public void Insert(Occupation occupation)
        {
            this.mongoRepository.Occupations.Add(occupation);
        }

        public void Delete(Occupation occupation)
        {
            this.mongoRepository.Occupations.Delete(occupation);
        }

        public void Update(Occupation occupation)
        {
            this.mongoRepository.Occupations.Update(occupation);
        }

        public IEnumerable<Occupation> ListAll()
        {
            return this.mongoRepository.Occupations.Select(x => x);
        }

        public IEnumerable<Occupation> Find(Expression<Func<Occupation, bool>> condition)
        {
            return this.mongoRepository.Occupations.Where(condition);
        }
    }
}
