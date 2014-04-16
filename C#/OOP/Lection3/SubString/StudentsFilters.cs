using System;
using System.Linq;

namespace MyLinq
{
    public class StudentsFilters
    {
        public StudentsFilters()
        {

        }
                
        public static void FindAlphaNames(Students[] allStudents)
        {
            var query = from student in allStudents
                        where student.FName[0] < student.LName[0]
                        select new { student.FName, student.LName };

            foreach (var singleStudent in query)
            {
                Console.WriteLine("{0} {1}", singleStudent.FName, singleStudent.LName);
            }
        }

        public static void FindNormalAgeStudents(Students[] allStudents, int minAge, int maxAge)
        {
            var query = from student in allStudents
                        where (student.AGE > minAge) && (student.AGE < maxAge)
                        select new { student.FName, student.LName };

            foreach (var singleStudent in query)
            {
                Console.WriteLine("{0} {1}", singleStudent.FName, singleStudent.LName);
            }
        }

        public static void SortByName(Students[] allStudents)
        {
            var result = allStudents.OrderByDescending(s => s.FName).ThenByDescending(s => s.LName);

            foreach (var singleStudent in result)
            {
                Console.WriteLine("{0} {1}", singleStudent.FName, singleStudent.LName);
            }
        }

        public static void SortByNameLinq(Students[] allStudents)
        {
            var query = from student in allStudents
                        orderby student.FName descending, student.LName ascending
                        select new { student.FName, student.LName };

            foreach (var singleStudent in query)
            {
                Console.WriteLine("{0} {1}", singleStudent.FName, singleStudent.LName);
            }
        }
    }
}