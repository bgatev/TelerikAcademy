using System;
using System.Linq;

namespace Human
{
    public class Student : Human
    {
        private char grade;

        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, char studentGrade):base(firstName, lastName)
        {
            this.grade = studentGrade;
        }

        public char Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if ((value >= 'A')  && (value <= 'D')) this.grade = value;
                else throw new ArgumentException("Invalid Grade");
            }
        }
    }
}
