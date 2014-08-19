namespace Computers
{
    public interface IComputerFactory
    {
        ICPU GetCPU();

        IManifacturer GetName();
    }
}