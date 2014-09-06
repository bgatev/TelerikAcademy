namespace WolfRaider.ConsoleClient.Contracts
{
    using System.Text;

    public interface IPrinter
    {
        void Print(string text);

        void Print(StringBuilder stringBuilder);

        void PrintLine(string message);

        void PrintLine(StringBuilder stringBuilder);
    }
}