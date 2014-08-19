namespace Computers
{
    using System;
    using System.Linq;

    public class DellPersonalComputer : IComputerFactory
    {
        public ICPU GetCPU()
        {
            return new CPU_64Bit(4, 64);
        }

        public IManifacturer GetName()
        {
            return new DellManifacturer();
        }
    }
}
