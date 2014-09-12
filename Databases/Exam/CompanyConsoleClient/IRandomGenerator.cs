namespace CompanyConsoleClient
{
    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);
        string GetRandomStringNumber(int length);
        string GetRandomStringNumberWithRandomLength(int min, int max);
        string GetRandomString(int length);
        string GetRandomStringWithRandomLength(int min, int max);
    }
}
