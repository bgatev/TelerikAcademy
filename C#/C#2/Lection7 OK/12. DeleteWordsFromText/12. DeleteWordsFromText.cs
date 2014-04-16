//Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class DeleteWordsFromText
{
    static string FixLine(string line, string source)
    {
        string fixedLine = string.Empty;
        int startIndex = 0;

        try
        {
            do
            {
                startIndex = line.IndexOf(source, 0);

                //fix for line < source.length
                if (startIndex == -1)
                {
                    fixedLine += line;
                    break;
                }

                //find word
                if ((line[startIndex - 1] == ' ') && (line[startIndex + source.Length] == ' '))
                {
                    if (startIndex != -1)
                    {
                        fixedLine += line.Substring(0, startIndex);
                        line = line.Substring(startIndex + source.Length + 1);
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
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("The index of the string method is out of range - please check your code");    
            throw new ArgumentException();
        }

        return fixedLine;
    }

    static void Main()
    {
        const string FilePath = @"..\..\";
        const string FileName = @"test.txt";
        const string FilePathWords = @"..\..\";
        const string FileNameWords = @"words.txt";
        
        List<string> listOfStrings = new List<string>();
        List<string> words = new List<string>();

        try
        {
            using (StreamReader wordsReader = new StreamReader(FilePathWords + FileNameWords, Encoding.GetEncoding("windows-1251")))
            {
                string line = string.Empty;

                line = wordsReader.ReadLine();
                while (line != null)
                {
                    words.Add(line);
                    line = wordsReader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251")))
            {
                string line = string.Empty;

                line = reader.ReadLine();
                while (line != null)
                {
                    foreach (var singleWord in words)
                    {
                        line = FixLine(line, singleWord);
                    }
                    listOfStrings.Add(line);
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

