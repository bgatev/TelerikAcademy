namespace DayOfTheWeekConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DayOfTheWeek;

    public class Program
    {
        public static void Main()
        {
            DayOfTheWeekClient client = new DayOfTheWeekClient();

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(client.GetWeekDay(DateTime.Now.AddDays(i)));    
            }

            client.Close();
        }
    }
}
