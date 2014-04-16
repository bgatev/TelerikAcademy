using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string charset;

        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "billingsystem";
            uid = "gatakka";
            password = "qwerty";
            charset = "utf8";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "CharSet=" + charset + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void InsertSubscriber(Subscriber subscriberToInsert)
        {
            int tariffPlanID = 0;
            string querySubscriberTable = string.Format("INSERT INTO subscriber (subscriber_msisdn, subscriber_name, subscriber_egn, subscriber_tariffplan, subscriber_account) VALUES('{0}','{1}','{2}','{3}','{4}')",
                subscriberToInsert.MSISDN, subscriberToInsert.Name, subscriberToInsert.EGN, subscriberToInsert.TariffPlanName, subscriberToInsert.Account);
            string queryTariffPlanTable = string.Format("SELECT tariffplan_id FROM tariffplan WHERE tariffplan_name='{0}'", subscriberToInsert.TariffPlanName);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(querySubscriberTable, connection);
                cmd.ExecuteNonQuery();
                
                object cmdID = MySqlHelper.ExecuteScalar(connection,"SELECT LAST_INSERT_ID();");
                int subscriberId = (int)(ulong)cmdID;

                cmd = new MySqlCommand(queryTariffPlanTable, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read()) tariffPlanID = (int)(dataReader["tariffplan_id"]);
                dataReader.Close();

                string querySubscriber_tariffplanTable = string.Format("INSERT INTO subscriber_tariffplan (subscriber_id, tariffplan_id) VALUES('{0}','{1}')", subscriberId, tariffPlanID);
                cmd = new MySqlCommand(querySubscriber_tariffplanTable, connection);
                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void InsertTariffPlan(TariffPlan planToInsert)
        {
            TariffPlan.Interval firstCall = planToInsert.GetTariffPlanParam("firstCallInterval");
            TariffPlan.Interval subseqCall = planToInsert.GetTariffPlanParam("subseqCallInterval");

            long firstCallIntervalBlock = firstCall.chargeableBlock;
            double firstCallIntervalPrice = firstCall.Price;
            long subseqCallIntervalBlock = subseqCall.chargeableBlock;
            double subseqCallIntervalPrice = subseqCall.Price;

            TariffPlan.Interval firstSMS = planToInsert.GetTariffPlanParam("firstSMSInterval");
            TariffPlan.Interval subseqSMS = planToInsert.GetTariffPlanParam("subseqSMSInterval");
            long firstSMSIntervalBlock = firstSMS.chargeableBlock;
            double firstSMSIntervalPrice = firstSMS.Price;
            long subseqSMSIntervalBlock = subseqSMS.chargeableBlock;
            double subseqSMSIntervalPrice = subseqSMS.Price;

            TariffPlan.Interval firstGPRS = planToInsert.GetTariffPlanParam("firstGPRSInterval");
            TariffPlan.Interval subseqGPRS = planToInsert.GetTariffPlanParam("subseqGPRSInterval");
            long firstGPRSIntervalBlock = firstGPRS.chargeableBlock;
            double firstGPRSIntervalPrice = firstGPRS.Price;
            long subseqGPRSIntervalBlock = subseqGPRS.chargeableBlock;
            double subseqGPRSIntervalPrice = subseqGPRS.Price;

            string query = string.Format("INSERT INTO tariffplan (tariffplan_name, callfirstblock, callfirstblockprice, callsubseqblock, callsubseqblockprice, smsfirstblock, smsfirstblockprice, smssubseqblock, smssubseqblockprice, gprsfirstblock, gprsfirstblockprice, gprssubseqblock, gprssubseqblockprice) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                planToInsert.Name, firstCallIntervalBlock, firstCallIntervalPrice, subseqCallIntervalBlock, subseqCallIntervalPrice,
                firstSMSIntervalBlock, firstSMSIntervalPrice, subseqSMSIntervalBlock, subseqSMSIntervalPrice,
                firstGPRSIntervalBlock, firstGPRSIntervalPrice, subseqGPRSIntervalBlock, subseqGPRSIntervalPrice);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Update statement
        public void UpdateSubscriber(Subscriber subscriberToUpdate)
        {
            int tariffPlanID = 0, subscriberID = 0;
            string querySubscriberTable = string.Format("UPDATE subscriber SET subscriber_name='{0}', subscriber_egn='{1}', subscriber_tariffplan='{2}', subscriber_account='{3}' WHERE subscriber_msisdn='{4}'",
                subscriberToUpdate.Name, subscriberToUpdate.EGN, subscriberToUpdate.TariffPlanName, subscriberToUpdate.Account, subscriberToUpdate.MSISDN);
            
            string queryTariffPlanTable = string.Format("SELECT tariffplan_id FROM tariffplan WHERE tariffplan_name='{0}'", subscriberToUpdate.TariffPlanName);
            string querySubscriberTableID = string.Format("SELECT subscriber_id FROM subscriber WHERE subscriber_msisdn='{0}'", subscriberToUpdate.MSISDN);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = querySubscriberTable;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(queryTariffPlanTable, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read()) tariffPlanID = (int)(dataReader["tariffplan_id"]);
                dataReader.Close();

                cmd = new MySqlCommand(querySubscriberTableID, connection);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read()) subscriberID = (int)(dataReader["subscriber_id"]);
                dataReader.Close();

                string querySubscriber_tariffplanTable = string.Format("UPDATE subscriber_tariffplan SET tariffplan_id='{0}' WHERE subscriber_id='{1}'",tariffPlanID,subscriberID);
                cmd.CommandText = querySubscriber_tariffplanTable;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void UpdateTariffPlan(TariffPlan planToUpdate)
        {
            TariffPlan.Interval firstCall = planToUpdate.GetTariffPlanParam("firstCallInterval");
            TariffPlan.Interval subseqCall = planToUpdate.GetTariffPlanParam("subseqCallInterval");

            long firstCallIntervalBlock = firstCall.chargeableBlock;
            double firstCallIntervalPrice = firstCall.Price;
            long subseqCallIntervalBlock = subseqCall.chargeableBlock;
            double subseqCallIntervalPrice = subseqCall.Price;

            TariffPlan.Interval firstSMS = planToUpdate.GetTariffPlanParam("firstSMSInterval");
            TariffPlan.Interval subseqSMS = planToUpdate.GetTariffPlanParam("subseqSMSInterval");
            long firstSMSIntervalBlock = firstSMS.chargeableBlock;
            double firstSMSIntervalPrice = firstSMS.Price;
            long subseqSMSIntervalBlock = subseqSMS.chargeableBlock;
            double subseqSMSIntervalPrice = subseqSMS.Price;

            TariffPlan.Interval firstGPRS = planToUpdate.GetTariffPlanParam("firstGPRSInterval");
            TariffPlan.Interval subseqGPRS = planToUpdate.GetTariffPlanParam("subseqGPRSInterval");
            long firstGPRSIntervalBlock = firstGPRS.chargeableBlock;
            double firstGPRSIntervalPrice = firstGPRS.Price;
            long subseqGPRSIntervalBlock = subseqGPRS.chargeableBlock;
            double subseqGPRSIntervalPrice = subseqGPRS.Price;

            string query = string.Format("UPDATE tariffplan SET callfirstblock='{0}', callfirstblockprice='{1}', callsubseqblock='{2}', callsubseqblockprice='{3}', smsfirstblock='{4}', smsfirstblockprice='{5}', smssubseqblock='{6}', smssubseqblockprice='{7}', gprsfirstblock='{8}', gprsfirstblockprice='{9}', gprssubseqblock='{10}', gprssubseqblockprice='{11}' WHERE tariffplan_name='{12}'", 
                firstCallIntervalBlock, firstCallIntervalPrice, subseqCallIntervalBlock, subseqCallIntervalPrice,
                firstSMSIntervalBlock, firstSMSIntervalPrice, subseqSMSIntervalBlock, subseqSMSIntervalPrice,
                firstGPRSIntervalBlock, firstGPRSIntervalPrice, subseqGPRSIntervalBlock, subseqGPRSIntervalPrice, planToUpdate.Name);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Delete statement
        public void DeleteSubscriber(Subscriber subscriberToDelete)
        {
            string query = string.Format("DELETE FROM subscriber WHERE subscriber_msisdn='{0}'", subscriberToDelete.MSISDN);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void DeleteTariffPlan(TariffPlan planToDelete)
        {
            string query = string.Format("DELETE FROM tariffplan WHERE tariffplan_name='{0}'", planToDelete.Name);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public Subscriber SelectSubscriber(string msisdnOrEgn, bool byEGN = false)
        {
            string query = string.Empty;

            if (byEGN) query = string.Format("SELECT subscriber_msisdn, subscriber_name, subscriber_egn, subscriber_tariffplan, subscriber_account FROM subscriber WHERE subscriber_egn='{0}'", msisdnOrEgn);
            else query = string.Format("SELECT subscriber_msisdn, subscriber_name, subscriber_egn, subscriber_tariffplan, subscriber_account FROM subscriber WHERE subscriber_msisdn='{0}'", msisdnOrEgn);

            Subscriber subscriber = new Subscriber();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                
                while (dataReader.Read())
                {
                    string msisdn = dataReader["subscriber_msisdn"] as string;
                    string name = dataReader["subscriber_name"] as string;
                    string egn = dataReader["subscriber_egn"] as string;
                    subscriber = new Subscriber(msisdn, name, egn);
                    subscriber.ChangeTariffPlan(dataReader["subscriber_tariffplan"] as string);
                    subscriber.UpdateAccount((double)dataReader["subscriber_account"]);
                }

                dataReader.Close();
                this.CloseConnection();
            }

            return subscriber;
        }

        public TariffPlan SelectTariffPlan(string planName)
        {
            string query = string.Format("SELECT callfirstblock, callfirstblockprice, callsubseqblock, callsubseqblockprice, smsfirstblock, smsfirstblockprice, smssubseqblock, smssubseqblockprice, gprsfirstblock, gprsfirstblockprice, gprssubseqblock, gprssubseqblockprice FROM tariffplan WHERE tariffplan_name='{0}'", planName);

            TariffPlan tariffPlan = new TariffPlan(planName);

            TariffPlan.Interval firstCall = new TariffPlan.Interval();
            TariffPlan.Interval subseqCall = new TariffPlan.Interval();
            TariffPlan.Interval firstSMS = new TariffPlan.Interval();
            TariffPlan.Interval subseqSMS = new TariffPlan.Interval();
            TariffPlan.Interval firstGPRS = new TariffPlan.Interval();
            TariffPlan.Interval subseqGPRS = new TariffPlan.Interval();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    firstCall.chargeableBlock = (long)dataReader["callfirstblock"];
                    firstCall.Price = (double)dataReader["callfirstblockprice"];
                    subseqCall.chargeableBlock = (long)dataReader["callsubseqblock"];
                    subseqCall.Price = (double)dataReader["callsubseqblockprice"];
                    firstSMS.chargeableBlock = (long)dataReader["smsfirstblock"];
                    firstSMS.Price = (double)dataReader["smsfirstblockprice"];
                    subseqSMS.chargeableBlock = (long)dataReader["smssubseqblock"];
                    subseqSMS.Price = (double)dataReader["smssubseqblockprice"];
                    firstGPRS.chargeableBlock = (long)dataReader["gprsfirstblock"];
                    firstGPRS.Price = (double)dataReader["gprsfirstblockprice"];
                    subseqGPRS.chargeableBlock = (long)dataReader["gprssubseqblock"];
                    subseqGPRS.Price = (double)dataReader["gprssubseqblockprice"];
                }

                dataReader.Close();
                this.CloseConnection();
            }

            tariffPlan.SetTariffPlanParam("firstCallInterval", firstCall);
            tariffPlan.SetTariffPlanParam("subseqCallInterval", subseqCall);
            tariffPlan.SetTariffPlanParam("firstSMSInterval", firstSMS);
            tariffPlan.SetTariffPlanParam("subseqSMSInterval", subseqSMS);
            tariffPlan.SetTariffPlanParam("firstGPRSInterval", firstGPRS);
            tariffPlan.SetTariffPlanParam("subseqGPRSInterval", subseqGPRS);

            return tariffPlan;
        }

        public HashSet<Subscriber> SelectAllSubscribers()
        {
            HashSet<Subscriber> allSubscribers = new HashSet<Subscriber>();

            string query = string.Format("SELECT subscriber_msisdn, subscriber_name, subscriber_egn, subscriber_tariffplan, subscriber_account FROM subscriber");

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string msisdn = dataReader["subscriber_msisdn"] as string;
                    string name = dataReader["subscriber_name"] as string;
                    string egn = dataReader["subscriber_egn"] as string;
                    string tariffPlan = (dataReader["subscriber_tariffplan"] as string);
                    double account = ((double)dataReader["subscriber_account"]);
                    Subscriber subscriber = new Subscriber(msisdn, name, egn, tariffPlan, account);
                    
                    allSubscribers.Add(subscriber);
                }

                dataReader.Close();
                this.CloseConnection();
            }

            return allSubscribers;
        }

        public List<string> SelectTariffPlanNames()
        {
            string query = string.Format("SELECT tariffplan_name FROM tariffplan");

            List<string> tariffPlanNames = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    tariffPlanNames.Add(dataReader["tariffplan_name"] as string);
                }

                dataReader.Close();
                this.CloseConnection();
            }

            return tariffPlanNames;
        }

        //Count statement
        public int CountSubscribers()
        {
            string query = "SELECT Count(*) FROM subscriber";
            int Count = -1;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                this.CloseConnection();
            }

            return Count;
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;

                //Save file to C:\ with the current date as a filename
                string path;
                path = @"..\..\MySqlBackup" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + ".sql";
                StreamWriter file = new StreamWriter(path, false, Encoding.GetEncoding("utf-8"));


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = @"C:\BGatev\Personal\PHP\XAMPP\mysql\bin\mysqldump.exe";
                psi.Arguments = string.Format(@"{0} -h{1} -u{2} -p{3}", database, server, uid, password);

                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (SystemException ex)
            {
                Console.WriteLine("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = @"..\..\MySqlBackup.sql";
                StreamReader file = new StreamReader(path, Encoding.GetEncoding("utf-8"));
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = @"C:\BGatev\Personal\PHP\XAMPP\mysql\bin\mysql.exe";
                psi.Arguments = string.Format(@"{0} -h{1} -u{2} -p{3}", database, server, uid, password);
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (SystemException ex)
            {
                Console.WriteLine("Error , unable to Restore!");
            }
        }
    }
}
