namespace Computers
{
    using System;
    using System.Linq;

    public class HPPersonalComputer : IComputerFactory
    {
        public ICPU GetCPU()
        {
            return new CPU_32Bit(2, 32);
        }

        public IManifacturer GetName()
        {
            return new HPManifacturer();
        }
    }
}
