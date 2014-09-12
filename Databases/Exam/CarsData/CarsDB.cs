namespace CarsData
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using CarsModel;

    public class CarsDB : DbContext
    {
        public CarsDB()
            : base("CarsDB")
        {

        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Manifacturer> Manifacturers { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<City> City { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
