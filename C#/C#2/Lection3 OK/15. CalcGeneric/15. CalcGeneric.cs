//* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). 
//Use generic method (read in Internet about generic methods in C#).

using System;
using System.Linq;


class CalcGeneric
{
    public static T Min<T>(ref T[] inArray) where T:IComparable<T>
    {
        T result = default(T);
        for (int i = 0; i < inArray.Length; i++) if (inArray[i].CompareTo(result) < 0) result = inArray[i];
        
        return result;
    }

    public static T Max<T>(ref T[] inArray) where T:IComparable<T>
    {
        T result = default(T);

        for (int i = 0; i < inArray.Length; i++) if (inArray[i].CompareTo(result) > 0) result = inArray[i];

        return result;
    }

    public static T Average<T>(params T[] inArray)
    {
        dynamic result = 0;

        for (int i = 0; i < inArray.Length; i++) result += inArray[i];
        result /= inArray.Length;

        return result;
    }

    public static T Sum<T>(params T[] inArray)
    {
        dynamic result = 0;

        for (int i = 0; i < inArray.Length; i++) result = result + inArray[i];

        return result;
    }

    public static T Multiply<T>(params T[] inArray)
    {
        dynamic result = 1;

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

        Console.WriteLine("Minimum of all integers is: {0}", Min(ref numArray));
        Console.WriteLine("Maximum of all integers is: {0}", Max(ref numArray));
        Console.WriteLine("Average of all integers is: {0:F2}", Average(numArray));
        Console.WriteLine("Sum of all integers is: {0}", Sum(numArray));
        Console.WriteLine("Mutiply of all integers is: {0}", Multiply(numArray));
        
    }
}

