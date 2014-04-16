//Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another 
//file test.txt. The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in 
//descending order. Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Find
{
    private static List<string> words = new List<string>();
        
    static void ReadWords()
    {
        const string FilePathWords = @"..\..\";
        const string FileNameWords = @"words.txt";
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
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid Argument during words reading - Your variables is NULL");
            throw new Exception();
        }

        catch (ArgumentException)
        {
            Console.WriteLine("Invalid Argument during words reading - Please see your variables");
            throw new Exception();
        }

        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid Path - Please check your full path for file {0}", FileNameWords);
            throw new Exception();
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Invalid Filename - File not found {0}", FileNameWords);
            throw new Exception();
        }

        catch (IOException)
        {
            Console.WriteLine("Please check your full path and filename for words reading file");
            throw new Exception();
        }
    }

    static void ReadFile(int[] wordsCount)
    {
        const string FilePath = @"..\..\";
        const string FileName = @"test.txt";

        try
        {
            using (StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251")))
            {
                string line = string.Empty;
                int counter = 0;

                line = reader.ReadLine();
                while (line != null)
                {
                    foreach (var singleWord in words)
                    {
                        wordsCount[counter] += CountWordsInLine(line, singleWord);
                        counter++;
                    }
                    line = reader.ReadLine();
                    counter = 0;
                }
            }
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid Argument during file reading - Your variables is NULL");
            throw new Exception();
        }

        catch (ArgumentException)
        {
            Console.WriteLine("Invalid Argument during file reading - Please see your variables");
            throw new Exception();
        }

        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid Path - Please check your full path for file {0}", FileName);
            throw new Exception();
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Invalid Filename - File not found {0}", FileName);
            throw new Exception();
        }

        catch (IOException)
        {
            Console.WriteLine("Please check your full path and filename for file reading");
            throw new Exception();
        }
    }

    static void WriteResult(string[] wordsArray, int[] wordsCount)
    {
        const string FilePathResult = @"..\..\";
        const string FileNameResult = @"result.txt";

        try
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePathResult + FileNameResult, false, Encoding.GetEncoding("windows-1251")))
                {
                    for (int i = 0; i < wordsCount.Length; i++) writer.WriteLine("Word '{0}' occurs {1} times.", wordsArray[i], wordsCount[i]);
                }
            }
            finally
            {
                Console.WriteLine("File is written");
            }
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid Argument during file writing - Your variables is NULL");
            throw new Exception();
        }

        catch (ArgumentException)
        {
            Console.WriteLine("Invalid Argument during file writing - Please see your variables");
            throw new Exception();
        }

        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid Path - Please check your full path for file {0}", FileNameResult);
            throw new Exception();
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Invalid Filename - File can not be written {0}", FileNameResult);
            throw new Exception();
        }

        catch (IOException)
        {
            Console.WriteLine("Please check your full path and filename for file writing ");
            throw new Exception();
        }
    }

    static int CountWordsInLine(string line, string source)
    {
        int counter = 0, startIndex = 0;

        try
        {
            do
            {
                startIndex = line.IndexOf(source, 0);

                //fix for line < source.length and line with word found at the end
                if (startIndex == -1) break;
                else if (startIndex == (line.Length - source.Length))
                {
                    counter++;
                    break;
                }

                //find word
                if ((line[startIndex - 1] == ' ') && (line[startIndex + source.Length] == ' '))
                {
                    if (startIndex != -1)
                    {
                        counter++;
                        line = line.Substring(startIndex + source.Length + 1);
                    }
                }
                else line = line.Substring(startIndex + source.Length);
            }
            while (startIndex != -1);
        }

        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The index of the string method is out of range - please check your code");
            throw new Exception();
        }

        return counter;
    }

    static void BubbleSort(int[] countsArray, string[] wordsArray)
    {
        int temp = 0;
        string tempWord = string.Empty;

        try
        {
            for (int i = 0; i < countsArray.Length; i++)
            {
                for (int j = 0; j < countsArray.Length - 1; j++)
                {
                    if (countsArray[j] < countsArray[j + 1])
                    {
                        temp = countsArray[j + 1];
                        countsArray[j + 1] = countsArray[j];
                        countsArray[j] = temp;

                        tempWord = wordsArray[j + 1];
                        wordsArray[j + 1] = wordsArray[j];
                        wordsArray[j] = tempWord;
                    }
                }
            }
        }

        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Index is out of range - Please check your sorting code");
            throw new Exception();
        }
    }

    static void Main()
    {
        try
        {
            ReadWords();
            
            int[] wordsCount = new int[words.Count];

            ReadFile(wordsCount);

            string[] wordsArray = words.ToArray();
            BubbleSort(wordsCount, wordsArray);

            WriteResult(wordsArray, wordsCount);
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid Argument - Your variables is NULL. Check your full code");
        }

        catch (ArgumentException)
        {
            Console.WriteLine("Invalid Argument - Please see your variables. Check your full code");
        }
        
        //common exception for exit, when other exception occured
        catch
        {
            Console.WriteLine("You are totally fucked");
        }
    }
}

