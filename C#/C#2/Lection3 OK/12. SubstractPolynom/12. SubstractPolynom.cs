//Extend the program to support also subtraction and multiplication of polynomials.

using System;

class SubstractPolynom
{
    static void StringParse(string inString, int[] outArray)
    {
        string[] s;

        s = inString.Split('+');

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Length == 1)
            {
                if (s[i] == "x") outArray[1] = 1;
                else outArray[0] = int.Parse(s[i]);
            }
            else if (s[i].Length == 2)
            {
                if (s[i][0] == 'x') outArray[s[i][1] - '0'] = 1;
                else outArray[1] = s[i][0] - '0';
            }
            else outArray[s[i][2] - '0'] = s[i][0] - '0';
        }

    }

    static void SubstractArraysAndPrint(int[] inArray1, int[] inArray2, int[] outArray)
    {
        for (int i = inArray1.Length - 1; i > -1; i--)
        {
            if (i > 0) outArray[i - 1] = inArray1[i - 1] - inArray2[i - 1];
            outArray[i] = inArray1[i] - inArray2[i];
            if ((outArray[i] != 0) && (i != 0))
            {
                if (outArray[i - 1] >= 0) Console.Write("{0}x^{1} +", outArray[i], i);
                else Console.Write("{0}x^{1} ", outArray[i], i);
            }
            else if (i == 0) Console.Write("{0}", outArray[i]);
        }
        Console.WriteLine();
    }

    static void MultiplyArraysAndPrint(int[] inArray1, int[] inArray2, int[] outArray)
    {
        for (int i = inArray1.Length - 1; i > -1; i--)
        {
            if (i > 0) outArray[i - 1] = inArray1[i - 1] * inArray2[i - 1];
            outArray[i] = inArray1[i] * inArray2[i];
            if ((outArray[i] != 0) && (i != 0))
            {
                if (outArray[i - 1] >= 0) Console.Write("{0}x^{1} +", outArray[i], i);
                else Console.Write("{0}x^{1} ", outArray[i], i);
            }
            else if (i == 0) Console.Write("{0}", outArray[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        string polynom1 = string.Empty, polynom2 = string.Empty;

        int[] polynom1Array = new int[20];
        int[] polynom2Array = new int[20];
        int[] resultArray = new int[20];

        polynom1 = Console.ReadLine();
        polynom2 = Console.ReadLine();

        /*polynom1 = "5";
        polynom2 = "x";
        polynom1 = "3x";
        polynom2 = "x+5";
        polynom1 = "4x+2";
        polynom2 = "x2";
        polynom1 = "9x2";
        polynom2 = "x2+6";
        polynom1 = "8x2+9";
        polynom2 = "x2+x";
        polynom1 = "3x2+5x";
        polynom2 = "x2+x+9";
        polynom1 = "7x2+3x+4";
        polynom2 = "x3+5";*/

        StringParse(polynom1, polynom1Array);
        StringParse(polynom2, polynom2Array);

        SubstractArraysAndPrint(polynom1Array, polynom2Array, resultArray);
        MultiplyArraysAndPrint(polynom1Array, polynom2Array, resultArray);
    }
}

