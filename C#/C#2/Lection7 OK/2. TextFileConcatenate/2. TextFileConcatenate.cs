//Write a program that concatenates two text files into another text file.

using System;
using System.IO;
using System.Linq;
using System.Text;

class TextFileConcatenate
{
    static void Main()
    {
        const string FilePath1 = @"";
        const string FilePath2 = @"";
        const string FileName1 = @"_2.TextFileConcatenate.exe.config";
        const string FileName2 = @"_2.TextFileConcatenate.vshost.exe.config";
        const string FilePathResult = @"";
        const string FileNameResult = @"test.txt";

        string line = string.Empty;

        try
        {
            StreamReader reader1 = new StreamReader(FilePath1 + FileName1, Encoding.GetEncoding("windows-1251"));
            StreamReader reader2 = new StreamReader(FilePath2 + FileName2, Encoding.GetEncoding("windows-1251"));
            StreamWriter writer = new StreamWriter(FilePathResult + FileNameResult, true, Encoding.GetEncoding("windows-1251"));

            try
            {
                line = reader1.ReadLine();
                while (line != null)
                {
                    writer.WriteLine(line);
                    line = reader1.ReadLine();
                }

                writer.WriteLine("The second file start here");
                line = reader2.ReadLine();
                while (line != null)
                {
                    writer.WriteLine(line);
                    line = reader2.ReadLine();
                }
            }
            finally
            {
                reader1.Close();
                reader2.Close();
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

