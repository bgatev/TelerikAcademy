namespace StudentSystemData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystemModel;
    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(StudentSystem dbContext)
        {
            this.SeedCourses(dbContext);
            this.SeedStudents(dbContext);

            dbContext.SaveChanges();
        }

        private void SeedStudents(StudentSystem dbContext)
        {
            if (dbContext.Students.Any())
            {
                return;
            }

            dbContext.Students.Add(new Students
            {
                Name = "Evlogi",
                Number = 657482
            });

            dbContext.Students.Add(new Students
            {
                Name = "Marko",
                Number = 134582
            });

            dbContext.Students.Add(new Students
            {
                Name = "Iveta",
                Number = 873451
            });
        }

        private void SeedCourses(StudentSystem dbContext)
        {
            if (dbContext.Courses.Any())
            {
                return;
            }

            dbContext.Courses.Add(new Courses { Name = "Seeded course" });
        }
    }
}