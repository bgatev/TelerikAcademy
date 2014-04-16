//Write a program that creates an array containing all letters from the alphabet (A-Z). 
//Read a word from the console and print the index of each of its letters in the array.

using System;

class ReadWord
{
    static int FindIndex(char[] inArray, char letter)
    {
        return Array.BinarySearch(inArray, letter); 
    }
    
    static void Main()
    {
        char[] charArray = new char[26];
        for (int i = 0; i < charArray.Length; i++) charArray[i] = (char)('a' + i);

        string wordRead = Console.ReadLine();
        for (int i = 0; i < wordRead.Length; i++)
        {
            int index = FindIndex(charArray, wordRead[i]);
            Console.Write("{0} ", index);
        }
    }
}

