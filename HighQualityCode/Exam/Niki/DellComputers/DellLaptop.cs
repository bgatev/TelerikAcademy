namespace Computers
{
    using System;
    using System.Linq;

    public class DellLaptop : IComputerFactory
    {
        public ICPU GetCPU()
        {
            return new CPU_32Bit(4, 32);
        }

        public IManifacturer GetName()
        {
            return new DellManifacturer();
        }
    }
}
