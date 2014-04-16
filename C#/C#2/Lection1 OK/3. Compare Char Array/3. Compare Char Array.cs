//Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class CompareCharArray
{
    static void Main()
    {
        char[] charArray = new char[5];
        char[] charArray2 = new char[charArray.Length];

        for (int i = 0; i < charArray.Length; i++)
        {
            Console.Write("Input {0} element of the first and second array: ", i);
            charArray[i] = char.Parse(Console.ReadLine());
            charArray2[i] = char.Parse(Console.ReadLine());
            if (charArray[i] > charArray2[i]) Console.WriteLine("{0} element of first array is bigger", i);
            else if (charArray[i] < charArray2[i]) Console.WriteLine("{0} element of first array is smaller", i);
            else Console.WriteLine("{0} element of both arrays is equal", i);
        }

    }
}

