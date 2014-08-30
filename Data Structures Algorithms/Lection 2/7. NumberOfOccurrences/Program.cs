using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        SortedDictionary<int, int> occurrences = new SortedDictionary<int, int>();

        foreach (int number in numbers)
        {
            if (occurrences.ContainsKey(number)) occurrences[number] += 1;
            else occurrences.Add(number, 1);
        }

        foreach (var number in occurrences)
        {
            Console.WriteLine(number.Key + " -> " + number.Value + " times");
        }
    }
}