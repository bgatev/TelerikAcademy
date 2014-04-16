using System;

class BubbleSortClass
{
    static void BubbleSort(int[] inArray)
    {
        int temp = 0;
        
        for (int i = 0; i < inArray.Length; i++)
        {
            for (int j = 0; j < inArray.Length - 1; j++)
            {
                if (inArray[j] > inArray[j + 1])
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
        int[] numArray = new int[n];
        
        for (int i = 0; i < numArray.Length; i++) numArray[i] = int.Parse(Console.ReadLine());

        BubbleSort(numArray);

        for (int i = 0; i < numArray.Length; i++) Console.Write("{0} ", numArray[i]);
    }
}

