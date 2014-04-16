using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class People : IComment
    {
        private string name;

        public People(string peopleName)
        {
            this.name = peopleName;
            this.Comments = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 0) this.name = value;
                else throw new ArgumentException("Invalid Name");
            }
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
    }
}
