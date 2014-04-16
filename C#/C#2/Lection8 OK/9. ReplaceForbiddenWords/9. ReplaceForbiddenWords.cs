//We are given a string containing a list of forbidden words and a text containing some of these words. Write a program that replaces the 
//forbidden words with asterisks. Example:
//Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
//Words: "PHP,CLR,Microsoft"
//		The expected result:
//********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

using System;
using System.Linq;

class ReplaceForbiddenWords
{
    static string FixLine(string line, string source, char dest)
    {
        string fixedLine = string.Empty, replaced = string.Empty;
        int startIndex = 0;

        replaced = replaced.PadLeft(source.Length, dest);

        do
        {
            startIndex = line.IndexOf(source, 0);

            //fix for line < source.length
            if (startIndex == -1)
            {
                fixedLine += line;
                break;
            }

            //find word - word is a string of chars (not symbols or digits)
            if ( ((line[startIndex - 1] < 'A') || (line[startIndex - 1] > 'z')) || ((line[startIndex - 1] < 'a') && (line[startIndex - 1] > 'Z'))
                && ((line[startIndex + source.Length] < 'A') || (line[startIndex + source.Length] > 'z'))
                || ((line[startIndex + source.Length] < 'a') && (line[startIndex + source.Length] > 'Z')) )
            {
                if (startIndex != -1)
                {
                    fixedLine += line.Substring(0, startIndex) + replaced;
                    line = line.Substring(startIndex + source.Length);
                }
                else fixedLine += line;
            }
            else
            {
                fixedLine += line.Substring(0, startIndex + source.Length);
                line = line.Substring(startIndex + source.Length);
            }
        }
        while (startIndex != -1);

        return fixedLine;
    }

    static void Main()
    {
        const string wordsList = "PHP,CLR,Microsoft";

        string outputString = string.Empty;
        char charToReplace = '*';
        string[] words = wordsList.Split(',');
        
        outputString = Console.ReadLine();

        for (int i = 0; i < words.Length; i++) outputString = FixLine(outputString, words[i], charToReplace); 
        
        Console.WriteLine(outputString);      
    }
}

