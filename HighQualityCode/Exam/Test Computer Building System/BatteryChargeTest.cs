namespace Test_Computer_Building_System
{
    using System;
    using Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BatteryChargeTest
    {
        [TestMethod]
        public void CanCreateBatteryWithDefaultPercentage()
        {
            Battery battery = new Battery();
            
            Assert.AreEqual(50, battery.Percentage);
        }

        [TestMethod]
        public void ChargeBatteryWithPercentageBetween0And100ShouldAddPowerToTheBattery()
        {
            Battery battery = new Battery();
            battery.Charge(23);

            Assert.AreEqual(73, battery.Percentage);
        }

        [TestMethod]
        public void ChargeBatteryWithPercentageAbove100ShouldFullChargeTheBattery()
        {
            Battery battery = new Battery();
            battery.Charge(51);

            Assert.AreEqual(100, battery.Percentage);
        }

        [TestMethod]
        public void ChargeBatteryWithNegativePercentageShouldDischargeTheBattery()
        {
            Battery battery = new Battery();
            battery.Charge(-11);

            Assert.AreEqual(39, battery.Percentage);
        }

        [TestMethod]
        public void ChargeBatteryWithNegativePercentageAboveTheCapacityShouldFullDischargeTheBattery()
        {
            Battery battery = new Battery();
            battery.Charge(-61);

            Assert.AreEqual(0, battery.Percentage);
        }
    }
}
