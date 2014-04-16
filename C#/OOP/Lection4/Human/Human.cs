using System;
using System.Linq;

namespace Human
{
    public abstract class Human
    {
        private string fName, lName;

        public Human(string firstName, string lastName)
        {
            this.fName = firstName;
            this.lName = lastName;
        }
        
        public string FName
        {
            get
            {
                return this.fName;
            }
            set
            {
                if (value.Length > 0) this.fName = value;
                else throw new ArgumentException("Invalid First Name");
            }
        }

        public string LName
        {
            get
            {
                return this.lName;
            }
            set
            {
                if (value.Length > 0) this.lName = value;
                else throw new ArgumentException("Invalid Last Name");
            }
        }
    }
}
