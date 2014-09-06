namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using StudentSystemData;
    using StudentSystemData.Migrations;
    using StudentSystemModel;
    
    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystem, Configuration>());

            StudentSystem dbContext = new StudentSystem();

            using (dbContext)
            {
                Students currentStudent = new Students();
                currentStudent.Name = "Ivan";
                currentStudent.Number = 123456;

                dbContext.Students.Add(currentStudent);
                dbContext.SaveChanges();

                foreach (var student in dbContext.Students)
                {
                    Console.WriteLine(student.Name + " " + student.Number);
                }
            }
        }
    }
}
