namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This Class is Only for Debug - not needed to be covered by testing
    /// </summary>
    public class School : IPrintable
    {
        private Dictionary<int, string> allStudents = new Dictionary<int, string>();
        private List<Course> schoolCourses;

        public School()
        {
            this.schoolCourses = new List<Course>();
        }

        public List<Course> SchoolCourses
        {
            get
            {
                return this.schoolCourses;
            }
        }

        public static void Main()
        {
            School mySchool = new School();
            Student firstStudent = new Student("Ivan Ivanov", 33333);
            Student secondStudent = new Student("Pesho Ivanov", 11133);
            Student thirdStudent = new Student("Kolio Petrov", 89765);
            Student fourthStudent = new Student("Mara Pobara", 89765);

            mySchool.allStudents.Add(firstStudent.FakNumber,firstStudent.Name);
            mySchool.allStudents.Add(secondStudent.FakNumber, secondStudent.Name);
            mySchool.allStudents.Add(thirdStudent.FakNumber, thirdStudent.Name);
            mySchool.allStudents.Add(fourthStudent.FakNumber, fourthStudent.Name);

            Course math = new Course("Math Course");
            Course bg = new Course("BG Course");

            mySchool.AddCourse(math);
            mySchool.AddCourse(bg);

            math.AddStudent(firstStudent);
            math.AddStudent(secondStudent);
            math.AddStudent(thirdStudent);

            bg.AddStudent(secondStudent);

            Console.WriteLine(mySchool);
        }

        public void AddCourse(Course currentCourse)
        {
            if (this.schoolCourses.Count < 100)
            {
                this.schoolCourses.Add(currentCourse);
            }
            else
            {
                throw new ArgumentException("Too many Courses - must be not more than 100");
            }
        }

        public void RemoveCourse(Course currentCourse)
        {
            this.schoolCourses.Remove(currentCourse);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var singleCourse in schoolCourses)
            {
                sb.AppendLine(singleCourse.ToString());
            }

            return sb.ToString();
        }
    }
}
