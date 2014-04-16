using System;
using System.Linq;

namespace Bank
{
    public class IndividualCustomer:Customer
    {
        private string egn;

        public IndividualCustomer(string name, string customerEGN):base(name)
        {
            this.egn = customerEGN;
        }

        public string EGN
        {
            get
            {
                return this.egn;
            }
            set
            {
                bool flag = true;

                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsNumber(value[i])) flag = false;    
                }

                if (flag && value.Length == 10) this.egn = value;
                else throw new ArgumentException("Invalid EGN");
            }
        }
    }
}
