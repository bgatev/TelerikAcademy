//Write a method that checks if the element at given position in given array of integers is bigger than its two neighbours (when such exist).

using System;

class BiggerElement
{
    static bool CheckBiggerAtIndex(int[] inArray, int index)
    {
        if (index == 0)
        {
            if (inArray[index] > inArray[index + 1]) return true;
            else return false;
        }
        else if (index == inArray.Length - 1)
        {
            if (inArray[index] > inArray[index - 1]) return true;
            else return false;
        }
        else if ((inArray[index] > inArray[index - 1]) && (inArray[index] > inArray[index + 1])) return true;
        else return false;
    }

    static void Main()
    {
        int n, indexToCheck;
        bool isBigger;
        
        indexToCheck = int.Parse(Console.ReadLine());

        n = int.Parse(Console.ReadLine());
        
        int[] numArray = new int[n];
        for (int i = 0; i < n; i++) numArray[i] = int.Parse(Console.ReadLine());
        
        isBigger = CheckBiggerAtIndex(numArray, indexToCheck);

        Console.WriteLine("Is element with index {0} bigger than its neighbours ? {1}",indexToCheck, isBigger);

    }
}

