using System;
using System.Linq;

namespace School
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            MySchool TU = new MySchool();
            Classes mathClass = new Classes();
            Classes geoClass = new Classes();
            Teacher ivanov = new Teacher("Ivan Ivanov");
            Teacher petrov = new Teacher("Dimcho Petrov");
            Discipline math = new Discipline("Math",4,6);
            Discipline geo = new Discipline();
            Discipline bg = new Discipline("BG Language");

            mathClass.AddTeacher(ivanov);
            mathClass.AddTeacher(petrov);
            geoClass.AddTeacher(petrov);

            mathClass.AddComment("The best class");
            geoClass.AddComment("Loosers");

            mathClass.ClassNum = "11g";
            geoClass.ClassNum = "11a";

            ivanov.AddDiscipline(math);
            petrov.AddDiscipline(bg);
            
            ivanov.AddComment("Varbata");
            petrov.AddComment("Gestapo");

            math.AddComment("You must learn it");
            bg.AddComment("I am proud to be Bulgarian");
            geo.AddComment("Go Go Go");

            TU.AddClass(mathClass);
            TU.AddClass(geoClass);

            Console.WriteLine("My class is {0}. This is {1}. We have some teachers - {2} - {3} and {4} - {5}. First is teaching {6} - {7}/{8} hpw lectures/exercises. {9} - {10}", 
                mathClass.ClassNum, mathClass.Comments[0], ivanov.Name, ivanov.Comments[0],petrov.Name, petrov.Comments[0],math.Name, math.NumOfLectures, math.NumOfExercises, math.Name, math.Comments[0]);
        }
    }
}
