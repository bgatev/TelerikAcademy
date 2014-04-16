//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

using System;

class Calc
{
    static int Min(int[] inArray)
    {
        int result = int.MaxValue;

        for (int i = 0; i < inArray.Length; i++) result = Math.Min(inArray[i], result);
        
        return result;
    }

    static int Max(int[] inArray)
    {
        int result = int.MinValue;

        for (int i = 0; i < inArray.Length; i++) result = Math.Max(inArray[i], result);

        return result;
    }

    static double Average(int[] inArray)
    {
        double result = 0;

        for (int i = 0; i < inArray.Length; i++) result += inArray[i];
        result /= inArray.Length;

        return result;
    }

    static int Sum(int[] inArray)
    {
        int result = 0;

        for (int i = 0; i < inArray.Length; i++) result += inArray[i];
        
        return result;
    }

    static int Multiply(int[] inArray)
    {
        int result = 1;

        for (int i = 0; i < inArray.Length; i++) result *= inArray[i];

        return result;
    }

    static void Main()
    {
        int num;
        
        do
        {
            Console.Write("Input number of numbers to calculate: ");
            num = int.Parse(Console.ReadLine());
        }
        while (num == 0);

        int[] numArray = new int[num];
        for (int i = 0; i < num; i++) numArray[i] = int.Parse(Console.ReadLine());

        Console.WriteLine("Minimum of all integers is: {0}", Min(numArray));
        Console.WriteLine("Maximum of all integers is: {0}", Max(numArray));
        Console.WriteLine("Average of all integers is: {0:F2}", Average(numArray));
        Console.WriteLine("Sum of all integers is: {0}", Sum(numArray));
        Console.WriteLine("Mutiply of all integers is: {0}", Multiply(numArray));

    }
}

