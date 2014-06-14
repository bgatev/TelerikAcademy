namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course : IPrintable
    {
        private List<Student> courses;
        private string name;

        public Course(string name)
        {
            this.courses = new List<Student>();
            this.name = name;
        }

        public List<Student> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public void AddStudent(Student currentStudent)
        {
            if (this.courses.Count < 30)
            {
                this.courses.Add(currentStudent);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Too many Students - must be not more than 30");
            }
        }

        public void RemoveStudent(Student currentStudent)
        {
            this.courses.Remove(currentStudent);
        }

        /// <summary>
        /// This Method is Only for Debug - not needed to be covered by testing
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.Name);

            foreach (var singleStudent in courses)
            {
                sb.AppendLine(singleStudent.ToString());   
            }

            return sb.ToString();
        }
    }
}
