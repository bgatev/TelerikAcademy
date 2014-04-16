using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class Billing
    {
        public const string FilePath = @"..\..\..\";
        public const string FileName = @"CDR.txt";

        private Billing()
        {
        }

        public static int CalculateIndex(string destParam, string locParam, DateTime timeParam)
        {           
            RatingItems rating = new RatingItemsCommon();
            RatingItems timeInv = new TimeInterval();

            var resultTime = timeInv.Index(new string[] { timeParam.ToString() });
            var resultRating = rating.Index(destParam, locParam, resultTime);

            return int.Parse(resultRating);
        }

        public static Tuple<List<MOC>,List<SMS>,List<GPRS>> ReadCDR(string subscriberMSISDN)
        {
            Tuple<List<MOC>, List<SMS>, List<GPRS>> readInfo;

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
            List<SMS> sms = new List<SMS>();
            List<GPRS> gprs = new List<GPRS>();

            foreach (var singleRecord in allMOCs)
            {
                string[] singleMOC = singleRecord.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                if (subscriberMSISDN == singleMOC[1]) moc.Add(new MOC(singleMOC[1], singleMOC[2], singleMOC[3], singleMOC[4], singleMOC[5]));
            }
            foreach (var singleRecord in allSMSs)
            {
                string[] singleSMS = singleRecord.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                if (subscriberMSISDN == singleSMS[1]) sms.Add(new SMS(singleSMS[1], singleSMS[2], singleSMS[4], singleSMS[5], singleSMS[6], singleSMS[8]));
            }
            foreach (var singleRecord in allGPRSs)
            {
                string[] singleGPRS = singleRecord.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                if (subscriberMSISDN == singleGPRS[1]) gprs.Add(new GPRS(singleGPRS[1], singleGPRS[2], singleGPRS[4], singleGPRS[6], singleGPRS[7]));
            }

            readInfo = new Tuple<List<MOC>, List<SMS>, List<GPRS>>(moc,sms,gprs);
            return readInfo;
        }

        public static void ChargeSubscriber(double amount)
        {
        }
    }
}
