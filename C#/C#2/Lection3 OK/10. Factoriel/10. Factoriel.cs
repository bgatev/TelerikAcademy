//Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that multiplies a number 
//represented as array of digits by given integer number. 

using System;

class Factoriel
{
    static string MultiplyLongNumbers(int num1, string num2String)
    {
        string num1String = Convert.ToString(num1);
        string result = string.Empty;
       
        int[] numArray1 = new int[num1String.Length];
        int[] numArray2 = new int[num2String.Length];

        for (int i = 0; i < num1String.Length; i++) numArray1[num1String.Length - 1 - i] = num1String[i] - '0';
        for (int i = 0; i < num2String.Length; i++) numArray2[num2String.Length - 1 - i] = num2String[i] - '0';

        int[] tempArray = new int[numArray1.Length + numArray2.Length];

        for (int i = 0, k = 0; i < numArray1.Length; i++)
        {
            k = i;
            for (int j = 0; j < numArray2.Length; j++)
            {
                tempArray[k] += numArray1[i] * numArray2[j];
                if (tempArray[k] > 9)
                {
                    tempArray[k + 1] += tempArray[k] / 10;
                    tempArray[k] = tempArray[k] % 10;    
                }
                k++;
            }
        }

        for (int i = tempArray.Length - 1; i > -1; i--) result += tempArray[i];

        return result;
    }

    static void PrintStringNoLeadingZero(string inString)
    {
        int firstIndex = 0;
        for (int i = 0; i < inString.Length; i++) 
        {
            if (inString[i] == '0') firstIndex++;
            else break;
        }
        
        for (int i = firstIndex; i < inString.Length; i++) Console.Write("{0}", inString[i]);
        Console.WriteLine();
    }

    static void Main()
    {
        int num;
        string tempString, multiplyOfInts = "1";

        num = int.Parse(Console.ReadLine());
        
        for (int i = 1; i < num + 1; i++)
        {
            tempString = MultiplyLongNumbers(i, multiplyOfInts);
            multiplyOfInts = tempString;
        }

        Console.Write("{0}! = ", num);
        PrintStringNoLeadingZero(multiplyOfInts);
       
    }
}

