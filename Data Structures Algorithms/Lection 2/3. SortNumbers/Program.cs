using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            allNumbers.Add(num);
        }

        allNumbers.Sort();

        foreach (var item in allNumbers)
        {
            Console.WriteLine(item);   
        }
    }
}

