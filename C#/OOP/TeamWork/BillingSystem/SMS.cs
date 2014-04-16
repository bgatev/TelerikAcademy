using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
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
                    if (value.Length == 12 && value.All(char.IsDigit)) this.msisdn = value;
                    else throw new BillingArgExc("Invalid MSISDN length");
                }
                catch (BillingArgExc exc)
                {
                    System.Windows.MessageBox.Show(exc.Message);
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
                    else throw new BillingArgExc("Number of Symbols must be non negative number");
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
            TariffPlan.Interval firstSMS = currentTariffPlan.Item1[1];
            TariffPlan.Interval subseqSMS = currentTariffPlan.Item2[1];*/

            //Work with HashSet
            TariffPlan currentTariffPlan = TariffPlan.FindTariffPlan(Tariff.Table1.FirstOrDefault(plan => plan.Name == tariffPlan));
            TariffPlan.Interval firstSMS = currentTariffPlan.GetTariffPlanParam("firstSMSInterval");
            TariffPlan.Interval subseqSMS = currentTariffPlan.GetTariffPlanParam("subseqSMSInterval");

            if (this.numberOfSymbols >= (firstSMS.chargeableBlock * 160))
                chargeAmount += firstSMS.Price + (this.numberOfSymbols - firstSMS.chargeableBlock * 160) / (subseqSMS.chargeableBlock * 160) * subseqSMS.Price;
            else chargeAmount += firstSMS.Price;

            if (firstDigit == 4) chargeAmount *= 1.2;   // 20% up for non-BG bparty

            switch (secondDigit)
            {
                case 2: chargeAmount *= 1.1; break;     // 10% up for EU sms
                case 3: chargeAmount *= 2; break;       // double price for non-EU sms
                case 4: chargeAmount *= 3; break;       // triple price for other world sms
            }

            if (fourthDigit == 2) chargeAmount *= 0.9;  // 10% down for non-rush timezone

            return chargeAmount;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", this.msisdn, this.smsSendTime, this.currentLocation, this.bParty, this.carrier, this.numberOfSymbols);
        }

        public string PrintClassData()
        {
            return this.ToString();
        }
    }
}
