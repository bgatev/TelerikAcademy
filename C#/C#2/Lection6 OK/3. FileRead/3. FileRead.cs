//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the 
//console. Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;

class FileRead
{
    static void Main()
    {
        const string FilePath = @"C:\Windows\";
        const string FileName = @"win.ini";

        string nullArgument = null, invalidArgument = "";

        string fileContent = string.Empty;

        try
        {
            fileContent = File.ReadAllText(FilePath + FileName);
            Console.WriteLine(fileContent);
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

        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Please check your rights");
        }

        catch (System.Security.SecurityException)
        {
            Console.WriteLine("Please check your security rights");
        }

        catch
        {
            Console.WriteLine("You are totally fucked");
        }
    }
}

