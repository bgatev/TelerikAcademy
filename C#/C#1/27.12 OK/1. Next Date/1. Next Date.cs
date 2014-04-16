using System;

class NextDate
{
    static void Main()
    {
        int day, month, year;
        string fullDate;

        day = int.Parse(Console.ReadLine());
        month = int.Parse(Console.ReadLine());
        year = int.Parse(Console.ReadLine());

        fullDate = Convert.ToString(year) + "-" + Convert.ToString(month) + "-" + Convert.ToString(day);
        DateTime nextDate1 = Convert.ToDateTime(fullDate).AddDays(1);
       
        Console.WriteLine("{0:d.M.yyyy}",nextDate1);
    }
}

