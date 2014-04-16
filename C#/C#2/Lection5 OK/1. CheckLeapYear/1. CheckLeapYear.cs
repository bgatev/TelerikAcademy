//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;
using System.Linq;


class CheckLeapYear
{
    static void Main()
    {
        int year;
        bool leapYear;

        year = int.Parse(Console.ReadLine());

        leapYear = DateTime.IsLeapYear(year);
        Console.WriteLine("Is the year you have entered leap ? {0}", leapYear);
    }
}

