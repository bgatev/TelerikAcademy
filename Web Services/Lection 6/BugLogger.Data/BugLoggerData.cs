namespace BugLogger.Data
{
    using System;
    using System.Collections.Generic;

    using Model;
    using Repositories;

    public class BugLoggerData
    {
        private BugLoggerDbContext context;
        private IDictionary<Type, object> repositories;

        public BugLoggerData()
            : this(new BugLoggerDbContext())
        {
        }

        public BugLoggerData(BugLoggerDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Bug> Bugs
        {
            get
            {
                return this.GetRepository<Bug>();
            }
        }

        public IGenericRepository<Status> Statuses
        {
            get
            {
                return this.GetRepository<Status>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }       

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
