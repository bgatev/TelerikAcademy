using System;
using System.Linq;

namespace Bank
{
    public class CompanyCustomer:Customer
    {
        private string bulstat;

        public CompanyCustomer(string name,string eik):base(name)
        {
            this.bulstat = eik;
        }

        public string Bulstat
        {
            get
            {
                return this.bulstat;
            }
            set
            {
                bool flag = true;

                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsNumber(value[i])) flag = false;
                }

                if (flag && value.Length >= 9 && value.Length <= 13) this.bulstat = value;
                else throw new ArgumentException("Invalid Bulstat");
            }
        }
    }
}
