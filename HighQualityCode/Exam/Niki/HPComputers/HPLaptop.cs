namespace Computers
{
    using System;
    using System.Linq;

    public class HPLaptop : IComputerFactory
    {
        public ICPU GetCPU()
        {
            return new CPU_64Bit(2, 64);
        }

        public IManifacturer GetName()
        {
            return new HPManifacturer();
        }
    }
}
