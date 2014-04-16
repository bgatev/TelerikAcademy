using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    class Program
    {
        static void Main()
        {
            bool createIndexTable = true, createIndexTableGPRS = true, printGPRS = true;
            const string FilePath = @"..\..\..\";
            const string FileName = @"CDR.txt";

            RatingItems dest = new Destination();
            var resultDest = dest.Index(new string[] {"+35987"});
            Console.WriteLine(resultDest);

            RatingItems loc = new Location();
            var resultLoc = loc.Index(new string[] { "BG" });
            Console.WriteLine(resultLoc);

            RatingItems timeInv = new TimeInterval();
            var resultTime = timeInv.Index(new string[] { "8:00 – 18:00" });
            Console.WriteLine(resultTime);

            RatingItems carrier = new CarrierType();
            var resultCarrier = carrier.Index(new string[] { "2" });
            Console.WriteLine(resultCarrier);

            RatingItems rating = new RatingItemsCommon(createIndexTable);
            var resultRating = rating.Index(resultDest, resultLoc, resultTime);
            Console.WriteLine(resultRating);

            RatingItems ratingGPRS = new RatingItemsCommon(false, createIndexTableGPRS);
            var resultRatingGPRS = ratingGPRS.Index(resultCarrier, resultLoc, resultTime);
            Console.WriteLine(resultRatingGPRS);

            StringBuilder sb = new StringBuilder();
            sb.Append(resultDest);sb.AppendLine();
            sb.Append(resultLoc);sb.Append(resultTime); sb.AppendLine();
            sb.Append(resultLoc);sb.AppendLine();
            sb.Append(resultRating);

            //RWFiles.WriteFile(@"..\..\..\test.txt", sb.ToString());
            //string resultRW = RWFiles.ReadFile(@"..\..\..\test.txt");
            string resultRW = RWFiles.ReadFile(FilePath + FileName);

            string[] resultByLine = resultRW.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(resultByLine);
            StringBuilder sbMOC = new StringBuilder();
            StringBuilder sbSMS = new StringBuilder();
            StringBuilder sbGPRS = new StringBuilder();

            for (int i = 0; i < resultByLine.Count(); i++)
            {              
                switch (resultByLine[i][0])
                {
                    case 'M': sbMOC.AppendLine(resultByLine[i]); 
                        break;
                    case 'S': sbSMS.AppendLine(resultByLine[i]);
                        break;
                    case 'G': sbGPRS.AppendLine(resultByLine[i]);
                        break;
                    default: break;
                }        
            }

            string[] allMOCs = sbMOC.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] allSMSs = sbSMS.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] allGPRSs = sbGPRS.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<MOC> moc = new List<MOC>();
            foreach (var singleRecord in allMOCs)
            {
                string[] singleMOC = singleRecord.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                moc.Add(new MOC(singleMOC[1],singleMOC[2],singleMOC[3],singleMOC[4],singleMOC[5]));    
            }

            moc[0].BParty = DestZone.Others.ToString();
            moc[1].CallDuration = 145;
            moc[2].CurrentLocation = LocZone.NonEU.ToString();
            moc[0].MSISDN = "356123456987";
            foreach (var item in moc)
            {
                Console.WriteLine("{0} - {1:0.00}", item, item.Rate(int.Parse(resultRating)));    
            }

            List<SMS> sms = new List<SMS>();
            foreach (var singleRecord in allSMSs)
            {
                string[] singleSMS = singleRecord.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                sms.Add(new SMS(singleSMS[1], singleSMS[2], singleSMS[4], singleSMS[5], singleSMS[6], singleSMS[8]));
            }
            sms[0].Carrier = GPRSZone.LTE.ToString();
            sms[1].NumberOfSymbols = 200;
            foreach (var item in sms)
            {
                Console.WriteLine(item);
            }

            List<GPRS> gprs = new List<GPRS>();
            foreach (var singleRecord in allGPRSs)
            {
                string[] singleGPRS = singleRecord.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                gprs.Add(new GPRS(singleGPRS[1], singleGPRS[2], singleGPRS[4], singleGPRS[6], singleGPRS[7]));
            }
            gprs[0].NumberOfBytes = 10000000;
            foreach (var item in gprs)
            {
                Console.WriteLine(item);
            }

            RatingItems.PrintTable();
            RatingItems.PrintTable(printGPRS);
            
            //RWFiles.WriteFile(@"..\..\..\table.txt", RatingItems.PrintTable());
            //RWFiles.WriteFile(@"..\..\..\tablegprs.txt", RatingItems.PrintTable(printGPRS));
            
            TariffPlan defaultPlan = new TariffPlan("MyDefaultPlan");
            
            List<TariffPlan.Interval> firstList = new List<TariffPlan.Interval>();
            List<TariffPlan.Interval> subseqList = new List<TariffPlan.Interval>();
            
            TariffPlan.Interval firstCall = new TariffPlan.Interval();
            TariffPlan.Interval subseqCall = new TariffPlan.Interval();
            firstCall.chargeableBlock = 60;
            firstCall.Price = 0.25;
            subseqCall.chargeableBlock = 60;
            subseqCall.Price = 0.20;

            TariffPlan.Interval firstSMS = new TariffPlan.Interval();
            TariffPlan.Interval subseqSMS = new TariffPlan.Interval();
            firstSMS.chargeableBlock = 1;
            firstSMS.Price = 0.21;
            subseqSMS.chargeableBlock = 1;
            subseqSMS.Price = 0.15;

            TariffPlan.Interval firstGPRS = new TariffPlan.Interval();
            TariffPlan.Interval subseqGPRS = new TariffPlan.Interval();
            firstGPRS.chargeableBlock = 100000;
            firstGPRS.Price = 1.50;
            subseqGPRS.chargeableBlock = 1000;
            subseqGPRS.Price = 0.01;

            firstList.Add(firstCall);
            firstList.Add(firstSMS);
            firstList.Add(firstGPRS);

            subseqList.Add(subseqCall);
            subseqList.Add(subseqSMS);
            subseqList.Add(subseqGPRS);

            TariffPlan planMtel = new TariffPlan("Cool",firstList,subseqList);
            //TariffPlan.DeleteTariffPlan(defaultPlan.Name);
            TariffPlan.ChangeTariffPlan(defaultPlan.Name, new Tuple<List<TariffPlan.Interval>, List<TariffPlan.Interval>>(firstList,subseqList));

            Console.WriteLine(planMtel);
            
            planMtel.SetTariffPlanParam("firstCallInterval", 20, 0.40);
            string[] firstCallIntervalMtel = planMtel.GetTariffPlanParam("firstCallInterval");

            Subscriber ivan = new Subscriber("359888123456", "Ivan Petrov", "1234567890");
            Console.WriteLine(ivan);

            ivan.ChangeTariffPlan(planMtel.Name.ToString());
            ivan.UpdateAccount(100.09);

            Subscriber.PrintClientsTable();

            Console.WriteLine(ivan);
            ivan.PrintClassData();
        }
    }
}
