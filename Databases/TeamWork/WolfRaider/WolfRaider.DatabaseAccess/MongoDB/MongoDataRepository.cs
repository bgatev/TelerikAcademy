namespace WolfRaider.DatabaseAccess.MongoDB
{
    using System;
    using System.Collections.Generic;

    using MongoRepository;
    using WolfRaider.Common.Models;

    public class MongoDataRepository
    {
        private readonly IDictionary<Type, object> repositories;

        public MongoDataRepository()
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public MongoRepository<Team> Teams
        {
            get
            {
                return this.GetRepository<Team>();
            }
        }

        public MongoRepository<Employee> Employees
        {
            get
            {
                return this.GetRepository<Employee>();
            }
        }

        public MongoRepository<Nationality> Nationalities
        {
            get
            {
                return this.GetRepository<Nationality>();
            }
        }

        public MongoRepository<Position> Positions
        {
            get
            {
                return this.GetRepository<Position>();
            }
        }

        public MongoRepository<SquadHistory> SquadHistories
        {
            get
            {
                return this.GetRepository<SquadHistory>();
            }
        }

        public MongoRepository<WorkHistory> WorkHistories
        {
            get
            {
                return this.GetRepository<WorkHistory>();
            }
        }

        public MongoRepository<Occupation> Occupations
        {
            get
            {
                return this.GetRepository<Occupation>();
            }
        }

        public MongoRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        private MongoRepository<T> GetRepository<T>() where T : Entity
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(MongoRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type));
            }

            return (MongoRepository<T>)this.repositories[typeOfModel];
        }
    }
}
