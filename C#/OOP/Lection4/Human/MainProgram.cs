using System;
using System.Collections.Generic;
using System.Linq;

namespace Human
{
    class MainProgram
    {
        static void Main()
        {
            List<Student> students = new List<Student>() {  new Student("Ivan","Ivanov",'A'),
                                                            new Student("Petar","Ivanov",'C'),
                                                            new Student("Ivan","Petrov",'B'),
                                                            new Student("Stamat","Dimitrov",'A'),
                                                            new Student("Vankata","Golemanov"),
                                                            new Student("Pesho","Shaibata",'C'),
                                                            new Student("Drago","Chaia",'D'),
                                                            new Student("Toncho","Papazov"),
                                                            new Student("George","Michael"),
                                                            new Student("Kircho","Ivanov",'B')};
            students[4].Grade = 'A';
            students[7].Grade = 'C';
            students[8].Grade = 'D';

            var sortedStudentsByGrade = from s in students
                                        orderby s.Grade ascending
                                        select new Student (s.FName,s.LName,s.Grade);

            foreach (var student in sortedStudentsByGrade)
            {
                Console.WriteLine("{0} {1} {2}",student.FName, student.LName, student.Grade);   
            }

            Console.WriteLine();
            List<Worker> workers = new List<Worker>() {     new Worker("Ivan","Ivanov",90,20),
                                                            new Worker("Petar","Ivanov",100,10),
                                                            new Worker("Ivan","Petrov",101,9),
                                                            new Worker("Stamat","Dimitrov",300,3),
                                                            new Worker("Vankata","Golemanov",145,4),
                                                            new Worker("Pesho","Shaibata",190,5),
                                                            new Worker("Drago","Chaia",250,6),
                                                            new Worker("Toncho","Papazov",770,8),
                                                            new Worker("George","Michael",567,10),
                                                            new Worker("Kircho","Ivanov",985,18)};
            var sortedWorkersByMPH = workers.OrderByDescending(w => w.MoneyPerHour());

            foreach (var worker in sortedWorkersByMPH)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",worker.FName,worker.LName,worker.WorkHoursPerDay,worker.WeekSalary,worker.MoneyPerHour());    
            }

            Console.WriteLine();
            List<Human> mergedList = new List<Human>();
            mergedList.AddRange(sortedStudentsByGrade); 
            mergedList.AddRange(sortedWorkersByMPH);

            foreach (var human in mergedList)
            {
                Console.WriteLine("{0} {1}", human.FName, human.LName);
            }

            Console.WriteLine();
            var result = from h in mergedList
                         orderby h.FName, h.LName
                         select new { h.FName, h.LName };

            foreach (var human in result)
            {
                Console.WriteLine("{0} {1}",human.FName, human.LName);    
            }
        }
    }
}
