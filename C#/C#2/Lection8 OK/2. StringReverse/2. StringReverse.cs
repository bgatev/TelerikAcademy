//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample"  "elpmas".

using System;
using System.Linq;
using System.Text;

class StringReverse
{
    public static string ReverseString(string s)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = s.Length - 1; i > -1; i--) sb.Append(s[i]);

        return sb.ToString();
    }

    static void Main()
    {
        string inputString = string.Empty;

        inputString = Console.ReadLine();

        inputString = ReverseString(inputString);
        Console.WriteLine(inputString);
    }
}

