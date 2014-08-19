namespace Computers
{
    using System;
    using System.Linq;

    public class LenovoServer : IComputerFactory
    {
        public ICPU GetCPU()
        {
            return new CPU_128Bit(2, 128);
        }

        public IManifacturer GetName()
        {
            return new LenovoManifacturer();
        }
    }
}
