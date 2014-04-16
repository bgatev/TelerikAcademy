using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
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
                    if (value.Length == 12 && value.All(char.IsDigit)) this.msisdn = value;
                    else throw new BillingArgExc("Invalid MSISDN length");
                }
                catch (BillingArgExc exc)
                {
                    System.Windows.MessageBox.Show(exc.Message);
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
                    else throw new BillingArgExc("Call Duration must be non negative number");
                }
                catch (BillingArgExc exc)
                {
                    System.Windows.MessageBox.Show(exc.Message);
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
                    else throw new BillingArgExc("Invalid Location");
                }
                catch (BillingArgExc exc)
                {
                    System.Windows.MessageBox.Show(exc.Message);
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
                    else throw new BillingArgExc("Invalid Destination");
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
            
            //Work with HashSet
            TariffPlan currentTariffPlan = TariffPlan.FindTariffPlan(Tariff.Table1.FirstOrDefault(plan => plan.Name == tariffPlan));
            TariffPlan.Interval firstCall = currentTariffPlan.GetTariffPlanParam("firstCallInterval");
            TariffPlan.Interval subseqCall = currentTariffPlan.GetTariffPlanParam("subseqCallInterval");

            if (this.callDuration >= firstCall.chargeableBlock)
                chargeAmount += firstCall.Price + (this.callDuration - firstCall.chargeableBlock) / subseqCall.chargeableBlock * subseqCall.Price;
            else chargeAmount += firstCall.Price;

            if (firstDigit == 4) chargeAmount *= 1.2;   // 20% up for non-BG bparty
            
            switch (secondDigit)
            {
                case 2: chargeAmount *= 1.1; break;     // 10% up for EU calls
                case 3: chargeAmount *= 2; break;       // double price for non-EU calls
                case 4: chargeAmount *= 3; break;       // triple price for other world calls
            }

            if (fourthDigit == 2) chargeAmount *= 0.9;  // 10% down for non-rush timezone

            return chargeAmount;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}",this.msisdn, this.callStartTime, this.callDuration, this.currentLocation, this.bParty);
        }

        public string PrintClassData()
        {
            return this.ToString();
        }
    }
}
