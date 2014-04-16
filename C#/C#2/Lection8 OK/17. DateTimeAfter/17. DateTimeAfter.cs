//Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours 
//and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Linq;


class DateTimeAfter
{
    static void Main()
    {
        DateTime date;
        string dayInBG = string.Empty;

        date = DateTime.Parse(Console.ReadLine());

        date = date.AddHours(6.5);

        dayInBG = date.DayOfWeek.ToString();

        switch (dayInBG)
        {
            case "Monday": dayInBG = "Понеделник";break;
            case "Tuesday": dayInBG = "Вторник"; break;
            case "Wednesday": dayInBG = "Сряда"; break;
            case "Thursday": dayInBG = "Четвъртък"; break;
            case "Friday": dayInBG = "Петък"; break;
            case "Saturday": dayInBG = "Събота"; break;
            case "Sunday": dayInBG = "Неделя"; break;
        }

        Console.WriteLine("DateTime after is: {0} and the day is {1}", date, dayInBG);

    }
}

