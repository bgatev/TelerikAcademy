//Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

using System;

class FindIncreasingSequenceinArray
{
    static void Main()
    {
        int arrayLenght, maxIncreasingSeq = 0, tempSequence = 1, index = 0;

        arrayLenght = int.Parse(Console.ReadLine());
        int[] numArray = new int[arrayLenght];

        for (int i = 0; i < arrayLenght; i++) numArray[i] = int.Parse(Console.ReadLine());

        for (int i = 0; i < arrayLenght - 1; i++)
        {
            if (numArray[i] < numArray[i + 1]) tempSequence++;
            else
            {
                if (tempSequence > maxIncreasingSeq)
                {
                    maxIncreasingSeq = tempSequence;
                    index = i - (maxIncreasingSeq - 1);
                }
                tempSequence = 1;
            }
        }

        Console.Write("Max increasing sequence is {0} numbers: ", maxIncreasingSeq);
        for (int i = index; i < index + maxIncreasingSeq; i++) Console.Write("{0} ", numArray[i]);

    }
}

