namespace Computers
{
    using System;
    using System.Linq;

    public class DellServer : IComputerFactory
    {
        public ICPU GetCPU()
        {
            return new CPU_64Bit(8, 64);
        }

        public IManifacturer GetName()
        {
            return new DellManifacturer();
        }
    }
}
