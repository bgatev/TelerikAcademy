using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public class MOC : IChargeable, IPrintable, IRequiredNumbers
    {
        private string msisdn;
        private DateTime callStartTime;
        private int callDuration;
        private string currentLocation;
        private string bParty;

        public MOC(params object[] mocParams)
        {
            this.MSISDN = mocParams[0] as string;
            this.callStartTime = DateTime.Parse(mocParams[1] as string);
            this.CallDuration = int.Parse(mocParams[2] as string);
            this.CurrentLocation = new Location().Index(mocParams[3]);
            this.BParty = new Destination().Index((mocParams[4] as string).Substring(0, 6));
        }

        public string MSISDN 
        {
            get
            {
                return this.msisdn;
            }
            set
            {
                try
                {
                    if (value.Length == 12) this.msisdn = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Invalid MSISDN length", exc);
                }
            }
        }

        public DateTime CallStartTime 
        {
            get
            {
                return this.callStartTime;
            }
            set
            {
                this.callStartTime = value;
            }
        }

        public int CallDuration 
        {
            get
            {
                return this.callDuration;
            }
            set
            {
                try
                {
                    if (value >= 0) this.callDuration = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Call Duration must be non negative number", exc);
                }
            }
        }

        public string CurrentLocation 
        {
            get
            {
                return this.currentLocation;
            }
            set
            {
                int locFound = Array.IndexOf(Enum.GetNames(typeof(LocZone)).ToArray(), value);

                try
                {
                    if (locFound != -1) this.currentLocation = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Invalid Location", exc);
                }
            }
        }

        public string BParty 
        {
            get
            {
                return this.bParty;
            }
            set
            {
                int bPartyFound = Array.IndexOf(Enum.GetNames(typeof(DestZone)).ToArray(), value);

                try
                {
                    if (bPartyFound != -1) this.bParty = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Invalid Destination", exc);
                }
            }
        }

        public double Rate(int tariffIndex)
        {
            double chargeAmount = 0;

            if (tariffIndex > 1000)
            {
                if (this.callDuration >= 60) chargeAmount += 0.30 + (this.callDuration - 60) * 0.01;
                else chargeAmount += 0.30;
            }

            return chargeAmount;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}",this.msisdn, this.callStartTime, this.callDuration, this.currentLocation, this.bParty);
        }

        public void PrintClassData()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
