//Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

using System;

class BinarySearch1
{
    static int BinarySearch(int[] inArray, int numToFind)
    {
        //return Array.BinarySearch(inArray, numToFind);      //Solution 1
        
        int left = 0, right = inArray.Length, mid;

        while (left <= right)
        {
            mid = (left + right) / 2;
            if (numToFind == inArray[mid]) return mid;
            else if (numToFind > inArray[mid]) left = mid + 1;
            else if (numToFind < inArray[mid]) right = mid - 1;
        }
        
        return -1;
    }
    
    static void Main()
    {
        int n, numberToFind, indexOfFoundNum = 0;
        numberToFind = int.Parse(Console.ReadLine());

        n = int.Parse(Console.ReadLine());
       
        int[] numArray = new int[n];
        for (int i = 0; i < numArray.Length; i++) numArray[i] = int.Parse(Console.ReadLine());

        indexOfFoundNum = BinarySearch(numArray, numberToFind);
                
        if (indexOfFoundNum >= 0) Console.WriteLine("Requested number is on the position {0}", indexOfFoundNum);
        else Console.WriteLine("There is no such number in the array");
    }
}

