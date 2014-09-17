namespace LibraryConsoleClient
{
    using System;

    public class Program
    {
        public static void Main()
        {
            LibraryClient client = new LibraryClient();

            Console.WriteLine(client.ContainsIn("minimumindians","in"));

            client.Close();
        }
    }
}
