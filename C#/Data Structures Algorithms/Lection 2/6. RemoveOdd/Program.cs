using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        
        Dictionary<int, int> occurrences = new Dictionary<int, int>();

        foreach (int number in numbers)
        {
            if (occurrences.ContainsKey(number)) occurrences[number] += 1;
            else occurrences.Add(number, 1);          
        }

        foreach (var number in occurrences)
        {
            if (number.Value % 2 != 0) numbers.RemoveAll(item => item == number.Key);
        }

        Console.WriteLine("\nOnly even occurrences: ");

        for (int i = 0; i < numbers.Count; i++) Console.Write(numbers[i] + " ");
    }
}