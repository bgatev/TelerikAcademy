//Write a program that finds the maximal sequence of equal elements in an array.
//		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

using System;

class FindSequenceinArray
{
    static void Main()
    {
        int arrayLenght, maxSequence = 0, tempSequence = 1, index = 0;

        arrayLenght = int.Parse(Console.ReadLine());
        int[] numArray = new int[arrayLenght];

        for (int i = 0; i < arrayLenght; i++) numArray[i] = int.Parse(Console.ReadLine());

        for (int i = 0; i < arrayLenght-1; i++)
        {
            if (numArray[i] == numArray[i + 1]) tempSequence++;
            else
            {
                if (tempSequence > maxSequence)
                {
                    maxSequence = tempSequence;
                    index = i - (maxSequence - 1);
                }
                tempSequence = 1;
            }
            if (i == arrayLenght - 2)
            {
                if (tempSequence > maxSequence)
                {
                    maxSequence = tempSequence;
                    index = i - (maxSequence - 2);
                }
            }
        }

        Console.Write("Max sequence is {0} numbers: ", maxSequence);
        for (int i = index; i < index + maxSequence; i++) Console.Write("{0} ", numArray[i]);
        
            
        
        
    }
}

