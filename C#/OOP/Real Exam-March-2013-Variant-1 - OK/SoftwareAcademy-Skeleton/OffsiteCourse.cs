using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class OffsiteCourse:IOffsiteCourse
    {
        private string town, name;
        private ITeacher teacher;
        List<string> courseTopics;

        public OffsiteCourse(string courseName, ITeacher courseTeacher, string courseTown)
        {
            this.Name = courseName;
            if (courseTeacher != null) this.Teacher = courseTeacher;
            this.Town = courseTown;
            this.courseTopics = new List<string>();
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                else if (value.Length < 3) throw new ArgumentOutOfRangeException("The town is too short");
                else this.town = value;
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

            sb.Append(string.Format("{0}: Name={1}", this.GetType().Name, this.Name));
            if (this.Teacher != null) sb.Append(string.Format("; Teacher={0}", this.Teacher.Name));
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

            if (!string.IsNullOrEmpty(this.Town)) sb.Append(string.Format("; Town={0}", this.Town));

            return sb.ToString();
        }
    }
}
