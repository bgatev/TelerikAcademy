namespace Arts.Data
{
    using Migrations;
    using Model;
    using System.Data.Entity;

    public class ArtsDbContext : DbContext
    {
        public ArtsDbContext()
            : base("Arts")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtsDbContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Song> Songs { get; set; }

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
