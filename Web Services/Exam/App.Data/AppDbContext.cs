namespace App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using App.Models;
    using Migrations;

    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("BullsCows")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Guess> Guesses { get; set; }

        public IDbSet<Notification> Notifications { get; set; }
    }
}