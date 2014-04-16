using System;
using System.Linq;

namespace MobilePhone
{
    public class GSMCallHistoryTest
    {
        public static void Test()
        {
            const double callPricePerMin = 0.37;

            DateTime dateFirstCall = new DateTime(2008, 6, 19, 7, 47, 0);
            DateTime dateSecondCall = new DateTime(2010, 2, 21, 17, 4, 10);
            DateTime dateThirdCall = new DateTime(2012, 7, 31, 6, 31, 45);
            DateTime dateFourthCall = new DateTime(2013, 3, 9, 20, 55, 23);

            GSM myPhone1 = new GSM("New Samsung", "Galaxy S");

            myPhone1.AddCall(45, dateFirstCall, "0888123456");
            myPhone1.AddCall(15, dateSecondCall, "0898123456");
            myPhone1.AddCall(556, dateThirdCall, "0878123456");
            myPhone1.AddCall(34, dateFourthCall, "0888987651");
            myPhone1.AddCall(456, DateTime.Now, "0883456789");

            myPhone1.DisplayCallHistory();
            double myPhoneCallPrice = myPhone1.CalculateCallPrice(callPricePerMin);
            Console.WriteLine("Your Bill is: {0:C2}",myPhoneCallPrice);

            Call longestCall = myPhone1.RemoveLongestCallInHistory();
            myPhone1.DeleteCall(longestCall.Duration, longestCall.CallDateTime);
            myPhone1.DisplayCallHistory();
            myPhoneCallPrice = myPhone1.CalculateCallPrice(callPricePerMin);
            Console.WriteLine("Your Second Bill is: {0:C2}", myPhoneCallPrice);

            myPhone1.ClearCallHistory();
            myPhone1.DisplayCallHistory();

        }
    }
}
