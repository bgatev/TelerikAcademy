using System;
using System.Linq;

namespace Students
{
    public class Human
    {
        private string fName, mName, lName, address, phone, eMail;

        public Human(string firstName, string middleName, string lastName) : this(firstName, middleName, lastName,null,null,null)
        {
        }

        public Human(string firstName, string middleName, string lastName, string fullAddress) : this(firstName, middleName, lastName, fullAddress, null, null)
        {
        }

        public Human(string firstName, string middleName, string lastName, string fullAddress, string mobPhone, string e_Mail)
        {
            this.fName = firstName;
            this.mName = middleName;
            this.lName = lastName;
            this.address = fullAddress;
            this.phone = mobPhone;
            this.eMail = e_Mail;
        }

        public string FName
        {
            get
            {
                return this.fName;
            }
            set
            {
                this.fName = value;
            }
        }

        public string MName
        {
            get
            {
                return this.mName;
            }
            set
            {
                this.mName = value;
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
                this.lName = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        public string EMail
        {
            get
            {
                return this.eMail;
            }
            set
            {
                this.eMail = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}",this.fName, this.mName, this.lName, this.address, this.phone, this.eMail);
        }
    }
}
