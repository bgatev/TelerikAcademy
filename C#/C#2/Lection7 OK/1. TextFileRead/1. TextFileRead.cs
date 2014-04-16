//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.Linq;
using System.IO;
using System.Text;


class TextFileRead
{
    static void Main()
    {
        const string FilePath = @"C:\Windows\";
        const string FileName = @"win.ini";
        string line = string.Empty;
        int counter = 0;

        try
        {
            using (StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251")))
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    counter++;
                    if (counter % 2 != 0) Console.WriteLine(line);
                    line = reader.ReadLine();
                }
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

