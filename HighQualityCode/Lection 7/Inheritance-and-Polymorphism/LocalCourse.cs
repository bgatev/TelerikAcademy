namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Courses
    {
        public LocalCourse(string courseName, string teacherName, IList<string> students) : base(courseName, teacherName, new List<string>())
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName) : base(courseName, teacherName, new List<string>())
        {
        }

        public LocalCourse(string name) : base(name, null, new List<string>())
        {
        }      

        public string Lab { get; set; }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}
