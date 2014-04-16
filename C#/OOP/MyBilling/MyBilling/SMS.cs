using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public class SMS : IChargeable, IPrintable, IRequiredNumbers
    {
        private string msisdn;
        private DateTime smsSendTime;
        private string currentLocation;
        private string bParty;
        private string carrier;
        private int numberOfSymbols;

        public SMS(params object[] smsParams)
        {
            this.MSISDN = smsParams[0] as string;
            this.smsSendTime = DateTime.Parse(smsParams[1] as string);
            this.CurrentLocation = new Location().Index(smsParams[2]);
            this.BParty = new Destination().Index((smsParams[3] as string).Substring(0, 6));
            this.Carrier = new CarrierType().Index(smsParams[4]);
            this.NumberOfSymbols = int.Parse(smsParams[5] as string);
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

        public DateTime SmsSendTime 
        {
            get
            {
                return this.smsSendTime;
            }
            set
            {
                this.smsSendTime = value;
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

        public string Carrier
        {
            get
            {
                return this.carrier;
            }
            set
            {
                int carrierFound = Array.IndexOf(Enum.GetNames(typeof(GPRSZone)).ToArray(), value);

                try
                {
                    if (carrierFound != -1) this.carrier = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Invalid Carrier", exc);
                }
            }
        }

        public int NumberOfSymbols
        {
            get
            {
                return this.numberOfSymbols;
            }
            set
            {
                try
                {
                    if (value >= 0) this.numberOfSymbols = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Number of Symbols must be non negative number", exc);
                }
            }
        }

        public double Rate(int tariffIndex)
        {
            double charge = 0;

            //TODO: search for the tariff index in the rating data
            //If match found, read the First And Subsequent Interval data

            //Calculate the charges. The Formula will be provided.
            //Return the charge
            //If no Index found, apply Default data.
            //Default tariff index is 0. It must be administered within the file holding the rating data,
            //among with the other indexes

            return charge;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", this.msisdn, this.smsSendTime, this.currentLocation, this.bParty, this.carrier, this.numberOfSymbols);
        }

        public void PrintClassData()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
