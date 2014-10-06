namespace BugLogger.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Model;
    using Migrations;

    public class BugLoggerDbContext:DbContext
    {
        public BugLoggerDbContext()
            : base("BugLogger")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Bug> Bugs { get; set; }

        public IDbSet<Status> Statuses { get; set; }
        
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
