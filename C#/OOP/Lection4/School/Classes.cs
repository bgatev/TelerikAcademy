using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class Classes : IComment
    {
        private string classNum;
        private List<Teacher> teachers;

        public Classes()
        {
            this.Comments = new List<string>();
            this.teachers = new List<Teacher>();
        }

        public string ClassNum
        {
            get
            {
                return this.classNum;
            }
            set
            {
                if (value.Length > 0) this.classNum = value;
                else throw new ArgumentException("Invalid Class Number");
            }
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }

        public void AddTeacher(Teacher inTeacher)
        {
            this.teachers.Add(inTeacher);
        }
    }
}
