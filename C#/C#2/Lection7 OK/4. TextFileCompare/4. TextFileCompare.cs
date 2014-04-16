//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that 
//are different. Assume the files have equal number of lines.

using System;
using System.IO;
using System.Linq;
using System.Text;

class TextFileCompare
{
    static void Main()
    {
        const string FilePath1 = @"";
        const string FilePath2 = @"";
        const string FileName1 = @"test1.txt";
        const string FileName2 = @"test2.txt";
       
        string lineFile1 = string.Empty, lineFile2 = string.Empty;
        int equalLines = 0, differentLines = 0;

        try
        {
            StreamReader reader1 = new StreamReader(FilePath1 + FileName1, Encoding.GetEncoding("windows-1251"));
            StreamReader reader2 = new StreamReader(FilePath2 + FileName2, Encoding.GetEncoding("windows-1251"));

            try
            {
                lineFile1 = reader1.ReadLine();
                lineFile2 = reader2.ReadLine();

                while (lineFile1 != null)
                {
                    if (lineFile1.CompareTo(lineFile2) == 0) equalLines++;
                    else differentLines++;

                    lineFile1 = reader1.ReadLine();
                    lineFile2 = reader2.ReadLine();
                }
            }
            finally
            {
                reader1.Close();
                reader2.Close();

                Console.WriteLine("You have {0} equal lines and {1} different lines", equalLines, differentLines);
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

