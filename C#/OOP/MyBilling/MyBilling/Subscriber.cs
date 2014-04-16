using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public sealed class Clients
    {
        private static readonly Dictionary<string, Tuple<string, string, string, double>> table = new Dictionary<string, Tuple<string, string, string, double>>();
        private Clients() { }

        public static Dictionary<string, Tuple<string, string, string, double>> Table
        {
            get
            {
                return table;
            }
        }
    }

    public class Subscriber:IPrintable
    {
        private string msisdn, name, egn, tariffPlanName;
        private double account;

        //private Dictionary<string, Tuple<string, string, string, double>> clients = new Dictionary<string, Tuple<string, string, string, double>>();

        public Subscriber(string subscriberMSISDN, string subscriberName, string subscriberEGN)
        {
            this.MSISDN = subscriberMSISDN;
            this.Name = subscriberName;
            this.EGN = subscriberEGN;
            AddSubscriber(this.msisdn, new Tuple<string,string,string,double>(this.name,this.egn,this.tariffPlanName,this.account));
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
                    if (value.Length == 12) this.msisdn = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Invalid Subscriber MSISDN", exc);
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
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Invalid Subscriber Name", exc);
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
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Invalid Subscriber EGN", exc);
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
                    if (Tariff.Table.ContainsKey(value)) this.tariffPlanName = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Invalid Subscriber Tariff Plan", exc);
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
                    if (value > 0) this.account = value;
                    else throw new BillingArgExc();
                }
                catch (BillingArgExc exc)
                {
                    throw new BillingArgExc("Invalid Subscriber Account", exc);
                }
            }
        }

        private static void AddSubscriber(string subscriberMSISDN, Tuple<string, string, string, double> newSubscriberParams)
        {
            //clients.Add(this.msisdn, new Tuple<string, string, string, double>(this.name, this.egn, this.tariffPlanName, this.account));
            Clients.Table.Add(subscriberMSISDN, newSubscriberParams);             
        }

        public static void ChangeSubscriber(string subscriberMSISDN, Tuple<string, string, string, double> newSubscriberParams)
        {
            //if (tariffPlans.ContainsKey(planName))
            if (Clients.Table.ContainsKey(subscriberMSISDN))
            {
                DeleteSubscriber(subscriberMSISDN);
                AddSubscriber(subscriberMSISDN,newSubscriberParams);
            }
            else throw new BillingArgExc(string.Format("You do not have Subscriber with MSISDN {0}", subscriberMSISDN));
        }

        public static void DeleteSubscriber(string subscriberMSISDN)
        {
            //if (clients.ContainsKey(subscriberMSISDN)) clients.Remove(subscriberMSISDN);
            if (Clients.Table.ContainsKey(subscriberMSISDN)) Clients.Table.Remove(subscriberMSISDN);
            else throw new BillingArgExc(string.Format("You do not have Subscriber with MSISDN {0}", subscriberMSISDN));
        }

        public void ChangeTariffPlan(string newTariffPlanName)
        {
            this.TariffPlanName = newTariffPlanName;
            ChangeSubscriber(this.msisdn, new Tuple<string, string, string, double>(this.name, this.egn, this.tariffPlanName, this.account));
        }

        public void UpdateAccount(double subscriberNewAccount)
        {
            this.account = subscriberNewAccount;
            ChangeSubscriber(this.msisdn, new Tuple<string, string, string, double>(this.name, this.egn, this.tariffPlanName, this.account));
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", this.name, this.egn, this.msisdn, this.tariffPlanName, this.account);
        }

        public static void PrintClientsTable()
        {
            foreach (var item in Clients.Table)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintClassData()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
