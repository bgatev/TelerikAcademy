//Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

using System;

class Counter
{
    static int NumCounter(int[] inArray, int num)
    {
        int counter = 0;

        for (int i = 0; i < inArray.Length; i++)
        {
            if (inArray[i] == num) counter++;    
        }
        return counter;
    }

    static void Main()
    {
        int n, numToFind, numCounter;
        
        numToFind = int.Parse(Console.ReadLine());

        n = int.Parse(Console.ReadLine());
        int[] numArray = new int[n];

        for (int i = 0; i < n; i++) numArray[i] = int.Parse(Console.ReadLine());

        numCounter = NumCounter(numArray,numToFind);
        Console.WriteLine(numCounter);
    }
}

