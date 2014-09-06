namespace StudentSystemData
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using StudentSystemModel;

    public class StudentSystem : DbContext
    {
        public StudentSystem() : base("StudentSystemDB")
        {

        }

        public IDbSet<Students> Students { get; set; }

        public IDbSet<Courses> Courses { get; set; }

        public IDbSet<Homework> Homework { get; set; }

        public IDbSet<StudentsInCourses> StudentsInCourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsInCourses>().HasKey(k => new { k.CoursesId, k.StudentsId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
