using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public sealed class Tariff
    {
        private static readonly Dictionary<string, Tuple<List<MyBilling.TariffPlan.Interval>, List<MyBilling.TariffPlan.Interval>>> table = new Dictionary<string, Tuple<List<MyBilling.TariffPlan.Interval>, List<MyBilling.TariffPlan.Interval>>>();
        private Tariff() { }

        public static Dictionary<string, Tuple<List<MyBilling.TariffPlan.Interval>, List<MyBilling.TariffPlan.Interval>>> Table
        {
            get
            {
                return table;
            }
        }
    }
    
    public class TariffPlan:IPrintable
    {
        private const long defaultCallFirstChargeableBlock = 60;
        private const double defaultCallFirstChargeableBlockPrice = 0.30;
        private const long defaultSMSFirstChargeableBlock = 1;
        private const double defaultSMSFirstChargeableBlockPrice = 0.20;
        private const long defaultGPRSFirstChargeableBlock = 1000;
        private const double defaultGPRSFirstChargeableBlockPrice = 0.01;

        private const long defaultCallSubseqChargeableBlock = 1;
        private const double defaultCallSubseqChargeableBlockPrice = 0.003;
        private const long defaultSMSSubseqChargeableBlock = 1;
        private const double defaultSMSSubseqChargeableBlockPrice = 0.20;
        private const long defaultGPRSSubseqChargeableBlock = 1000;
        private const double defaultGPRSSubseqChargeableBlockPrice = 0.01;

        public struct Interval
        {
            public long chargeableBlock { get; set; }
            public double Price { get; set; }

            public override string ToString()
            {
                return string.Format("{0} {1:0.00}",this.chargeableBlock, this.Price);
            }
        }

        //private static Dictionary<string, Tuple<List<Interval>, List<Interval>>> tariffPlans = new Dictionary<string, Tuple<List<Interval>, List<Interval>>>();
        private string name;
        private Interval firstCallInterval;
        private Interval subseqCallInterval;
        private Interval firstSMSInterval;
        private Interval subseqSMSInterval;
        private Interval firstGPRSInterval;
        private Interval subseqGPRSInterval;

        public TariffPlan(string planName, List<Interval> planFirstInterval = null, List<Interval> planSubseqInterval = null)
        {
            if (planFirstInterval == null || planSubseqInterval == null)
            {
                AddTariffPlan(planName, InitDefaultValues());
                this.name = planName;
                this.firstCallInterval.chargeableBlock = defaultCallFirstChargeableBlock;
                this.firstCallInterval.Price = defaultCallFirstChargeableBlockPrice;
                this.subseqCallInterval.chargeableBlock = defaultCallSubseqChargeableBlock;
                this.subseqCallInterval.Price = defaultCallSubseqChargeableBlockPrice;
                this.firstSMSInterval.chargeableBlock = defaultSMSFirstChargeableBlock;
                this.firstSMSInterval.Price = defaultSMSFirstChargeableBlockPrice;
                this.subseqSMSInterval.chargeableBlock = defaultSMSSubseqChargeableBlock;
                this.subseqSMSInterval.Price = defaultSMSSubseqChargeableBlockPrice;
                this.firstGPRSInterval.chargeableBlock = defaultGPRSFirstChargeableBlock;
                this.firstGPRSInterval.Price = defaultGPRSFirstChargeableBlockPrice;
                this.subseqGPRSInterval.chargeableBlock = defaultGPRSSubseqChargeableBlock;
                this.subseqGPRSInterval.Price = defaultGPRSSubseqChargeableBlockPrice;
            }
            else
            {
                AddTariffPlan(planName, new Tuple<List<Interval>, List<Interval>>(planFirstInterval, planSubseqInterval));
                this.name = planName;
                this.firstCallInterval = planFirstInterval[0];
                this.subseqCallInterval = planSubseqInterval[0];
                this.firstSMSInterval = planFirstInterval[1];
                this.subseqSMSInterval = planSubseqInterval[1];
                this.firstGPRSInterval = planFirstInterval[2];
                this.subseqGPRSInterval = planSubseqInterval[2];
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public void SetTariffPlanParam(string paramName, long chargeableBlockValue, double chargeableBlockPrice)
        {
            List<Interval> planFirstInterval = new List<Interval>();
            List<Interval> planSubseqInterval = new List<Interval>();

            switch (paramName)
            {
                case "firstCallInterval":   this.firstCallInterval.chargeableBlock = chargeableBlockValue;
                                            this.firstCallInterval.Price = chargeableBlockPrice;
                                            break;
                case "subseqCallInterval":  this.subseqCallInterval.chargeableBlock = chargeableBlockValue;
                                            this.subseqCallInterval.Price = chargeableBlockPrice;
                                            break;
                case "firstSMSInterval":    this.firstSMSInterval.chargeableBlock = chargeableBlockValue;
                                            this.firstSMSInterval.Price = chargeableBlockPrice;
                                            break;
                case "subseqSMSInterval":   this.subseqSMSInterval.chargeableBlock = chargeableBlockValue;
                                            this.subseqSMSInterval.Price = chargeableBlockPrice;
                                            break;
                case "firstGPRSInterval":   this.firstGPRSInterval.chargeableBlock = chargeableBlockValue;
                                            this.firstGPRSInterval.Price = chargeableBlockPrice;
                                            break;
                case "subseqGPRSInterval":  this.subseqGPRSInterval.chargeableBlock = chargeableBlockValue;
                                            this.subseqGPRSInterval.Price = chargeableBlockPrice;
                                            break;
                default:
                    break;
            }

            planFirstInterval.Add(firstCallInterval);
            planFirstInterval.Add(firstSMSInterval);
            planFirstInterval.Add(firstGPRSInterval);
            planSubseqInterval.Add(subseqCallInterval);
            planSubseqInterval.Add(subseqSMSInterval);
            planSubseqInterval.Add(subseqGPRSInterval);

            ChangeTariffPlan(this.name,new Tuple<List<Interval>, List<Interval>>(planFirstInterval, planSubseqInterval));
        }

        public string[] GetTariffPlanParam(string paramName)
        {
            string[] result = new string[2];

            switch (paramName)
            {
                case "firstCallInterval":   result[0] = this.firstCallInterval.chargeableBlock.ToString();
                                            result[1] = this.firstCallInterval.Price.ToString();
                                            break;
                case "subseqCallInterval":  result[0] = this.subseqCallInterval.chargeableBlock.ToString();
                                            result[1] = this.subseqCallInterval.Price.ToString();
                                            break;
                case "firstSMSInterval":    result[0] = this.firstSMSInterval.chargeableBlock.ToString();
                                            result[1] = this.firstSMSInterval.Price.ToString();
                                            break;
                case "subseqSMSInterval":   result[0] = this.subseqSMSInterval.chargeableBlock.ToString();
                                            result[1] = this.subseqSMSInterval.Price.ToString();
                                            break;
                case "firstGPRSInterval":   result[0] = this.firstGPRSInterval.chargeableBlock.ToString();
                                            result[1] = this.firstGPRSInterval.Price.ToString();
                                            break;
                case "subseqGPRSInterval":  result[0] = this.subseqGPRSInterval.chargeableBlock.ToString();
                                            result[1] = this.subseqGPRSInterval.Price.ToString();
                                            break;
            }

            return result;
        }

        private Tuple<List<Interval>, List<Interval>> InitDefaultValues()
        {
            Interval defaultFirstCallValue = new Interval();
            Interval defaultFirstSMSValue = new Interval();
            Interval defaultFirstGPRSValue = new Interval();

            Interval defaultSubseqCallValue = new Interval();
            Interval defaultSubseqSMSValue = new Interval();
            Interval defaultSubseqGPRSValue = new Interval();

            List<Interval> defaultFirstInterval = new List<Interval>();
            List<Interval> defaultSubseqInterval = new List<Interval>();
            Tuple<List<Interval>, List<Interval>> defaultValue = new Tuple<List<Interval>, List<Interval>>(defaultFirstInterval, defaultSubseqInterval);

            defaultFirstCallValue.chargeableBlock = defaultCallFirstChargeableBlock;
            defaultFirstCallValue.Price = defaultCallFirstChargeableBlockPrice;
            defaultFirstSMSValue.chargeableBlock = defaultSMSFirstChargeableBlock;
            defaultFirstSMSValue.Price = defaultSMSFirstChargeableBlockPrice;
            defaultFirstGPRSValue.chargeableBlock = defaultGPRSFirstChargeableBlock;
            defaultFirstGPRSValue.Price = defaultGPRSFirstChargeableBlockPrice;

            defaultSubseqCallValue.chargeableBlock = defaultCallSubseqChargeableBlock;
            defaultSubseqCallValue.Price = defaultCallSubseqChargeableBlockPrice;
            defaultSubseqSMSValue.chargeableBlock = defaultSMSSubseqChargeableBlock;
            defaultSubseqSMSValue.Price = defaultSMSSubseqChargeableBlockPrice;
            defaultSubseqGPRSValue.chargeableBlock = defaultGPRSSubseqChargeableBlock;
            defaultSubseqGPRSValue.Price = defaultGPRSSubseqChargeableBlockPrice;
                        
            defaultFirstInterval.Add(defaultFirstCallValue);
            defaultFirstInterval.Add(defaultFirstSMSValue);
            defaultFirstInterval.Add(defaultFirstGPRSValue);

            defaultSubseqInterval.Add(defaultSubseqCallValue);
            defaultSubseqInterval.Add(defaultSubseqSMSValue);
            defaultSubseqInterval.Add(defaultSubseqGPRSValue);

            return defaultValue;
        }

        public static void AddTariffPlan(string planName, Tuple<List<Interval>, List<Interval>> planParams)
        {
            //if (!tariffPlans.ContainsKey(planName)) tariffPlans.Add(planName, planParams);
            if (!Tariff.Table.ContainsKey(planName)) Tariff.Table.Add(planName, planParams);
            else throw new BillingArgExc(string.Format("You have Tariff Plan with name {0}", planName));
        }

        public static void DeleteTariffPlan(string planName)
        {
            //if (tariffPlans.ContainsKey(planName)) tariffPlans.Remove(planName);
            if (Tariff.Table.ContainsKey(planName)) Tariff.Table.Remove(planName);
            else throw new BillingArgExc(string.Format("You do not have Tariff Plan with name {0}", planName));
        }

        public static void ChangeTariffPlan(string planName, Tuple<List<Interval>, List<Interval>> newPlanParams)
        {
            //if (tariffPlans.ContainsKey(planName))
            if (Tariff.Table.ContainsKey(planName))
            {
                DeleteTariffPlan(planName);
                AddTariffPlan(planName, newPlanParams);
            }
            else throw new BillingArgExc(string.Format("You do not have Tariff Plan with name {0}", planName));
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", this.name, this.firstCallInterval, this.subseqCallInterval, 
                this.firstSMSInterval, this.subseqSMSInterval, this.firstGPRSInterval, this.subseqGPRSInterval);
        }

        public void PrintClassData()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
