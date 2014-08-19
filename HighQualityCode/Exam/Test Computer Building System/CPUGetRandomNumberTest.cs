namespace Test_Computer_Building_System
{
    using System;
    using Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CPUGetRandomNumberTest
    {
        [TestMethod]
        public void GetRandomNumberShouldReturnInteger()
        {
            CPU cpu = new CPU(2, 32);
            var randomNumber = cpu.GetRandomNumber(0, 100);

            Assert.IsInstanceOfType(randomNumber, typeof(int));
        }

        [TestMethod]
        public void GetRandomNumberBiggerThanTheMinimum()
        {
            CPU cpu = new CPU(2, 32);
            var randomNumber = cpu.GetRandomNumber(0, 100);

            Assert.IsTrue(randomNumber >= 0, "The number is not bigger than the minimum");
        }

        [TestMethod]
        public void GetRandomNumberSmallerThanTheMaximum()
        {
            CPU cpu = new CPU(2, 32);
            var randomNumber = cpu.GetRandomNumber(0, 100);

            Assert.IsTrue(randomNumber < 100, "The number is not smaller than the maximum");
        }
    }
}
