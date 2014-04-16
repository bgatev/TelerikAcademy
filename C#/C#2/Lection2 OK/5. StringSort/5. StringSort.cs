//You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

using System;

class StringSort
{
    static void BubbleSort(string[] inArray)
    {
        string temp = string.Empty;

        for (int i = 0; i < inArray.Length; i++)
        {
            for (int j = 0; j < inArray.Length - 1; j++)
            {
                if (inArray[j].Length > inArray[j + 1].Length)
                {
                    temp = inArray[j + 1];
                    inArray[j + 1] = inArray[j];
                    inArray[j] = temp;
                }
            }
        }

    }

    static void Main()
    {
        int n;

        n = int.Parse(Console.ReadLine());
        string[] stringArray = new string[n];

        for (int i = 0; i < stringArray.Length; i++) stringArray[i] = Console.ReadLine();

        BubbleSort(stringArray);

        for (int i = 0; i < stringArray.Length; i++) Console.Write("{0} ", stringArray[i]);
    }
}

