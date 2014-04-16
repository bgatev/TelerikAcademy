//Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from 
//the console and prints the biggest of them using the method GetMax().

using System;

class GetMax1
{
    static int GetMax(int fNum, int sNum)
    {
        if (fNum > sNum) return fNum;
        else return sNum;
    }
    static void Main()
    {
        int fNum, sNum, tNum, biggerNum, biggestNum;
        fNum = int.Parse(Console.ReadLine());
        sNum = int.Parse(Console.ReadLine());
        tNum = int.Parse(Console.ReadLine());

        biggerNum = GetMax(fNum, sNum);
        biggestNum = GetMax(biggerNum, tNum);

        Console.WriteLine(biggestNum);
    }
}

