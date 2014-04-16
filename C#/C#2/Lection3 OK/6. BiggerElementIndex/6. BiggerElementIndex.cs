//Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
//Use the method from the previous exercise

using System;

class BiggerElementIndex
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
        int n, indexOfBigger = -1;
        bool isBigger;

        n = int.Parse(Console.ReadLine());

        int[] numArray = new int[n];
        for (int i = 0; i < n; i++) numArray[i] = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            isBigger = CheckBiggerAtIndex(numArray, i);
            if (isBigger)
            {
                indexOfBigger = i;
                break;
            }
        }
        
        Console.WriteLine("Index of the first element, that its bigger than its neighbours is {0}", indexOfBigger);

    }
}

