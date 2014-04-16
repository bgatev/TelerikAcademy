using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class LocalCourse:ILocalCourse
    {
        private string lab, name;
        private ITeacher teacher;
        List<string> courseTopics;

        public LocalCourse(string courseName, ITeacher courseTeacher, string courseLab)
        {
            this.Name = courseName;
            if (courseTeacher != null) this.Teacher = courseTeacher;
            this.Lab = courseLab;
            this.courseTopics = new List<string>();
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                else if (value.Length < 1) throw new ArgumentOutOfRangeException("The lab is too short");
                else this.lab = value;
            }
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

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.courseTopics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0}: Name={1}" ,this.GetType().Name,this.Name));
            if (this.Teacher != null) sb.Append(string.Format("; Teacher={0}",this.Teacher.Name));
            if (this.courseTopics.Count() > 0)
            {
                sb.Append(string.Format("; Topics=["));

                foreach (var singleTopic in this.courseTopics)
                {
                    sb.Append(singleTopic);
                    sb.Append(", ");
                }

                if (sb[sb.Length - 2] == ',') sb.Remove(sb.Length - 2, 2);
                sb.Append("]");
            }

            if (!string.IsNullOrEmpty(this.Lab)) sb.Append(string.Format("; Lab={0}", this.Lab));
            
            return sb.ToString();
        }
    }
}
