using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

class TwoIsBetterThanOne
{
    public static string ReverseString(int[] s)
    {
        StringBuilder sb = new StringBuilder();
        
        for (int i = s.Length - 1; i >= 0; i--) sb.Append(s[i]);
        
        return sb.ToString();
    }
        
    static string IncreaseLongNumber(string numString)
    {
        string result = string.Empty;
        int[] numArray = new int[numString.Length];
        int[] tempArray = new int[numString.Length + 1];

        for (int i = 0; i < numString.Length; i++) numArray[numString.Length - 1 - i] = numString[i] - '0';

        for (int i = 0; i < numArray.Length; i++)
        {
            if (i == 0) tempArray[i] += (numArray[i] + 1);
            else tempArray[i] += numArray[i];
            
            if (tempArray[i] > 9)
            {
                tempArray[i] -= 10;
                tempArray[i + 1] += 1;
            }
            
        }

        result = ReverseString(tempArray);
        result = result.TrimStart('0');
        return result;
    }
    
    static bool CheckPalindrom(string word)
    {
        int counter = 0;

        if (word.Length == 1)
        {
            if ((word == "3") || (word == "5")) return true;
            else return false;
        }
        for (int i = 0; i < word.Length / 2; i++) if ((word[i] == word[word.Length - i - 1]) && ((word[i] == '3') || (word[i] == '5'))) counter++;
                
        if (counter == word.Length / 2) return true;
        else return false;  
    }
    
    static int CountLuckyNums(string A, string B)
    {
        int count = 0;
        string currentNum = string.Empty;

        if (CheckPalindrom(A)) count++;
        if (A.Equals(B)) return count;

        currentNum = IncreaseLongNumber(A);
        if (currentNum.Equals(B))
        {
            if (CheckPalindrom(B)) count++;
            return count;
        }

        do
        {
            if (CheckPalindrom(currentNum)) count++;
            currentNum = IncreaseLongNumber(currentNum);
            if (currentNum.Equals(B))
            {
                if (CheckPalindrom(B)) count++;
                break;
            }
        }
        while (true);

        return count;
    }

    static int FindSmallest(int[] inNumbers, int P)
    {
        int smallestNum = int.MinValue, index = 0;
        double percentage;

        percentage = (double)P / (double)100 * (double)inNumbers.Length;
        if (percentage == 0) index = 0;
        else if ((percentage % 1) > 0) index = (int)(percentage);
        else index = (int)(percentage) - 1;

        Array.Sort(inNumbers);
        smallestNum = inNumbers[index];

        return smallestNum;
    }

    static void Main()
    {
        string A = string.Empty, B = string.Empty;
        int P, count = 0, smallestNum = int.MinValue;
        string inputStr = string.Empty;

        inputStr = Console.ReadLine();
        string[] inputAB = inputStr.Split(' ');
        A = inputAB[0];
        B = inputAB[1];

        inputStr = Console.ReadLine();
        string[] inputNumStr = inputStr.Split(',');
        int[] inputNums = new int[inputNumStr.Length];

        for (int i = 0; i < inputNums.Length; i++) inputNums[i] = int.Parse(inputNumStr[i]);

        P = int.Parse(Console.ReadLine());

        Stopwatch sw = new Stopwatch();
        sw.Start();

        count = FindLuckyNumbersBySybo(long.Parse(A), long.Parse(B));//CountLuckyNums(A, B);
        smallestNum = FindSmallest(inputNums, P);

        sw.Stop();

        Console.WriteLine(count);
        Console.WriteLine(smallestNum);
        //Console.WriteLine(sw.Elapsed);

    }

    static int FindLuckyNumbersBySybo(long lowerBound, long upperBound)
    {
        long max = upperBound;
        int left = 0;
        var numbers = new List<long> { 3, 5 };

        int count = 0;
        while (left < numbers.Count)
        {
            int right = numbers.Count;
            for (int i = left; i < right; i++)
            {
                if (numbers[i] < max)
                {
                    numbers.Add((numbers[i] * 10) + 3);
                    numbers.Add((numbers[i] * 10) + 5);
                }
            }
            left = right;
        }

        foreach (var num in numbers)
        {
            if (num >= lowerBound && num <= upperBound && CheckPalindrom(num.ToString())) count++;
        }

        return count;
    }
}

