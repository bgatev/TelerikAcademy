using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static long CalculateBinom(int n, int k)
    {
        long nominator = 1, denominator = 1;

        for (int i = n; i > (n - k); i--) nominator *= i;
        for (int i = k; i > 0; i--) denominator *= i;

        return (nominator / denominator);
    }

    public static long FindSequenceSum(int n, int k, int[] numbers)
    {
        long sum = 0;

        for (int i = 0; i < numbers.Length; i++) sum += numbers[i];

        long sequenceSum = CalculateBinom(n - 1, k) * sum;

        return sequenceSum;
    }

    static void Main()
    {
        int numberOfSequences = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfSequences; i++)
        {
            string inputLine = Console.ReadLine();
            string[] nk = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(nk[0]);
            int k = int.Parse(nk[1]);

            inputLine = Console.ReadLine();
            string[] allNumbersString = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] allNumbers = new int[allNumbersString.Length];

            for (int j = 0; j < allNumbers.Length; j++) allNumbers[j] = int.Parse(allNumbersString[j]);

            Console.WriteLine(FindSequenceSum(n, k, allNumbers));
        }
    }
}

