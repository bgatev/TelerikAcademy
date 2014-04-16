//Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class HexToDec1
{
    static int HexToDec(string inString)
    {
        int result = 0;

        for (int i = inString.Length - 1, j = 0; i > -1; i--, j++)
        {
            switch (inString[i])
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': result += ((inString[i] - '0') * (int)Math.Pow(16, j)); break;
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F': result += ((inString[i] - 'A' + 10) * (int)Math.Pow(16, j)); break;
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f': result += ((inString[i] - 'a' + 10) * (int)Math.Pow(16, j)); break;
            }
        }

        return result;
    }

    static void Main()
    {
        string num = string.Empty;
        int decValue = 0, sign = 1, temp = 0;

        do
        {
            Console.Write("Input less or equal than 8 bytes hex number:");
            num = Console.ReadLine();
        }
        while (num.Length > 8);

        if ((num.Length == 8) && (num[0] > '7'))        //negative number
        {
            sign = -1;
            switch (num[0])
            {
                case '8':
                case '9': temp = num[0] - '8'; break;
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F': temp = num[0] - 63; break;
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f': temp = num[0] - 95; break;
            }
            num = num.Substring(1);                 //get num without sign
            num = num.Insert(0, temp.ToString());   //add MS Byte without sign
            
            decValue = HexToDec(num);
            decValue = 0x7fffffff - decValue + 1;   
        }
        else decValue = HexToDec(num);
        
        Console.WriteLine(sign * decValue);
    }
}

