using System;
using System.Linq;

namespace School
{
    public class Student : People
    {
        private string classNum;

        public Student(string name, string uniqueClassNum):base(name)
        {
            this.classNum = uniqueClassNum;
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

    }
}
