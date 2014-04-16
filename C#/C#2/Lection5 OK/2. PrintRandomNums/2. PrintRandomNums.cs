//Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;
using System.Linq;

class PrintRandomNums
{
    static void Main()
    {
        Random ranNum = new Random();
        
        for (int i = 0; i < 10; i++) Console.WriteLine(ranNum.Next(99, 201));      
    }
}

