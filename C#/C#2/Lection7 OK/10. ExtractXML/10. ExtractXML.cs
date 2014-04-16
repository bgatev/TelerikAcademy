//Write a program that extracts from given XML file all the text without the tags. Example:
// <?xml version="1.0"><student><name>PESHO</name><age>21</age><interests count="3"><interest> GAMES</instrest>
// <interest>C#</instrest><interest> JAVA</instrest></interests></student>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class ExtractXML1
{
    static string ExtractXML(string line)
    {
        string fixedLine = string.Empty;
        int startIndex = 0, endIndex = 0;

        do
        {
            startIndex = line.IndexOf('>');
            line = line.Substring(startIndex + 1);
            
            if (line == "") break;
            
            if (line[0] == '<') continue;
            else
            {
                endIndex = line.IndexOf('<');
                fixedLine += line.Substring(0,endIndex);
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

        List<string> listOfStrings = new List<string>();

        try
        {
            using (StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251")))
            {
                string line = string.Empty;
               
                line = reader.ReadLine();
                while (line != null)
                {
                    listOfStrings.Add(ExtractXML(line));
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(FilePathResult + FileNameResult, false, Encoding.GetEncoding("windows-1251")))
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

