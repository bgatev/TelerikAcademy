using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher:ITeacher
    {
        private string name;
        List<ICourse> teacherCourses; 

        public Teacher(string fullName)
        {
            this.Name = fullName;
            this.teacherCourses = new List<ICourse>();
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                else if (value.Length < 3) throw new ArgumentOutOfRangeException("The name is too short");
                else this.name = value; 
            }
        }

        public void AddCourse(ICourse course)
        {
            this.teacherCourses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Teacher: Name={0}",this.Name));

            if (this.teacherCourses.Count() > 0)
            {
                sb.Append("; Courses=[");
                foreach (var singleCourse in this.teacherCourses)
                {
                    sb.Append(singleCourse.Name);
                    sb.Append(", ");
                }

                if (sb[sb.Length - 2] == ',') sb.Remove(sb.Length - 2, 2);
                sb.Append("]");
            }

            return sb.ToString();
        }
    }
}
