using System;
using System.Linq;

namespace MyLinq
{
    public class Students
    {
        private string fName, lName;
        private int age;

        public Students(string firstName, string lastName)
        {
            this.fName = firstName;
            this.lName = lastName;
        }

        public Students(string firstName, string lastName, int studentAge)
        {
            this.fName = firstName;
            this.lName = lastName;
            this.age = studentAge;
        }
                
        public string FName
        {
            get
            {
                return this.fName;
            }
        }

        public string LName
        {
            get
            {
                return this.lName;
            }
        }

        public int AGE
        {
            get
            {
                return this.age;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FName, this.LName);
        }

    }
}
