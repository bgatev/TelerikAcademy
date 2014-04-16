//Write a program to convert decimal numbers to their binary representation.

using System;

class DecToBin1
{
    static string ReverseString(string inString)
    {
        string temp = string.Empty;

        for (int i = inString.Length - 1; i > -1; i--) temp += inString[i];
        
        return temp;
    }

    static string DecToBin(int num)
    {
        string binaryResult = string.Empty;

        do
        {
            binaryResult += num % 2;
            num /= 2;
        }
        while (num > 0);
        binaryResult = ReverseString(binaryResult);

        return binaryResult;
    }

    static string BinaryInvert(string inString)
    {
        string result = string.Empty;

        for (int i = 0; i < inString.Length; i++)
        {
            if (inString[i] == '0') result += 1;
            else result += 0;
        }
               
        return result;
    }

    static void Main()
    {
        string binValue = string.Empty;
        int num;    //32-bit number

        num = int.Parse(Console.ReadLine());

        if (num >= 0) binValue = DecToBin(num);
        else
        {
            num = ~num;                                                 //invert to get only positive num
            binValue = DecToBin(num);                                   //convert dec to bin
                        
            binValue = BinaryInvert(binValue);                          //invert for negative result
            binValue = binValue.PadLeft(32, '1');                       //fill all the leading 1 for 32-bit number
        }
        Console.WriteLine(binValue);

        

    }
}

