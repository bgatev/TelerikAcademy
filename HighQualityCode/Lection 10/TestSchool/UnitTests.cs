namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    using System.Collections.Generic;

    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CanCreateStudent()
        {
            Student firstStudent = new Student("Ivan Ivanov", 33333);
            Assert.IsNotNull(firstStudent,"Student can not be null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Invalid Student Name")]
        public void CanCreateStudentWithoutName()
        {
            Student firstStudent = new Student("", 33333);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid FakNumber - must be 5 digit number")]
        public void CanCreateStudentWithInvalidNumber()
        {
            Student firstStudent = new Student("Pesho", 2222);
            Student secondStudent = new Student("Pesho Ivanov", 222277);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid FakNumber - must be unique")]
        public void CanCreateStudentWithDuplicateNumber()
        {
            Dictionary<int, string> allStudents = new Dictionary<int, string>();
            Student firstStudent = new Student("Ivan Ivanov", 33333);
            Student secondStudent = new Student("Pesho Ivanov", 11133);
            Student thirdStudent = new Student("Kolio Petrov", 89765);
            Student fourthStudent = new Student("Mara Pobara", 89765);

            allStudents.Add(firstStudent.FakNumber, firstStudent.Name);
            allStudents.Add(secondStudent.FakNumber, secondStudent.Name);
            allStudents.Add(thirdStudent.FakNumber, thirdStudent.Name);
            allStudents.Add(fourthStudent.FakNumber, fourthStudent.Name);
        }

        [TestMethod]
        public void CanGetCourseName()
        {
            Course math = new Course("Math Course");
            string name = math.Name;

            Assert.IsNotNull(name);
        }

        [TestMethod]
        public void CanAddStudentToCourse()
        {
            Course math = new Course("Math Course");
            Student firstStudent = new Student("Ivan Ivanov", 33333);
            math.AddStudent(firstStudent);

            Assert.AreEqual(1, math.Courses.Count);
        }

        [TestMethod]
        public void CanRemoveStudentFromCourse()
        {
            Course math = new Course("Math Course");
            Student firstStudent = new Student("Ivan Ivanov", 33333);
            math.AddStudent(firstStudent);
            math.RemoveStudent(firstStudent);

            Assert.AreEqual(0, math.Courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Students in course must be less than 30")]
        public void CanCreateCourseWithMoreThan30Students()
        {
            Course math = new Course("Math Course");

            for (int i = 0; i < 31; i++)
            {
                Student currentStudent = new Student(string.Format("Ivan Ivanov {0}", i), 33333 + i);
                math.AddStudent(currentStudent);
            }
        }
    }
}
