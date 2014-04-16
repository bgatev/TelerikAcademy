//Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; 
//the last digit is kept in arr[0]). Each of the numbers that will be added could have up to 10 000 digits.

using System;

class AddNumbers
{
    static string SumLongNumbers(string num1String, string num2String)
    {
        int shorterArray, longerArray;
        string result = string.Empty;
        bool array1IsLonger = false;

        int[] numArray1 = new int[num1String.Length];
        int[] numArray2 = new int[num2String.Length];

        for (int i = 0; i < num1String.Length; i++) numArray1[num1String.Length - 1 - i] = num1String[i] - '0';
        for (int i = 0; i < num2String.Length; i++) numArray2[num2String.Length - 1 - i] = num2String[i] - '0';

        if (numArray1.Length < numArray2.Length)
        {
            shorterArray = numArray1.Length;
            longerArray = numArray2.Length;
        }
        else
        {
            longerArray = numArray1.Length;
            shorterArray = numArray2.Length;
            array1IsLonger = true;
        }

        int[] tempArray = new int[longerArray + 1];
        
        for (int i = 0; i < shorterArray; i++)
        {
            tempArray[i] += numArray1[i] + numArray2[i];
            if (tempArray[i] > 9)
            {
                tempArray[i] -= 10;
                tempArray[i + 1] = 1;
            }
        }
        if (array1IsLonger)
        {
            for (int i = shorterArray; i < longerArray; i++)
            {
                tempArray[i] += numArray1[i];
                if (tempArray[i] > 9)
                {
                    tempArray[i] -= 10;
                    tempArray[i + 1] = 1;
                }
            }
        }
        else
        {
            for (int i = shorterArray; i < longerArray; i++)
            {
                tempArray[i] += numArray2[i];
                if (tempArray[i] > 9)
                {
                    tempArray[i] -= 10;
                    tempArray[i + 1] = 1;
                }
            }
        }
        for (int i = longerArray; i > -1; i--) result += tempArray[i];
			
        return result;
    }
    
    static void Main()
    {
        string num1String, num2String, sumOfInts;

        num1String = Console.ReadLine();
        num2String = Console.ReadLine();

        sumOfInts = SumLongNumbers(num1String, num2String);

        Console.WriteLine("{0} + {1} = {2}", num1String, num2String, sumOfInts);
    }
}

