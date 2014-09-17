using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<int> allNumbers = new List<int>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == string.Empty) break;

            int num = int.Parse(input);
            if (num >= 0) allNumbers.Add(num);
        }

        int sum = 0;

        for (int i = 0; i < allNumbers.Count; i++)
        {
            sum += allNumbers[i];
        }

        double average = (double)sum / (double)allNumbers.Count;
        Console.WriteLine("Sum is {0} and Average is {1}", sum, average);
    }
}

