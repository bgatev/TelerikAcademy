//Write a method that reverses the digits of given decimal number. Example: 256  652

using System;

class ReverseDigits1
{
    static int ReverseDigits(int num)
    {
        int result;
        string numString = string.Empty, temp = string.Empty;

        numString = Convert.ToString(num);
        for (int i = numString.Length - 1; i > -1; i--) temp += numString[i];
        result = int.Parse(temp);
        
        return result;
    }
    
    static void Main()
    {
        int num,reversedNum;

        num = int.Parse(Console.ReadLine());
       
        reversedNum = ReverseDigits(num);
        Console.WriteLine(reversedNum);
    }
}

