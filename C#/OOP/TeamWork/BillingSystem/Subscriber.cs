using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public sealed class Clients
    {
        private static readonly Dictionary<string, Tuple<string, string, string, double>> table = new Dictionary<string, Tuple<string, string, string, double>>();
        private static readonly HashSet<Subscriber> table1 = new HashSet<Subscriber>();
        private Clients() { }

        public static Dictionary<string, Tuple<string, string, string, double>> Table
        {
            get
            {
                return table;
            }
        }

        public static HashSet<Subscriber> Table1
        {
            get
            {
                return table1;
            }
        }
    }

    public class Subscriber : IPrintable
    {
        private string msisdn, name, egn, tariffPlanName;
        private double account;

        //private Dictionary<string, Tuple<string, string, string, double>> clients = new Dictionary<string, Tuple<string, string, string, double>>();

        public Subscriber()
        {
        }

        public Subscriber(string subscriberMSISDN, string subscriberName, string subscriberEGN)
        {
            this.MSISDN = subscriberMSISDN;
            this.Name = subscriberName;
            this.EGN = subscriberEGN;
            //AddSubscriber(this.msisdn, new Tuple<string, string, string, double>(this.name, this.egn, this.tariffPlanName, this.account)); //work with Hashset
        }

        public Subscriber(string subscriberMSISDN, string subscriberName, string subscriberEGN, string subscriberTariffPlan, double subscriberAccount)
        {
            this.MSISDN = subscriberMSISDN;
            this.Name = subscriberName;
            this.EGN = subscriberEGN;
            this.TariffPlanName = subscriberTariffPlan;
            this.Account = subscriberAccount;
        }

        public string MSISDN
        {
            get
            {
                return this.msisdn;
            }
            private set
            {
                try
                {
                    if (value.Length == 12 && value.All(char.IsDigit)) this.msisdn = value;
                    //else throw new BillingArgExc();
                    else throw new BillingArgExc("Invalid Subscriber MSISDN");
                }
                catch (BillingArgExc exc)
                {
                    //throw new BillingArgExc("Invalid Subscriber MSISDN", exc);
                    System.Windows.MessageBox.Show(exc.Message);
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                try
                {
                    if (value.Length > 3) this.name = value;
                    //else throw new BillingArgExc();
                    else throw new BillingArgExc("Invalid Subscriber Name");
                }
                catch (BillingArgExc exc)
                {
                    //throw new BillingArgExc("Invalid Subscriber Name", exc);
                    System.Windows.MessageBox.Show(exc.Message);
                }
            }
        }

        public string EGN
        {
            get
            {
                return this.egn;
            }
            private set
            {
                try
                {
                    if (value.Length == 10) this.egn = value;
                    //else throw new BillingArgExc();
                    else throw new BillingArgExc("Invalid Subscriber EGN");
                }
                catch (BillingArgExc exc)
                {
                    //throw new BillingArgExc("Invalid Subscriber EGN", exc);
                    System.Windows.MessageBox.Show(exc.Message);
                }
            }
        }

        public string TariffPlanName
        {
            get
            {
                return this.tariffPlanName;
            }
            private set
            {
                try
                {
                    if (Tariff.Table1.Contains(Tariff.Table1.FirstOrDefault(plan=>plan.Name == value))) this.tariffPlanName = value;
                    //else throw new BillingArgExc();
                    else throw new BillingArgExc("Invalid Subscriber Tariff Plan");
                }
                catch (BillingArgExc exc)
                {
                    //throw new BillingArgExc("Invalid Subscriber Tariff Plan", exc);
                    System.Windows.MessageBox.Show(exc.Message);
                }
            }
        }

        public double Account
        {
            get
            {
                return this.account;
            }
            private set
            {
                try
                {
                    if (value >= 0) this.account = value;
                    //else throw new BillingArgExc();
                    else throw new BillingArgExc("Invalid Subscriber Account");
                }
                catch (BillingArgExc exc)
                {
                    //throw new BillingArgExc("Invalid Subscriber Account", exc);
                    System.Windows.MessageBox.Show(exc.Message);
                }
            }
        }

        public static void AddSubscriber(string subscriberMSISDN, Tuple<string, string, string, double> newSubscriberParams)
        {
            //clients.Add(this.msisdn, new Tuple<string, string, string, double>(this.name, this.egn, this.tariffPlanName, this.account));
            try
            {
                Clients.Table.Add(subscriberMSISDN, newSubscriberParams);
            }
            catch (ArgumentNullException exc)
            {
                System.Windows.MessageBox.Show(exc.Message);
            }
        }
        
        //work with Hashset
        public static void AddSubscriber(Subscriber newSubscriber)
        {
            try
            {
                Clients.Table1.Add(newSubscriber);
            }
            catch (ArgumentNullException exc)
            {
                System.Windows.MessageBox.Show(exc.Message);
            }
        }

        public static void ChangeSubscriber(string subscriberMSISDN, Tuple<string, string, string, double> newSubscriberParams)
        {
            //if (tariffPlans.ContainsKey(planName))
            if (Clients.Table.ContainsKey(subscriberMSISDN))
            {
                DeleteSubscriber(subscriberMSISDN);
                AddSubscriber(subscriberMSISDN, newSubscriberParams);
            }
            else throw new BillingArgExc(string.Format("You do not have Subscriber with MSISDN {0}", subscriberMSISDN));
        }
        
        //work with Hashset
        public static void ChangeSubscriber(Subscriber subscriberToChange, Tuple<string, double> newSubscriberParams)
        {
            Subscriber newSubscriber = subscriberToChange;

            if (Clients.Table1.Contains(subscriberToChange))
            {
                DeleteSubscriber(subscriberToChange);
                newSubscriber.TariffPlanName = newSubscriberParams.Item1.ToString();
                newSubscriber.Account = newSubscriberParams.Item2;
                AddSubscriber(newSubscriber);
            }
            else throw new BillingArgExc(string.Format("You do not have Subscriber with data {0}", subscriberToChange));
        }

        public static void DeleteSubscriber(string subscriberMSISDN)
        {
            //if (clients.ContainsKey(subscriberMSISDN)) clients.Remove(subscriberMSISDN);
            if (Clients.Table.ContainsKey(subscriberMSISDN)) Clients.Table.Remove(subscriberMSISDN);
            else throw new BillingArgExc(string.Format("You do not have Subscriber with MSISDN {0}", subscriberMSISDN));
        }
        
        //work with Hashset
        public static void DeleteSubscriber(Subscriber subscriberToDelete)
        {
            if (Clients.Table1.Contains(subscriberToDelete)) Clients.Table1.Remove(subscriberToDelete);
            else throw new BillingArgExc(string.Format("You do not have Subscriber with data {0}", subscriberToDelete.ToString()));
        }

        public static Tuple<string, string, string, double> FindSubscriber(string subscriberMSISDN)
        {
            if (Clients.Table.ContainsKey(subscriberMSISDN)) return Clients.Table[subscriberMSISDN];
            else throw new BillingArgExc(string.Format("You do not have Subscriber with MSISDN {0}", subscriberMSISDN));
        }

        //work with Hashset
        public static Subscriber FindSubscriber(Subscriber subscriberToFind)
        {
            if (Clients.Table1.Contains(subscriberToFind))
            {
                foreach (var subscriber in Clients.Table1)
                {
                    if (subscriber == subscriberToFind) return subscriber;    
                }
            }
            else throw new BillingArgExc(string.Format("You do not have Subscriber with data {0}", subscriberToFind));

            return new Subscriber(null, null, null);
        }
        
        public void ChangeTariffPlan(string newTariffPlanName)
        {
            this.TariffPlanName = newTariffPlanName;
            //ChangeSubscriber(this.msisdn, new Tuple<string, string, string, double>(this.name, this.egn, this.tariffPlanName, this.account));
            ChangeSubscriber(this, new Tuple<string, double>(this.tariffPlanName, this.account));
        }

        public void UpdateAccount(double subscriberNewAccount)
        {
            this.account = subscriberNewAccount;
            //ChangeSubscriber(this.msisdn, new Tuple<string, string, string, double>(this.name, this.egn, this.tariffPlanName, this.account));
            ChangeSubscriber(this, new Tuple<string, double>(this.tariffPlanName, this.account));
        }

        public override bool Equals(object obj)
        {
            Subscriber other = obj as Subscriber;
            
            if (other == null) return false;
            
            return this.MSISDN == other.MSISDN;
        }

        public override int GetHashCode()
        {
            return this.MSISDN.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", this.name, this.egn, this.msisdn, this.tariffPlanName, this.account);
        }

        public static string PrintClientsTable()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var subscriber in Clients.Table)
            {
                string key = subscriber.Key;
                Tuple<string, string, string, double> values = subscriber.Value;

                sb.Append(string.Format("MSISDN: {0}", key));
                sb.Append(string.Format("\nName: {0}", values.Item1));
                sb.Append(string.Format("\nEGN: {0}", values.Item2));
                sb.Append(string.Format("\nTariff Plan: {0}", values.Item3));
                sb.Append(string.Format("\nAccount: {0}\n\n", values.Item4));
            }

            return sb.ToString();
        }

        //work with Hashset
        public static string PrintClientsTable1()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var subscriber in Clients.Table1)
            {
                sb.Append(string.Format("MSISDN: {0}", subscriber.MSISDN));
                sb.Append(string.Format("\nName: {0}", subscriber.Name));
                sb.Append(string.Format("\nEGN: {0}", subscriber.EGN));
                sb.Append(string.Format("\nTariff Plan: {0}", subscriber.TariffPlanName));
                sb.Append(string.Format("\nAccount: {0}\n\n", subscriber.Account));
            }

            return sb.ToString();
        }

        public string PrintClassData()
        {
            return this.ToString();
        }
    }
}
