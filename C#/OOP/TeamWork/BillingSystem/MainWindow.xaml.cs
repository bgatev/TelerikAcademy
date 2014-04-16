using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BillingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private bool tariffPlanInit = true, createIndexTable = true, createIndexTableGPRS = true, printGPRS = true;
        public const string defaultTariffPlan = "MyDefaultPlan";
        public DBConnect billingSystemDB = new DBConnect();

        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            InitializeComponent();

            //init IndexTables
            RatingItems rating = new RatingItemsCommon(createIndexTable);
            RatingItems ratingGPRS = new RatingItemsCommon(false, createIndexTableGPRS);
        }

        private void TariffPlanAllTextBoxInit(object sender, EventArgs e)
        {
            OnSubscriberTariffPlanLoaded(sender, e);
            OnTariffPlanNameTextBoxInit(sender, e);
            OnFirstCallIntervalBlockTextBoxInit(sender, e);
            OnFirstCallIntervalPriceTextBoxInit(sender, e);
            OnFirstSMSIntervalBlockTextBoxInit(sender, e);
            OnFirstSMSIntervalPriceTextBoxInit(sender, e);
            OnFirstGPRSIntervalBlockTextBoxInit(sender, e);
            OnFirstGPRSIntervalPriceTextBoxInit(sender, e);
            OnSubseqCallIntervalBlockTextBoxInit(sender, e);
            OnSubseqCallIntervalPriceTextBoxInit(sender, e);
            OnSubseqSMSIntervalBlockTextBoxInit(sender, e);
            OnSubseqSMSIntervalPriceTextBoxInit(sender, e);
            OnSubseqGPRSIntervalBlockTextBoxInit(sender, e);
            OnSubseqGPRSIntervalPriceTextBoxInit(sender, e);
        }

        private void SubscriberAllTextBoxInit(object sender, EventArgs e)
        {
            OnSubscriberMSISDNTextBoxInit(sender, e);
            OnSubscriberNameTextBoxInit(sender, e);
            OnSubscriberEGNTextBoxInit(sender, e);
            OnSubscriberAccountTextBoxInit(sender, e);
            OnSubscriberTariffPlanLoaded(sender, e);
        }

        private void OnSubscriberMSISDNTextBoxInit(object sender, EventArgs e)
        {
            this.SubscriberMSISDN.Text = string.Empty;
        }

        private void OnSubscriberNameTextBoxInit(object sender, EventArgs e)
        {
            this.SubscriberName.Text = string.Empty;
        }

        private void OnSubscriberEGNTextBoxInit(object sender, EventArgs e)
        {
            this.SubscriberEGN.Text = string.Empty;
        }    

        private void OnSubscriberAccountTextBoxInit(object sender, EventArgs e)
        {
            this.SubscriberAccount.Text = string.Empty;
        }

        private void OnSubscriberTariffPlanLoaded(object sender, EventArgs e)
        {
            this.SubscriberTariffPlan.Items.Clear();
            this.SubscriberTariffPlan.IsEditable = true; //must be true to display .Text
            this.SubscriberTariffPlan.Text = "Please choose:";

            //List<string> allTariffPlanNames = TariffPlan.GetTariffPlanNames();
            List<string> allTariffPlanNames = billingSystemDB.SelectTariffPlanNames();

            if (tariffPlanInit)
            {
                tariffPlanInit = false;
                foreach (var tariffPlan in allTariffPlanNames)
                {
                    this.SubscriberTariffPlan.Items.Add(tariffPlan);
                    TariffPlan currentPlan = new TariffPlan(tariffPlan);
                    TariffPlan.AddTariffPlan(currentPlan);
                    currentPlan = billingSystemDB.SelectTariffPlan(tariffPlan);
                }
            }
            else
            {
                foreach (var tariffPlan in allTariffPlanNames)
                {
                    this.SubscriberTariffPlan.Items.Add(tariffPlan);
                    TariffPlan currentPlan = new TariffPlan(tariffPlan);
                    if (!Tariff.Table1.Contains(currentPlan)) TariffPlan.AddTariffPlan(currentPlan);
                    currentPlan = billingSystemDB.SelectTariffPlan(tariffPlan);
                }           
            }

            //init Subscriber Table
            foreach (var subscriber in billingSystemDB.SelectAllSubscribers())
            {
                Clients.Table1.Add(subscriber);
            }
        }
        
        private void OnAddSubcriber_Click(object sender, RoutedEventArgs e)
        {
            string currentMSISDN = this.SubscriberMSISDN.Text;
            string currentName = this.SubscriberName.Text;
            string currentEGN = this.SubscriberEGN.Text;
            string currentTariffPlan = defaultTariffPlan;
            double account = 0;
            Subscriber currentSubscriber = new Subscriber(currentMSISDN, currentName, currentEGN);

            //work with Hashset
            Subscriber.AddSubscriber(currentSubscriber);
            
            if (this.SubscriberTariffPlan.SelectedItem != null)
            {
                currentTariffPlan = this.SubscriberTariffPlan.SelectedItem.ToString();
                currentSubscriber.ChangeTariffPlan(currentTariffPlan);
            }

            if (this.SubscriberAccount.Text != null)
            {
                account = double.Parse(this.SubscriberAccount.Text.ToString());
                currentSubscriber.UpdateAccount(account);
            }

            billingSystemDB.InsertSubscriber(currentSubscriber);

            SubscriberAllTextBoxInit(sender, e);
        }

        private void OnChangeSubcriber_Click(object sender, RoutedEventArgs e)
        {
            string currentMSISDN = this.SubscriberMSISDN.Text;
            string currentName = this.SubscriberName.Text;
            string currentEGN = this.SubscriberEGN.Text;
            string currentTariffPlan = this.SubscriberTariffPlan.SelectedItem.ToString();
            double currentAccount = double.Parse(this.SubscriberAccount.Text);

            //Subscriber.ChangeSubscriber(currentMSISDN, new Tuple<string, string, string, double>(currentName, currentEGN, currentTariffPlan, currentAccount));
            
            //work with Hashset
            Subscriber currentSubscriber = new Subscriber(currentMSISDN, currentName, currentEGN);
            Subscriber.AddSubscriber(currentSubscriber);
            Subscriber.ChangeSubscriber(currentSubscriber, new Tuple<string, double>(currentTariffPlan, currentAccount));

            billingSystemDB.UpdateSubscriber(currentSubscriber);

            SubscriberAllTextBoxInit(sender, e);
        }

        private void OnDeleteSubcriber_Click(object sender, RoutedEventArgs e)
        {
            //Subscriber.DeleteSubscriber(this.SubscriberMSISDN.Text);
            
            //work with Hashset
            string currentMSISDN = this.SubscriberMSISDN.Text;
            string currentName = this.SubscriberName.Text;
            string currentEGN = this.SubscriberEGN.Text;
            Subscriber currentSubscriber = new Subscriber(currentMSISDN, currentName, currentEGN);
            Subscriber.DeleteSubscriber(currentSubscriber);

            billingSystemDB.DeleteSubscriber(currentSubscriber);
            SubscriberAllTextBoxInit(sender, e);
        }

        private void OnFindSubcriber_Click(object sender, RoutedEventArgs e)
        {
            Subscriber currentSubscriber;
            bool searchByEGN = true;
            string msisdn = this.SubscriberMSISDN.Text;
            string egn = this.SubscriberEGN.Text;

            //currentSubscriber = Subscriber.FindSubscriber(this.SubscriberMSISDN.Text);
            if (!string.IsNullOrEmpty(msisdn)) currentSubscriber = billingSystemDB.SelectSubscriber(msisdn);
            else
            {
                currentSubscriber = billingSystemDB.SelectSubscriber(egn, searchByEGN);
                //msisdn = currentSubscriber.Where(p => p.Value.Item2 == egn).Select(p => p.Key).FirstOrDefault();
            }

            this.SubscriberMSISDN.Text = currentSubscriber.MSISDN;
            this.SubscriberName.Text = currentSubscriber.Name;
            this.SubscriberEGN.Text = currentSubscriber.EGN;
            this.SubscriberTariffPlan.Text = currentSubscriber.TariffPlanName;
            this.SubscriberAccount.Text = currentSubscriber.Account.ToString();
        }

        private void OnTariffPlanNameTextBoxInit(object sender, EventArgs e)
        {
            this.TariffPlanName.Text = string.Empty;
        }

        private void OnFirstCallIntervalBlockTextBoxInit(object sender, EventArgs e)
        {
            this.firstCallIntervalBlock.Text = string.Empty;
        }

        private void OnFirstCallIntervalPriceTextBoxInit(object sender, EventArgs e)
        {
            this.firstCallIntervalPrice.Text = string.Empty;
        }

        private void OnSubseqCallIntervalBlockTextBoxInit(object sender, EventArgs e)
        {
            this.subseqCallIntervalBlock.Text = string.Empty;
        }

        private void OnSubseqCallIntervalPriceTextBoxInit(object sender, EventArgs e)
        {
            this.subseqCallIntervalPrice.Text = string.Empty;
        }

        private void OnFirstSMSIntervalBlockTextBoxInit(object sender, EventArgs e)
        {
            this.firstSMSIntervalBlock.Text = string.Empty;
        }

        private void OnFirstSMSIntervalPriceTextBoxInit(object sender, EventArgs e)
        {
            this.firstSMSIntervalPrice.Text = string.Empty;
        }

        private void OnSubseqSMSIntervalBlockTextBoxInit(object sender, EventArgs e)
        {
            this.subseqSMSIntervalBlock.Text = string.Empty;
        }

        private void OnSubseqSMSIntervalPriceTextBoxInit(object sender, EventArgs e)
        {
            this.subseqSMSIntervalPrice.Text = string.Empty;
        }

        private void OnFirstGPRSIntervalBlockTextBoxInit(object sender, EventArgs e)
        {
            this.firstGPRSIntervalBlock.Text = string.Empty;
        }

        private void OnFirstGPRSIntervalPriceTextBoxInit(object sender, EventArgs e)
        {
            this.firstGPRSIntervalPrice.Text = string.Empty;
        }

        private void OnSubseqGPRSIntervalBlockTextBoxInit(object sender, EventArgs e)
        {
            this.subseqGPRSIntervalBlock.Text = string.Empty;
        }

        private void OnSubseqGPRSIntervalPriceTextBoxInit(object sender, EventArgs e)
        {
            this.subseqGPRSIntervalPrice.Text = string.Empty;
        }

        private void OnAddTariffPlan_Click(object sender, RoutedEventArgs e)
        {
            TariffPlan currentPlan = new TariffPlan(this.TariffPlanName.Text);

            TariffPlan.Interval firstCall = new TariffPlan.Interval();
            TariffPlan.Interval subseqCall = new TariffPlan.Interval();
            firstCall.chargeableBlock = long.Parse(this.firstCallIntervalBlock.Text);
            firstCall.Price = double.Parse(this.firstCallIntervalPrice.Text);
            subseqCall.chargeableBlock = long.Parse(this.subseqCallIntervalBlock.Text);
            subseqCall.Price = double.Parse(this.subseqCallIntervalPrice.Text);

            TariffPlan.Interval firstSMS = new TariffPlan.Interval();
            TariffPlan.Interval subseqSMS = new TariffPlan.Interval();
            firstSMS.chargeableBlock = long.Parse(this.firstSMSIntervalBlock.Text);
            firstSMS.Price = double.Parse(this.firstSMSIntervalPrice.Text);
            subseqSMS.chargeableBlock = long.Parse(this.subseqSMSIntervalBlock.Text);
            subseqSMS.Price = double.Parse(this.subseqSMSIntervalPrice.Text);

            TariffPlan.Interval firstGPRS = new TariffPlan.Interval();
            TariffPlan.Interval subseqGPRS = new TariffPlan.Interval();
            firstGPRS.chargeableBlock = long.Parse(this.firstGPRSIntervalBlock.Text);
            firstGPRS.Price = double.Parse(this.firstGPRSIntervalPrice.Text);
            subseqGPRS.chargeableBlock = long.Parse(this.subseqGPRSIntervalBlock.Text);
            subseqGPRS.Price = double.Parse(this.subseqGPRSIntervalPrice.Text);

            currentPlan.SetTariffPlanParam("firstCallInterval", firstCall);
            currentPlan.SetTariffPlanParam("subseqCallInterval", subseqCall);
            currentPlan.SetTariffPlanParam("firstSMSInterval", firstSMS);
            currentPlan.SetTariffPlanParam("subseqSMSInterval", subseqSMS);
            currentPlan.SetTariffPlanParam("firstGPRSInterval", firstGPRS);
            currentPlan.SetTariffPlanParam("subseqGPRSInterval", subseqGPRS);

            TariffPlan.AddTariffPlan(currentPlan);

            billingSystemDB.InsertTariffPlan(currentPlan);

            TariffPlanAllTextBoxInit(sender, e);
        }

        private void OnChangeTariffPlan_Click(object sender, RoutedEventArgs e)
        {
            TariffPlan currentPlan = new TariffPlan(this.TariffPlanName.Text);

            TariffPlan.Interval firstCall = new TariffPlan.Interval();
            TariffPlan.Interval subseqCall = new TariffPlan.Interval();
            firstCall.chargeableBlock = long.Parse(this.firstCallIntervalBlock.Text);
            firstCall.Price = double.Parse(this.firstCallIntervalPrice.Text);
            subseqCall.chargeableBlock = long.Parse(this.subseqCallIntervalBlock.Text);
            subseqCall.Price = double.Parse(this.subseqCallIntervalPrice.Text);

            TariffPlan.Interval firstSMS = new TariffPlan.Interval();
            TariffPlan.Interval subseqSMS = new TariffPlan.Interval();
            firstSMS.chargeableBlock = long.Parse(this.firstSMSIntervalBlock.Text);
            firstSMS.Price = double.Parse(this.firstSMSIntervalPrice.Text);
            subseqSMS.chargeableBlock = long.Parse(this.subseqSMSIntervalBlock.Text);
            subseqSMS.Price = double.Parse(this.subseqSMSIntervalPrice.Text);

            TariffPlan.Interval firstGPRS = new TariffPlan.Interval();
            TariffPlan.Interval subseqGPRS = new TariffPlan.Interval();
            firstGPRS.chargeableBlock = long.Parse(this.firstGPRSIntervalBlock.Text);
            firstGPRS.Price = double.Parse(this.firstGPRSIntervalPrice.Text);
            subseqGPRS.chargeableBlock = long.Parse(this.subseqGPRSIntervalBlock.Text);
            subseqGPRS.Price = double.Parse(this.subseqGPRSIntervalPrice.Text);

            currentPlan.SetTariffPlanParam("firstCallInterval", firstCall);
            currentPlan.SetTariffPlanParam("subseqCallInterval", subseqCall);
            currentPlan.SetTariffPlanParam("firstSMSInterval", firstSMS);
            currentPlan.SetTariffPlanParam("subseqSMSInterval", subseqSMS);
            currentPlan.SetTariffPlanParam("firstGPRSInterval", firstGPRS);
            currentPlan.SetTariffPlanParam("subseqGPRSInterval", subseqGPRS);

            billingSystemDB.UpdateTariffPlan(currentPlan);
            TariffPlanAllTextBoxInit(sender, e);
        }

        private void OnDeleteTariffPlan_Click(object sender, RoutedEventArgs e)
        {
            TariffPlan currentPlan = new TariffPlan(this.TariffPlanName.Text);

            TariffPlan.DeleteTariffPlan(currentPlan);
            billingSystemDB.DeleteTariffPlan(currentPlan);
            TariffPlanAllTextBoxInit(sender, e);
        }

        private void OnFindTariffPlan_Click(object sender, RoutedEventArgs e)
        {
            TariffPlan currentTariffPlan;
            
            //currentTariffPlan = TariffPlan.FindTariffPlan(this.TariffPlanName.Text);
            currentTariffPlan = billingSystemDB.SelectTariffPlan(this.TariffPlanName.Text);

            TariffPlan.Interval firstCall = currentTariffPlan.GetTariffPlanParam("firstCallInterval");
            TariffPlan.Interval subseqCall = currentTariffPlan.GetTariffPlanParam("subseqCallInterval");

            this.firstCallIntervalBlock.Text = firstCall.chargeableBlock.ToString();

            this.firstCallIntervalPrice.Text = (firstCall.Price.ToString().Length < 4) ? firstCall.Price.ToString() + '0' : firstCall.Price.ToString();
            this.subseqCallIntervalBlock.Text = subseqCall.chargeableBlock.ToString();
            this.subseqCallIntervalPrice.Text = (subseqCall.Price.ToString().Length < 4) ? subseqCall.Price.ToString() + '0' : subseqCall.Price.ToString();

            TariffPlan.Interval firstSMS = currentTariffPlan.GetTariffPlanParam("firstSMSInterval");
            TariffPlan.Interval subseqSMS = currentTariffPlan.GetTariffPlanParam("subseqSMSInterval");
            this.firstSMSIntervalBlock.Text = firstSMS.chargeableBlock.ToString();
            this.firstSMSIntervalPrice.Text = (firstSMS.Price.ToString().Length < 4) ? firstSMS.Price.ToString() + '0' : firstSMS.Price.ToString();
            this.subseqSMSIntervalBlock.Text = subseqSMS.chargeableBlock.ToString();
            this.subseqSMSIntervalPrice.Text = (subseqSMS.Price.ToString().Length < 4) ? subseqSMS.Price.ToString() + '0' : subseqSMS.Price.ToString();

            TariffPlan.Interval firstGPRS = currentTariffPlan.GetTariffPlanParam("firstGPRSInterval");
            TariffPlan.Interval subseqGPRS = currentTariffPlan.GetTariffPlanParam("subseqGPRSInterval");
            this.firstGPRSIntervalBlock.Text = firstGPRS.chargeableBlock.ToString();
            this.firstGPRSIntervalPrice.Text = (firstGPRS.Price.ToString().Length < 4) ? firstGPRS.Price.ToString() + '0' : firstGPRS.Price.ToString();
            this.subseqGPRSIntervalBlock.Text = subseqGPRS.chargeableBlock.ToString();
            this.subseqGPRSIntervalPrice.Text = (subseqGPRS.Price.ToString().Length < 4) ? subseqGPRS.Price.ToString() + '0' : subseqGPRS.Price.ToString();
        }

        private void OnShowHistoryTextBoxInit(object sender, EventArgs e)
        {
            this.ShowHistoryTextBox.Text = string.Empty;
        }

        private void OnShowHistory_Click(object sender, RoutedEventArgs e)
        {
            //this.ShowHistoryTextBox.Text = Subscriber.PrintClientsTable();
            OnFindSubcriber_Click(sender, e);
            this.TariffPlanName.Text = this.SubscriberTariffPlan.Text;
            OnFindTariffPlan_Click(sender, e);
            Tuple<List<MOC>, List<SMS>, List<GPRS>> readInfo = Billing.ReadCDR(this.SubscriberMSISDN.Text);
            List<MOC> moc = readInfo.Item1;
            List<SMS> sms = readInfo.Item2;
            List<GPRS> gprs = readInfo.Item3;
            StringBuilder sb = new StringBuilder();

            foreach (var item in moc)
            {
                int mocIndex = Billing.CalculateIndex(item.BParty,item.CurrentLocation, item.CallStartTime);
                double mocPrice = item.Rate(mocIndex,this.SubscriberTariffPlan.Text);

                sb.AppendLine(string.Format("Call Start time: {0} Call Duration: {1} s Location network: {2} BParty: {3} Price: {4} Index: {5}", item.CallStartTime, item.CallDuration, item.CurrentLocation, item.BParty, mocPrice, mocIndex));
            }
            foreach (var item in sms)
            {
                int smsIndex = Billing.CalculateIndex(item.BParty, item.CurrentLocation, item.SmsSendTime);
                double smsPrice = item.Rate(smsIndex, this.SubscriberTariffPlan.Text);

                sb.AppendLine(string.Format("SMS Send time: {0} Location network: {1} BParty: {2} Carrier: {3} Chars: {4} Price: {5} Index: {6}", item.SmsSendTime, item.CurrentLocation, item.BParty, item.Carrier, item.NumberOfSymbols, smsPrice, smsIndex));
            }
            foreach (var item in gprs)
            {
                int gprsIndex = Billing.CalculateIndex(item.Carrier, item.CurrentLocation, item.GPRSStartTime);
                double gprsPrice = item.Rate(gprsIndex, this.SubscriberTariffPlan.Text);

                sb.AppendLine(string.Format("Session Start time: {0} Location network: {1} Carrier: {2} Bytes: {3} B Price: {4} Index: {5}", item.GPRSStartTime, item.CurrentLocation, item.Carrier, item.NumberOfBytes, gprsPrice, gprsIndex));
            }
            this.ShowHistoryTextBox.Text = sb.ToString();
        }       

        private void OnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to Exit now ?", "Thank you for using our Service", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes) Environment.Exit(0);
            else return;
        }
    }
}
