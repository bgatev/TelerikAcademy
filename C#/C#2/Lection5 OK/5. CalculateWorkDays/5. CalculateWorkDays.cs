//Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that workdays are all 
//days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;
using System.Linq;

public static class DateTimeExtensions
{
    public static bool IsWorkingDay(this DateTime inDate)
    {
        return ((inDate.DayOfWeek != DayOfWeek.Saturday) && (inDate.DayOfWeek != DayOfWeek.Sunday));
    }
}

class CalculateWorkDays1
{
    static int CalculateWorkingDays(DateTime inDate)
    {
        int workDaysCounter = 0;
        DateTime today = DateTime.Now;

        do
        {
            if (DateTimeExtensions.IsWorkingDay(today)) workDaysCounter++;
            if (today > inDate) today = today.AddDays(-1);
            else today = today.AddDays(1);
        }
        while (today.Date != inDate.Date);

        return workDaysCounter;
    }
    
    static void Main()
    {
        int workDays = 0;
        DateTime date;
        DateTime[] holidays = new DateTime[]
        {
            new DateTime(2013,1,1),
            new DateTime(2013,2,1),
            new DateTime(2013,2,2),
            new DateTime(2013,3,3),
            new DateTime(2013,4,1),
            new DateTime(2013,5,1),
            new DateTime(2013,5,6),
            new DateTime(2013,5,24),
            new DateTime(2013,8,15),
            new DateTime(2013,9,6),
            new DateTime(2013,9,9),
            new DateTime(2013,11,1),
            new DateTime(2013,12,6),
            new DateTime(2013,12,8),
            new DateTime(2013,12,24),
            new DateTime(2013,12,25),
            new DateTime(2013,12,31)
        };

        date = DateTime.Parse(Console.ReadLine());

        workDays = CalculateWorkingDays(date);

        for (int i = 0; i < holidays.Length; i++) if (DateTimeExtensions.IsWorkingDay(holidays[i])) workDays--;
        
        Console.WriteLine("There are {0} working days between today and {1}", workDays, date.ToShortDateString());
    }
}

