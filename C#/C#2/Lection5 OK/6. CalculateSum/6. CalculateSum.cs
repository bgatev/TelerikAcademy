//You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values 
//from given string and calculates their sum. Example:
//		string = "43 68 9 23 318"  result = 461

using System;
using System.Linq;

class CalculateSum1
{
    static int CalculateSum(string inString)
    {
        string[] numString = inString.Split(' ');
        int[] num = new int[numString.Length];
        int sum = 0;

        for (int i = 0; i < num.Length; i++)
        {
            num[i] = int.Parse(numString[i]);
            sum += num[i];
        }
        
        return sum;
    }

    static void Main()
    {
        string numbers = string.Empty;
        int sum = 0;
            
        numbers = Console.ReadLine();

        sum = CalculateSum(numbers);
        Console.WriteLine(sum);
    }
}

