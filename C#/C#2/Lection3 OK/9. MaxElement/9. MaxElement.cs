//Write a method that return the maximal element in a portion of array of integers starting at given index. Using it write 
//another method that sorts an array in ascending / descending order.

using System;

class MaxElement
{
    static void Sort(int[] inArray)
    {
        int[] tempArray = new int[inArray.Length];

        for (int i = 0; i < inArray.Length; i++)
        {
            tempArray[inArray.Length - 1 - i] = MaxElementInArray(inArray, 0);
            for (int j = 0; j < inArray.Length; j++)
            {
                if (inArray[j] == tempArray[inArray.Length - 1 - i])
                {
                    inArray[j] = int.MinValue;
                    break;
                }
            }
        }
        for (int i = 0; i < inArray.Length; i++) inArray[i] = tempArray[i];
        
    }
    
    static int MaxElementInArray(int[] inArray, int indexStart)
    {
        int maxElement = int.MinValue;

        for (int i = indexStart; i < inArray.Length; i++)
        {
            if (inArray[i] > maxElement) maxElement = inArray[i];
        }
        return maxElement;
    }
    
    static void Main()
    {
        int n, indexStart, maxElement;

        indexStart = int.Parse(Console.ReadLine());
        n = int.Parse(Console.ReadLine());

        int[] numArray = new int[n];
        for (int i = 0; i < n; i++) numArray[i] = int.Parse(Console.ReadLine());

        maxElement = MaxElementInArray(numArray, indexStart);
        Console.WriteLine("Max element in the array is {0}", maxElement);

        Sort(numArray);
        for (int i = 0; i < n; i++) Console.Write("{0} ", numArray[i]);
        
    }
}

