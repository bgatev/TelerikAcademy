//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.
//with the help of the forum

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractDate
{
    static void ExtractDateRegex(string inString)
    {
        DateTime date;
        
        foreach (Match item in Regex.Matches(inString, @"\b\d{2}.\d{2}.\d{4}\b"))
        {
            if (DateTime.TryParseExact(item.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
        }
    }

    static void Main()
    {
        string inputText = string.Empty;

        inputText = "I was born at 14.06.1980. My sister was born at 53.07.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

        ExtractDateRegex(inputText);
    }
}

