//Modify the solution of the previous problem to replace only whole words (not substrings).


using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

class ReplaceWords
{
    static string FixLine(string line, string source, string dest)
    {
        string fixedLine = string.Empty;
        int startIndex = 0;

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
                    fixedLine += line.Substring(0, startIndex) + dest;
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
        const string FilePath = @"..\..\";
        const string FileName = @"test.txt";
        const string FilePathResult = @"..\..\";
        const string FileNameResult = @"output.txt";
        const string stringToReplace = "start";
        const string replaceWith = "finish";

        string line = string.Empty;

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        try
        {
            StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251"));
            StreamWriter writer = new StreamWriter(FilePathResult + FileNameResult, false, Encoding.GetEncoding("windows-1251"));

            try
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    writer.WriteLine(FixLine(line, stringToReplace, replaceWith));
                    line = reader.ReadLine();
                }
            }
            finally
            {
                reader.Close();
                writer.Close();

                stopWatch.Stop();
                Console.WriteLine(stopWatch.Elapsed);
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

