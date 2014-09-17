using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> allNumbers = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            allNumbers.Push(currentNumber);
        }

        foreach (var item in allNumbers)
        {
            Console.WriteLine(item);
        }
    }
}

