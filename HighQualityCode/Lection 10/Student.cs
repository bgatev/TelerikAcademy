namespace School
{
    using System;
    using System.Collections.Generic;

    public class Student : IPrintable
    {
        private string name;
        private int fakNumber;
        
        public Student(string name, int fakNumber)
        {
            this.Name = name;
            this.FakNumber = fakNumber;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid Student Name");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int FakNumber
        {
            get
            {
                return this.fakNumber;
            }

            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Invalid FakNumber - must be 5 digit number");
                }
                else
                {
                    this.fakNumber = value;
                }
            }
        }

        /// <summary>
        /// This Method is Only for Debug - not needed to be covered by testing
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} -> {1}", this.Name, this.FakNumber);
        }
    }
}
