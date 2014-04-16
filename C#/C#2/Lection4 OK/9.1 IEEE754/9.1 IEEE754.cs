//IEEE754 solution 2

using System;
using System.Linq;

class IEEE754
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

    static string CalculateMantissa(float num, int calcLenght, out float numOut)
    {
        string result = string.Empty;

        for (int i = 0; i < calcLenght; i++)
        {
            num *= 2;
            if (num >= 1)
            {
                result += 1;
                num--;
            }
            else result += 0;
        }

        numOut = num;
        return result;
    }

    static int FirstOnePosition(string inString)
    {
        int i = -1;

        for (i = 0; i < inString.Length; i++) if (inString[i] == '1') return i;
        
        return i;
    }

    static void Main()
    {
        float num, numTemp;
        int sign = 0, exponent = 0;
        string exponentString = string.Empty, mantissaString = string.Empty;

        Console.Write("Enter a single-precision floating-point number: ");
        num = float.Parse(Console.ReadLine());

        //get sign
        if (num < 0) sign = 1;
        num = Math.Abs(num);

        //get exponent as number and mantissa as number(stored in num)
        while (num > 1)
        {
            exponent++;
            num--;
        }

        mantissaString = CalculateMantissa(num, 23, out numTemp);
        /*for (int i = 0; i < 23; i++)
        {
            num *= 2;
            if (num >= 1)
            {
                mantissaString += 1;
                num--;
            }
            else mantissaString += 0;
        }*/

        if (exponent > 0)
        {
            exponentString = DecToBin(exponent);
            
            if (exponentString.Length > 1) mantissaString = exponentString.Substring(1) + mantissaString;
            mantissaString = mantissaString.Substring(0, 23);
            
            exponent = 127 + (exponentString.Length - 1);   
        }
        else if (exponent == 0)
        {
            int fOnes = FirstOnePosition(mantissaString);
            mantissaString = mantissaString.Substring(fOnes + 1);

            mantissaString += CalculateMantissa(numTemp, fOnes + 1, out num);
            /*for (int i = 0; i < fOnes + 1; i++)
            {
                num *= 2;
                if (num >= 1)
                {
                    mantissaString += 1;
                    num--;
                }
                else mantissaString += 0;
            }*/
            exponent = 127 - (fOnes + 1);
        }
        exponentString = DecToBin(exponent);
        exponentString = exponentString.PadLeft(8, '0'); 

        Console.WriteLine("The Sign is: {0}", sign);
        Console.WriteLine("The Exponent is: {0}", exponentString);
        Console.WriteLine("The Mantissa is: {0}", mantissaString);
    }
}

