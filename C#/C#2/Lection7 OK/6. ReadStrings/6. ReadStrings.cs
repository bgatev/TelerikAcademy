//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
//	Ivan			George
//	Peter			Ivan
//	Maria			Maria
//	George			Peter

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class ReadStrings
{
    static void Main()
    {
        const string FilePath = @"..\..\";
        const string FileName = @"test.txt";
        const string FilePathResult = @"..\..\";
        const string FileNameResult = @"output.txt";

        string line = string.Empty;
        List<string> listOfStrings = new List<string>();

        try
        {
            StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251"));
            StreamWriter writer = new StreamWriter(FilePathResult + FileNameResult, false, Encoding.GetEncoding("windows-1251"));

            try
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    listOfStrings.Add(line);
                    line = reader.ReadLine();
                }
            }
            finally
            {
                listOfStrings.Sort();

                foreach (var singleLine in listOfStrings)
                {
                    writer.WriteLine(singleLine);
                }

                reader.Close();
                writer.Close();
                Console.WriteLine("File is written");
            }
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

