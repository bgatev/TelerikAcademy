//Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using 
//the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

class BinarySearch
{
    static void Main()
    {
        int N, K, indexOfFoundNum = 0;
        K = int.Parse(Console.ReadLine());

        N = int.Parse(Console.ReadLine());

        int[] numArray = new int[N];
        for (int i = 0; i < numArray.Length; i++) numArray[i] = int.Parse(Console.ReadLine());

        Array.Sort(numArray);
        indexOfFoundNum = Array.BinarySearch(numArray, K);

        if (indexOfFoundNum > -1) Console.WriteLine(K);
        else if (indexOfFoundNum == -1) Console.WriteLine("All numbers are bigger than {0}, but the smallest is {1}",K,numArray[0]);
        else Console.WriteLine(numArray[-indexOfFoundNum - 2]);
    }
}

