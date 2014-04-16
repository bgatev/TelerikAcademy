//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
//		Example: The target substring is "in". The text is as follows:
//We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
//	The result is: 9.

using System;
using System.Linq;

class FindSubstring1
{
    static int FindSubstring(string line, string source)
    {
        int counter = 0, startIndex = 0;

        line = line.ToLower();
        do
        {
            startIndex = line.IndexOf(source, 0);

            if (startIndex != -1)
            {
                counter++;
                line = line.Substring(startIndex + source.Length);
            }
        } while (startIndex != -1);
        

        return counter;
    }

    static void Main()
    {
        string wordToFind = "In";
        string input = string.Empty;
        int counter = 0;

        input = Console.ReadLine();
        wordToFind = wordToFind.ToLower();

        counter = FindSubstring(input, wordToFind);

        Console.WriteLine(counter);

    }

}

