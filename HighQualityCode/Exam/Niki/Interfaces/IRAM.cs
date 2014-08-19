namespace Computers
{
    public interface IRAM
    {
        void SaveValue(int newValue);

        int LoadValue();
    }
}
