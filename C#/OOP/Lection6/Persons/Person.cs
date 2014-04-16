using System;
using System.Linq;

namespace Persons
{
    public class Person
    {
        private string name;
        private int? age;

        public Person(string fullName):this(fullName,null)
        {
        }

        public Person(string fullName, int? personAge)
        {
            this.name = fullName;
            this.age = personAge;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public override string ToString()
        {
            if (this.age == null) return string.Format("{0} and the age is not specified",this.name);

            return string.Format("{0} {1}",this.name, this.age);
        }
    }
}
