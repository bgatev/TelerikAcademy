//* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

using System;

class MergeSort1
{
    static void Merge(int[] inArray, int indexFirst, int indexMid, int indexLast)
    {
        int[] tempArray = new int[inArray.Length*2];
        int indexFirstEnd, elementsNum, indexTemp;

        indexFirstEnd = (indexMid - 1);
        elementsNum = (indexLast - indexFirst + 1);
        indexTemp = indexFirst;

        while ((indexFirst <= indexFirstEnd) && (indexMid <= indexLast))
        {
            if (inArray[indexFirst] <= inArray[indexMid]) tempArray[indexTemp++] = inArray[indexFirst++];
            else tempArray[indexTemp++] = inArray[indexMid++];
        }

        while (indexFirst <= indexFirstEnd) tempArray[indexTemp++] = inArray[indexFirst++];
        while (indexMid <= indexLast) tempArray[indexTemp++] = inArray[indexMid++];

        for (int i = 0; i < elementsNum; i++)
        {
            inArray[indexLast] = tempArray[indexLast];
            indexLast--;
        }
    }

    static void MergeSort(int[] inArray, int indexFirst, int indexLast)
    {
        if (indexFirst < indexLast)
        {
            int indexMid = (indexFirst + indexLast) / 2;

            MergeSort(inArray, indexFirst, indexMid);
            MergeSort(inArray, (indexMid + 1), indexLast);

            Merge(inArray, indexFirst, (indexMid + 1), indexLast);
        }
    }
        
    static void Main()
    {
        int n;

        n = int.Parse(Console.ReadLine());
        int[] numArray = new int[n];

        for (int i = 0; i < numArray.Length; i++) numArray[i] = int.Parse(Console.ReadLine());

        MergeSort(numArray, 0, n - 1);      // sort all elements in numArray - these from index 0 to index n-1

        for (int i = 0; i < numArray.Length; i++) Console.Write("{0} ", numArray[i]);
    }
}

