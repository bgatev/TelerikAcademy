using System;
using System.Linq;
using System.Numerics;

class Task5
{
    static void SwapElementsInArray(char[] inArray, long sourceElement, long destElement)
    {
        char temp = '0';

        temp = inArray[sourceElement];
        inArray[sourceElement] = inArray[destElement];
        inArray[destElement] = temp;
    }

    static bool PermN(char[] inArray, long sequenceLength, ref BigInteger permCounter)
    {
        long num = sequenceLength - 1;
        long newNum = sequenceLength - 1;

        while ((num > 0) && (inArray[num] <= inArray[num - 1])) num--;

        num--;

        if (num < 0)
        {
            bool fix = true;

            for (long i = 0; i < inArray.Length - 1; i++) if (inArray[i] == inArray[i + 1]) fix = false; 
            if (fix) permCounter++;
            
            return false;
        }

        newNum = sequenceLength - 1;
        while ((newNum > num) && (inArray[newNum] <= inArray[num])) newNum--;

        SwapElementsInArray(inArray, num, newNum);

        sequenceLength--;
        num++;

        while (sequenceLength > num)
        {
            SwapElementsInArray(inArray, sequenceLength, num);
            num++;
            sequenceLength--;
        }

        for (long i = 0; i < inArray.Length - 1; i++)
        {
            if (inArray[i] == inArray[i + 1])
            {
                permCounter--;
                break;
            }
        }
        return true;
    }

    static void Main()
    {
        BigInteger permCounter = 0;
        
        string word = Console.ReadLine();

        char[] charArray = word.ToCharArray();

        Array.Sort(charArray);
        
        while (PermN(charArray, word.Length, ref permCounter)) permCounter++;
                    
        Console.WriteLine(permCounter);

    }
}

class Task5Evening
{
    static void SwapElementsInArray(char[] inArray, long sourceElement, long destElement)
    {
        char temp = '0';

        temp = inArray[sourceElement];
        inArray[sourceElement] = inArray[destElement];
        inArray[destElement] = temp;
    }

    static bool PermN(char[] inArray, long sequenceLength, ref BigInteger permCounter)
    {
        long num = sequenceLength - 1;
        long newNum = sequenceLength - 1;

        while ((num > 0) && (inArray[num] <= inArray[num - 1])) num--;

        num--;

        if (num < 0)
        {
            bool fix = true;

            for (long i = 0; i < inArray.Length - 1; i++) if (inArray[i] == inArray[i + 1]) fix = false;
            if (fix) permCounter++;

            return false;
        }

        newNum = sequenceLength - 1;
        while ((newNum > num) && (inArray[newNum] <= inArray[num])) newNum--;

        SwapElementsInArray(inArray, num, newNum);

        sequenceLength--;
        num++;

        while (sequenceLength > num)
        {
            SwapElementsInArray(inArray, sequenceLength, num);
            num++;
            sequenceLength--;
        }

        for (long i = 0; i < inArray.Length - 1; i++)
        {
            if (inArray[i] == inArray[i + 1])
            {
                permCounter--;
                break;
            }
        }
        return true;
    }

    static void Main1()
    {
        BigInteger permCounter = 0;
        int N = int.Parse(Console.ReadLine());
        char[] charArray = new char[N];

        for (int i = 0; i < N; i++)
        {
            string temp = Console.ReadLine();
            charArray[i] = temp[0];
        }

        Array.Sort(charArray);

        while (PermN(charArray, N, ref permCounter)) permCounter++;

        Console.WriteLine(permCounter);

    }
}