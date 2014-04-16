using System;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main()
        {
            Human ivan = new Human("Ivan","Petrov","Dimitrov");
            Human vankata = new Human("Ivan", "Petrovich", "Petrov");
            Human pesho = new Human("Pesho", "Ivanov", "Petrov", "Sofia");
            Human gosho = new Human("Gosho", "Gledalov", "Loshakov", "Varna", "0888123456", "gecata@abv.bg");

            Student ivanSt = new Student(ivan);
            Student peshoSt = new Student(pesho, Universities.PU, Faculties.FMakroeconomics, Specialities.Finance, "1234", 2);
            Student goshoSt = new Student(gosho, Universities.SU, Faculties.FSocialScience, Specialities.KTT, "5678", 4);
            Student vankataSt = new Student(vankata, Universities.TU, Faculties.FKTT, Specialities.KTT, "5678", 4);

            Console.WriteLine(goshoSt.ToString());
            Console.WriteLine(goshoSt.Equals(vankataSt));
            Console.WriteLine(goshoSt==ivanSt);
            Console.WriteLine(peshoSt!=vankataSt);

            Student gecata = goshoSt.Clone() as Student;
            Console.WriteLine(gecata.ToString());

            Console.WriteLine(vankataSt.CompareTo(peshoSt));
            Console.WriteLine(goshoSt.CompareTo(peshoSt));
        }
    }
}
