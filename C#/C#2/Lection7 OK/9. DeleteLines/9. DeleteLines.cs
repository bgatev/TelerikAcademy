//Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class DeleteLines
{
    static void Main()
    {
        const string FilePath = @"..\..\";
        const string FileName = @"test.txt";

        List<string> listOfStrings = new List<string>();

        try
        {
            using (StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251")))
            {
                string line = string.Empty;
                int fileLines = 0;
                
                line = reader.ReadLine();
                while (line != null)
                {
                    fileLines++;
                    if (fileLines % 2 != 0) listOfStrings.Add(line);
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(FilePath + FileName, false,Encoding.GetEncoding("windows-1251")))
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

