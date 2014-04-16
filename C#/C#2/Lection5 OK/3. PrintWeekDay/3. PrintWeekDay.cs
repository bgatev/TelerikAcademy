//Write a program that prints to the console which day of the week is today. Use System.DateTime.

using System;
using System.Linq;

class PrintWeekDay
{
    static void Main()
    {
        string dayOfWeekToday = string.Empty;
        
        dayOfWeekToday = DateTime.Now.DayOfWeek.ToString();
        Console.WriteLine("Today is: {0}", dayOfWeekToday);
    }
}

