//Write a program that reads two arrays from the console and compares them element by element.

using System;

class ArrayCompare
{
    static void Main()
    {
        int[] numArray = new int[5];
        int[] numArray2 = new int[numArray.Length];

        for (int i = 0; i < numArray.Length; i++)
        {
            Console.Write("Input {0} element of the first and second array: ",i);
            numArray[i] = int.Parse(Console.ReadLine());
            numArray2[i] = int.Parse(Console.ReadLine());
            if (numArray[i] > numArray2[i]) Console.WriteLine("{0} element of first array is bigger",i);
            else if (numArray[i] < numArray2[i]) Console.WriteLine("{0} element of first array is smaller", i);
            else Console.WriteLine("{0} element of both arrays is equal", i);
        }


    }
}

