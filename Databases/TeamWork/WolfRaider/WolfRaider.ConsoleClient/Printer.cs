namespace WolfRaider.ConsoleClient
{
    using System;
    using System.Text;

    using WolfRaider.ConsoleClient.Contracts;

    public class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.Write(text);
        }

        public void Print(StringBuilder stringBuilder)
        {
            Console.Write(stringBuilder.ToString());
        }

        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintLine(StringBuilder stringBuilder)
        {
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
