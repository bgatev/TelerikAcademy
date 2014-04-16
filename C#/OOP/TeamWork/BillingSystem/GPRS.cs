using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class GPRS : IChargeable, IPrintable
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
                    if (value.Length == 12 && value.All(char.IsDigit)) this.msisdn = value;
                    else throw new BillingArgExc("Invalid MSISDN length");
                }
                catch (BillingArgExc exc)
                {
                    System.Windows.MessageBox.Show(exc.Message);
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
                    else throw new BillingArgExc("Invalid Location");
                }
                catch (BillingArgExc exc)
                {
                    System.Windows.MessageBox.Show(exc.Message);
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
                    else throw new BillingArgExc("Invalid Carrier");
                }
                catch (BillingArgExc exc)
                {                  
                    System.Windows.MessageBox.Show(exc.Message);
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
                    else throw new BillingArgExc("Number of Bytes must be non negative number");
                }
                catch (BillingArgExc exc)
                {
                    System.Windows.MessageBox.Show(exc.Message);
                }
            }
        }

        public double Rate(int tariffIndex, string tariffPlan)
        {
            double chargeAmount = 0;

            int firstDigit = tariffIndex / 1000;
            int secondDigit = (tariffIndex / 100) % 10;
            int fourthDigit = tariffIndex % 10;

            /*Tuple<List<TariffPlan.Interval>, List<TariffPlan.Interval>> currentTariffPlan = TariffPlan.FindTariffPlan(tariffPlan);
            TariffPlan.Interval firstGPRS = currentTariffPlan.Item1[2];
            TariffPlan.Interval subseqGPRS = currentTariffPlan.Item2[2];*/

            //Work with HashSet
            TariffPlan currentTariffPlan = TariffPlan.FindTariffPlan(Tariff.Table1.FirstOrDefault(plan => plan.Name == tariffPlan));
            TariffPlan.Interval firstGPRS = currentTariffPlan.GetTariffPlanParam("firstGPRSInterval");
            TariffPlan.Interval subseqGPRS = currentTariffPlan.GetTariffPlanParam("subseqGPRSInterval");

            if (this.numberOfBytes >= firstGPRS.chargeableBlock)
                chargeAmount += firstGPRS.Price + (this.numberOfBytes - firstGPRS.chargeableBlock) / subseqGPRS.chargeableBlock * subseqGPRS.Price;
            else chargeAmount += firstGPRS.Price;

            switch (firstDigit)
            {
                case 2: chargeAmount *= 1.2; break;     // 20% up for 3G sessions
                case 3: chargeAmount *= 1.7; break;     // 170% up for HSPA sessions
                case 4: chargeAmount *= 2.5; break;     // 250% up for LTE sessions
            }

            switch (secondDigit)
            {
                case 2: chargeAmount *= 1.1; break;     // 10% up for EU sessions
                case 3: chargeAmount *= 2; break;       // double price for non-EU sessions
                case 4: chargeAmount *= 3; break;       // triple price for other world sessions
            }

            if (fourthDigit == 2) chargeAmount *= 0.9;  // 10% down for non-rush timezone

            return chargeAmount;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", this.msisdn, this.gprsStartTime, this.currentLocation, this.carrier, this.numberOfBytes);
        }

        public string PrintClassData()
        {
            return this.ToString();
        }
    }
}
