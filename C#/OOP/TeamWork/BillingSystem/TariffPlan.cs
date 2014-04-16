using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public sealed class Tariff
    {
        private static readonly Dictionary<string, Tuple<List<TariffPlan.Interval>, List<TariffPlan.Interval>>> table = new Dictionary<string, Tuple<List<TariffPlan.Interval>, List<TariffPlan.Interval>>>();
        private static readonly HashSet<TariffPlan> table1 = new HashSet<TariffPlan>();
        private Tariff() { }

        public static Dictionary<string, Tuple<List<TariffPlan.Interval>, List<TariffPlan.Interval>>> Table
        {
            get
            {
                return table;
            }
        }

        public static HashSet<TariffPlan> Table1
        {
            get
            {
                return table1;
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
        private const double defaultCallSubseqChargeableBlockPrice = 0.005;
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

        public TariffPlan(string planName)//, List<Interval> planFirstInterval = null, List<Interval> planSubseqInterval = null)
        {
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
            
            /*if (planFirstInterval == null || planSubseqInterval == null)
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
            }*/
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public void SetTariffPlanParam(string paramName, Interval chargeableBlockParams)
        {
            List<Interval> planFirstInterval = new List<Interval>();
            List<Interval> planSubseqInterval = new List<Interval>();

            switch (paramName)
            {
                case "firstCallInterval":   this.firstCallInterval.chargeableBlock = chargeableBlockParams.chargeableBlock;
                                            this.firstCallInterval.Price = chargeableBlockParams.Price;
                                            break;
                case "subseqCallInterval":  this.subseqCallInterval.chargeableBlock = chargeableBlockParams.chargeableBlock;
                                            this.subseqCallInterval.Price = chargeableBlockParams.Price;
                                            break;
                case "firstSMSInterval":    this.firstSMSInterval.chargeableBlock = chargeableBlockParams.chargeableBlock;
                                            this.firstSMSInterval.Price = chargeableBlockParams.Price;
                                            break;
                case "subseqSMSInterval":   this.subseqSMSInterval.chargeableBlock = chargeableBlockParams.chargeableBlock;
                                            this.subseqSMSInterval.Price = chargeableBlockParams.Price;
                                            break;
                case "firstGPRSInterval":   this.firstGPRSInterval.chargeableBlock = chargeableBlockParams.chargeableBlock;
                                            this.firstGPRSInterval.Price = chargeableBlockParams.Price;
                                            break;
                case "subseqGPRSInterval":  this.subseqGPRSInterval.chargeableBlock = chargeableBlockParams.chargeableBlock;
                                            this.subseqGPRSInterval.Price = chargeableBlockParams.Price;
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

            ChangeTariffPlan(this);
        }

        public Interval GetTariffPlanParam(string paramName)
        {
            Interval result = new Interval();

            switch (paramName)
            {
                case "firstCallInterval":   result.chargeableBlock = this.firstCallInterval.chargeableBlock;
                                            result.Price = this.firstCallInterval.Price;
                                            break;
                case "subseqCallInterval":  result.chargeableBlock = this.subseqCallInterval.chargeableBlock;
                                            result.Price = this.subseqCallInterval.Price;
                                            break;
                case "firstSMSInterval":    result.chargeableBlock = this.firstSMSInterval.chargeableBlock;
                                            result.Price = this.firstSMSInterval.Price;
                                            break;
                case "subseqSMSInterval":   result.chargeableBlock = this.subseqSMSInterval.chargeableBlock;
                                            result.Price = this.subseqSMSInterval.Price;
                                            break;
                case "firstGPRSInterval":   result.chargeableBlock = this.firstGPRSInterval.chargeableBlock;
                                            result.Price = this.firstGPRSInterval.Price;
                                            break;
                case "subseqGPRSInterval":  result.chargeableBlock = this.subseqGPRSInterval.chargeableBlock;
                                            result.Price = this.subseqGPRSInterval.Price;
                                            break;
            }

            return result;
        }
        
        public static List<string> GetTariffPlanNames()
        {
            List<string> allTariffPlanNames = new List<string>();
            foreach (var tariffPlan in Tariff.Table)
            {
                allTariffPlanNames.Add(tariffPlan.Key);    
            }

            return allTariffPlanNames;
        }

        //work with Hashset
        public static List<string> GetTariffPlanNames1()
        {
            List<string> allTariffPlanNames = new List<string>();
            foreach (var tariffPlan in Tariff.Table1)
            {
                allTariffPlanNames.Add(tariffPlan.Name);
            }

            return allTariffPlanNames;
        }
        
        private static Tuple<List<Interval>, List<Interval>> InitDefaultValues()
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
            try
            {
                if (!Tariff.Table.ContainsKey(planName)) Tariff.Table.Add(planName, planParams);
                else throw new BillingArgExc(string.Format("You have Tariff Plan with name {0}", planName));
            }
            catch (BillingArgExc exc)
            {
                System.Windows.MessageBox.Show(exc.Message);
            }
        }
        
        //work with Hashset
        public static void AddTariffPlan(TariffPlan planToAdd)
        {
            try
            {
                if (!Tariff.Table1.Contains(planToAdd)) Tariff.Table1.Add(planToAdd);
                else throw new BillingArgExc(string.Format("You have Tariff Plan with data {0}", planToAdd));
            }
            catch (BillingArgExc exc)
            {
                System.Windows.MessageBox.Show(exc.Message);
            }
        }

        public static void DeleteTariffPlan(string planName)
        {
            //if (tariffPlans.ContainsKey(planName)) tariffPlans.Remove(planName);
            try
            {
                if (Tariff.Table.ContainsKey(planName)) Tariff.Table.Remove(planName);
                else throw new BillingArgExc(string.Format("You do not have Tariff Plan with name {0}", planName));
            }
            catch (BillingArgExc exc)
            {
                System.Windows.MessageBox.Show(exc.Message);
            }
        }

        //work with Hashset
        public static void DeleteTariffPlan(TariffPlan planToDelete)
        {
            try
            {
                if (Tariff.Table1.Contains(planToDelete)) Tariff.Table1.Remove(planToDelete);
                else throw new BillingArgExc(string.Format("You do not have Tariff Plan with data {0}", planToDelete));
            }
            catch (BillingArgExc exc)
            {
                System.Windows.MessageBox.Show(exc.Message);
            }
        }

        public static void ChangeTariffPlan(string planName, Tuple<List<Interval>, List<Interval>> newPlanParams)
        {
            //if (tariffPlans.ContainsKey(planName))
            try
            {
                if (Tariff.Table.ContainsKey(planName))
                {
                    DeleteTariffPlan(planName);
                    AddTariffPlan(planName, newPlanParams);
                }
                else throw new BillingArgExc(string.Format("You do not have Tariff Plan with name {0}", planName));
            }
            catch(BillingArgExc exc)
            {
                System.Windows.MessageBox.Show(exc.Message);
            }
        }

        //work with Hashset
        public static void ChangeTariffPlan(TariffPlan planToChange)
        {
            try
            {
                if (Tariff.Table1.Contains(planToChange))
                {
                    DeleteTariffPlan(planToChange);
                    AddTariffPlan(planToChange);
                }
                else throw new BillingArgExc(string.Format("You do not have Tariff Plan with data {0}", planToChange));
            }
            catch (BillingArgExc exc)
            {
                System.Windows.MessageBox.Show(exc.Message);
            }
        }

        public static Tuple<List<TariffPlan.Interval>, List<TariffPlan.Interval>> FindTariffPlan(string planName)
        {
            if (Tariff.Table.ContainsKey(planName)) return Tariff.Table[planName];
            else throw new BillingArgExc(string.Format("You do not have Tariff Plan with name {0}", planName));                      
        }

        //work with Hashset
        public static TariffPlan FindTariffPlan(TariffPlan planToFind)
        {
            if (Tariff.Table1.Contains(planToFind))
            {
                foreach (var tariffPlan in Tariff.Table1)
                {
                    if (tariffPlan == planToFind) return tariffPlan;
                }
            }
            else throw new BillingArgExc(string.Format("You do not have Tariff Plan with data {0}", planToFind));

            return new TariffPlan(null);
        }

        public override bool Equals(object obj)
        {
            TariffPlan other = obj as TariffPlan;

            if (other == null) return false;

            return this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", this.name, this.firstCallInterval, this.subseqCallInterval, 
                this.firstSMSInterval, this.subseqSMSInterval, this.firstGPRSInterval, this.subseqGPRSInterval);
        }

        public string PrintClassData()
        {
            return this.ToString();
        }
    }
}
