//Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. 
//Find in Google how to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.IO;
using System.Net;

class Download
{
    static void Main()
    {
        string remoteUrl = "http://www.devbg.org/img/";
        string fileName = "Logo-BASD.jpg", nullArgument = null;

        using (WebClient myWebClient = new WebClient())
        {
            try
            {
                myWebClient.DownloadFile(remoteUrl + fileName, fileName);
                Console.WriteLine("File is downloaded successfully");
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid Argument - Your variables is NULL");
            }

            catch (WebException)
            {
                Console.WriteLine("Please check your URL and filename");
            }

            catch
            {
                Console.WriteLine("You are totally fucked");
            }
            finally
            {
                myWebClient.Dispose();
            }
        }

    }
}

