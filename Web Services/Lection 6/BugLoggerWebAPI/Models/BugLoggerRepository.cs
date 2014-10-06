namespace BugLoggerWebAPI.Models
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    using BugLogger.Data;

    public class BugLoggerRepository<T> : IRepository<T> where T : class
    {
        private static BugLoggerDbContext dbContext = new BugLoggerDbContext();

        public BugLoggerRepository()
            : this(dbContext)
        {
        }

        public BugLoggerRepository(DbContext context)
        {
            if (context == null) throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }
        
        public void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Detached) entry.State = EntityState.Added;
            else this.DbSet.Add(entity);

            this.Context.SaveChanges();
        }

        public T Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().Where(conditions);
        }

        public IQueryable<T> GetAll()
        {
            return this.DbSet;
        }

        public void Update(int id, T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached) this.DbSet.Attach(entity);

            entry.State = EntityState.Modified;

            this.Context.SaveChanges();
        }

        public T Delete(int id)
        {
            var entity = this.Get(id);

            if (entity != null) this.Delete(entity);

            return entity;
        }

        public virtual T Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Deleted) entry.State = EntityState.Deleted;
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }

            this.Context.SaveChanges();

            return entity;
        }    
    }
}