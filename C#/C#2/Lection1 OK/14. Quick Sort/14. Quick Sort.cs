//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

using System;

class QuickSort1
{
    static int PartitionArray(string[] inArray, int leftElement, int rightElement)
    {
        for (int i = leftElement; i < rightElement; i++)
		{
            if (string.Compare(inArray[i],inArray[rightElement]) <= 0)      //i <= rightElement
            {
                SwapElementsInArray(inArray, i, leftElement);
                leftElement++;
            }
		}
        SwapElementsInArray(inArray, leftElement,rightElement);

        return leftElement;
    }

    static void SwapElementsInArray(string[] inArray, int sourceElement, int destElement)
    {
        string temp=string.Empty;

        temp = inArray[sourceElement];
        inArray[sourceElement] = inArray[destElement];
        inArray[destElement] = temp;
    }

    static void QuickSort(string[] inArray, int indexFirst, int indexLast)
    {
        if (indexFirst < indexLast)
        {
            int indexNewElement = PartitionArray(inArray, indexFirst, indexLast);

            QuickSort(inArray, indexFirst, indexNewElement - 1);
            QuickSort(inArray, indexNewElement + 1, indexLast);
        }
    }

    static void Main()
    {
        int n;

        n = int.Parse(Console.ReadLine());
        string[] stringArray = new string[n];

        for (int i = 0; i < stringArray.Length; i++) stringArray[i] = Console.ReadLine();

        QuickSort(stringArray, 0, n-1); // sort all elements in stringArray - these from index 0 to index n-1

        Console.WriteLine();
        for (int i = 0; i < stringArray.Length; i++) Console.WriteLine("{0}", stringArray[i]);
    }
}

