using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        string password = Console.ReadLine();
        int unknownDigits = 0;
        long result = 1;

        for (int i = 0; i < password.Length; i++) if (password[i] == '*') unknownDigits++;

        for (int i = 1; i < unknownDigits + 1; i++) result *= 2;
        
        Console.WriteLine(result);
    }
}