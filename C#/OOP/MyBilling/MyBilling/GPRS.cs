using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public class GPRS : IChargeable,IPrintable
    {
        private string msisdn;
        private DateTime gprsStartTime;
        private string currentLocation;
        private string carrier;
        private long numberOfBytes;

        public GPRS(params object[] gprsParams)
        {
            this.MSISDN = gprsParams[0] as string;
            this.gprsStartTime = DateTime.Parse(gprsParams[1] as string);
            this.CurrentLocation = new Location().Index(gprsParams[2]);
            this.Carrier = new CarrierType().Index(gprsParams[3]);
            this.NumberOfBytes = long.Parse(gprsParams[4] as string);
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

        public DateTime GPRSStartTime 
        {
            get
            {
                return this.gprsStartTime;
            }
            set
            {
                this.gprsStartTime = value;
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

        public long NumberOfBytes
        {
            get
            {
                return this.numberOfBytes;
            }
            set
            {
                try
                {
                    if (value >= 0) this.numberOfBytes = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Number of Bytes must be non negative number", exc);
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
            return string.Format("{0} {1} {2} {3} {4}", this.msisdn, this.gprsStartTime, this.currentLocation, this.carrier, this.numberOfBytes);
        }

        public void PrintClassData()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
