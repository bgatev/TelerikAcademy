//Write a program to convert decimal numbers to their hexadecimal representation.

using System;

class DecToHex1
{
    static string ReverseString(string inString)
    {
        string temp = string.Empty;

        for (int i = inString.Length - 1; i > -1; i--) temp += inString[i];

        return temp;
    }

    static string DecToHex(int num)
    {
        string hexResult = string.Empty;
        int temp;

        do
        {
            temp = num % 16;
            switch (temp)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9: hexResult += temp; break;
                case 10: hexResult += 'A'; break;
                case 11: hexResult += 'B'; break;
                case 12: hexResult += 'C'; break;
                case 13: hexResult += 'D'; break;
                case 14: hexResult += 'E'; break;
                case 15: hexResult += 'F'; break;
            }
            
            num /= 16;
        }
        while (num > 0);
        hexResult = ReverseString(hexResult);

        return hexResult;
    }

    static string DecToHex(uint num)
    {
        string hexResult = string.Empty;
        uint temp;

        do
        {
            temp = num % 16;
            switch (temp)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9: hexResult += temp; break;
                case 10: hexResult += 'A'; break;
                case 11: hexResult += 'B'; break;
                case 12: hexResult += 'C'; break;
                case 13: hexResult += 'D'; break;
                case 14: hexResult += 'E'; break;
                case 15: hexResult += 'F'; break;
            }

            num /= 16;
        }
        while (num > 0);
        hexResult = ReverseString(hexResult);

        return hexResult;
    }

    static void Main()
    {
        string hexValue = string.Empty;
        int num;    //32-bit number
        uint numN;

        num = int.Parse(Console.ReadLine());

        if (num >= 0) hexValue = DecToHex(num);
        else
        {
            numN = (uint) ~num;                                          //invert to get only positive num
            numN = 0xffffffff - numN;
            hexValue = DecToHex(numN);                                   //convert dec to hex
        }
        Console.WriteLine(hexValue);
    }
}

