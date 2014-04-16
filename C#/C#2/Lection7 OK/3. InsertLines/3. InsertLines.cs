//Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

using System;
using System.IO;
using System.Linq;
using System.Text;

class InsertLines
{
    static void Main()
    {
        const string FilePath = @"";
        const string FileName = @"_3.InsertLines.exe.config";
        const string FilePathResult = @"";
        const string FileNameResult = @"test.txt";

        string line = string.Empty;
        int linenumber = 0;

        try
        {
            StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251"));
            StreamWriter writer = new StreamWriter(FilePathResult + FileNameResult, false, Encoding.GetEncoding("windows-1251"));

            try
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    linenumber++;
                    writer.WriteLine("{0}: {1}", linenumber, line);
                    line = reader.ReadLine();
                }
            }
            finally
            {
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

