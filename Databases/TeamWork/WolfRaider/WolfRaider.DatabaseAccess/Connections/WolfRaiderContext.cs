namespace WolfRaider.DatabaseAccess.Connections
{
    using System.Data.Entity;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.Migrations;

    public partial class WolfRaiderContext : DbContext
    {
        public WolfRaiderContext()
            : base("name=WolfRaiderEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WolfRaiderContext, Configuration>());
        }

        public virtual DbSet<Employee> Employees { get; set; }
     
        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Nationality> Nationalities { get; set; }

        public virtual DbSet<Occupation> Occupations { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<SquadHistory> SquadHistories { get; set; }
       
        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<WorkHistory> WorkHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ManagedEmployees)
                .WithRequired(e => e.Manager)
                .HasForeignKey(e => e.ManagerId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.SquadHistories)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.EmpoyeeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkHistories)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.SquadHistories)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nationality>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Nationality)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Occupation>()
                .HasMany(e => e.WorkHistories)
                .WithRequired(e => e.Occupation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.SquadHistories)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.HomeGames)
                .WithRequired(e => e.HomeTeam)

                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.AwayGames)
                .WithRequired(e => e.GuestTeam)

                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.WorkHistories)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);
        }
    }
}
