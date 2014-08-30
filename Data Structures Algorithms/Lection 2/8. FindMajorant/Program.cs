using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
        int n = numbers.Count();

        Dictionary<int, int> occurrences = new Dictionary<int, int>();

        foreach (int number in numbers)
        {
            if (occurrences.ContainsKey(number)) occurrences[number] += 1;
            else occurrences.Add(number, 1);
        }

        foreach (var number in occurrences)
        {
            if (number.Value / (n / 2 + 1) > 0) Console.WriteLine("Majorant: " + number.Key);
        }
    }
}