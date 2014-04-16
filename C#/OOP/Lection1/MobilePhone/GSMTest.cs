using MobilePhone;
using System;
using System.Collections.Generic;
using System.Linq;

class GSMTest
{
    static void Main()
    {
        BatterySpecs secondPhoneBattery = new BatterySpecs("SE", BatteryType.NiCd, 200, 30);
        DisplaySpecs secondPhoneDisplay = new DisplaySpecs(5.2, 256000);
        BatterySpecs thirdPhoneBattery = new BatterySpecs("Asus", BatteryType.LiIon, 400,80);

        List<GSM> allPhones = new List<GSM>();

        GSM myPhone = new GSM("Samsung", "Galaxy");
        allPhones.Add(myPhone);

        GSM secondPhone = new GSM("Nokia", "Lumia", "Ivan", 234, secondPhoneBattery, secondPhoneDisplay);
        allPhones.Add(secondPhone);

        GSM thirdPhone = new GSM("Google", "Nexus", "Petko", 456, thirdPhoneBattery);
        allPhones.Add(thirdPhone);

        foreach (var phone in allPhones)
        {
            GSM.DisplayGSMInfo(phone);      
        }

        GSM.IPhone4S.Price = 800;
        Console.WriteLine(GSM.IPhone4S.ToString());

        GSMCallHistoryTest.Test();
       
    }
}

