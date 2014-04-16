using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public static class RWFiles
    {
        public static string ReadFile(string fullPathFileName)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using (StreamReader reader = new StreamReader(fullPathFileName, Encoding.GetEncoding("windows-1251")))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        sb.AppendLine(line);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (DirectoryNotFoundException exc)
            {
                Console.WriteLine("Directory {0} is not found.", exc.Message);
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine("File {0} is not found.", exc.FileName);
            }
            catch (NullReferenceException exc)
            {
                Console.WriteLine(exc.Message);
            }

            return sb.ToString();
        }

        public static void WriteFile(string fullPathFileName, string writeData)
        {
            string[] dataToWrite = writeData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                using (StreamWriter writer = new StreamWriter(fullPathFileName, true))
                {
                    for (int i = 0; i < dataToWrite.Count(); i++) writer.WriteLine(dataToWrite[i]);                    
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You don't have write access to this file");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Please check your path - directory not found");
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
