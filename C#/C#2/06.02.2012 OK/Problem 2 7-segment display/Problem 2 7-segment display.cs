using System;
using System.Collections.Generic;
using System.Linq;

class Problem27segmentDisplay
{
    static byte[] digits = new byte[10]
    {
        Convert.ToByte("1111110", 2), // 0
        Convert.ToByte("0110000", 2), // 1
        Convert.ToByte("1101101", 2), // 2
        Convert.ToByte("1111001", 2), // 3
        Convert.ToByte("0110011", 2), // 4
        Convert.ToByte("1011011", 2), // 5
        Convert.ToByte("1011111", 2), // 6
        Convert.ToByte("1110000", 2), // 7
        Convert.ToByte("1111111", 2), // 8
        Convert.ToByte("1111011", 2), // 9
    };

    static byte[] segments;
    static char[] currentResult;
    static List<string> result = new List<string>();

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        segments = new byte[N];
        currentResult = new char[N];    //razrednost na display-a

        for (int i = 0; i < N; i++) segments[i] = Convert.ToByte(Console.ReadLine(), 2);

        FindDigits(0, ref N);
        
        Console.WriteLine(result.Count);
        foreach (string singleResult in result)
        {
            Console.WriteLine(singleResult);
        }
    }   

    static void FindDigits(int numberPosition, ref int N)
    {
        if (numberPosition == N)    //pro4eli sme vsi4ki segmenti
        {
            result.Add(new string(currentResult));
            return;
        }
        for (int i = 0; i < digits.Length; i++)
        {
            if ((digits[i] & segments[numberPosition]) == segments[numberPosition])
            {
                currentResult[numberPosition] = (char)('0' + i);
                FindDigits(numberPosition + 1, ref N);
            }
        }
    }
}

