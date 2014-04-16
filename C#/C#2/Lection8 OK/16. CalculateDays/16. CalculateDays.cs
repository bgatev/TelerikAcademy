//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
//Enter the first date: 27.02.2006
//Enter the second date: 3.03.2006
//Distance: 4 days

using System;
using System.Linq;

class CalculateDays1
{
    static int CalculateDays(DateTime inDateStart, DateTime inDateEnd)
    {
        int DaysCounter = 0;
       
        do
        {
            DaysCounter++;
            if (inDateEnd > inDateStart) inDateEnd = inDateEnd.AddDays(-1);
            else inDateEnd = inDateEnd.AddDays(1);
        }
        while (inDateEnd.Date != inDateStart.Date);

        return DaysCounter;
    }

    static void Main()
    {
        int numberOfDays = 0;
        DateTime dateStart, dateEnd;
       
        dateStart = DateTime.Parse(Console.ReadLine());
        dateEnd = DateTime.Parse(Console.ReadLine());

        numberOfDays = CalculateDays(dateStart, dateEnd);

        Console.WriteLine("Distance: {0} days", numberOfDays);
    }
}

