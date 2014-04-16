//Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class DeleteWords
{
    static string FixLine(string line, string source)
    {
        string fixedLine = string.Empty;
        int startIndex = 0, endIndex = 0;

        do
        {
            startIndex = line.IndexOf(source, 0);
           
            //fix for line < source.length
            if (startIndex == -1)
            {
                fixedLine += line;
                break;
            }

            endIndex = line.IndexOf(' ', startIndex);

            //find word
            if ((line[startIndex - 1] == ' ') && (line[endIndex] == ' '))
            {
                if (startIndex != -1)
                {
                    fixedLine += line.Substring(0, startIndex);
                    line = line.Substring(endIndex + 1);
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
        const string FilePath = @"..\..\";
        const string FileName = @"test.txt";
        const string stringToReplace = "test";
        
        List<string> listOfStrings = new List<string>();

        try
        {
            using (StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251")))
            {
                string line = string.Empty;
                
                line = reader.ReadLine();
                while (line != null)
                {
                    listOfStrings.Add(FixLine(line, stringToReplace));
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(FilePath + FileName, false, Encoding.GetEncoding("windows-1251")))
            {
                foreach (var singleLine in listOfStrings)
                {
                    writer.WriteLine(singleLine);
                }
            }

            Console.WriteLine("File is written");
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid Argument - Your variables is NULL");
        }

        catch (ArgumentException)
        {
            Console.WriteLine("Invalid Argument - Please see your variables");
        }

        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid Path - Please check your full path");
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Invalid Filename - File not found");
        }

        catch (IOException)
        {
            Console.WriteLine("Please check your full path and filename");
        }

        catch
        {
            Console.WriteLine("You are totally fucked");
        }
    }
}

