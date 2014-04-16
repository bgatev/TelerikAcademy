//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. 
//Format the output aligned right in 15 symbols.

using System;
using System.Linq;
using System.Threading;

class NumberRepresentation
{
    static void Main(string[] args)
    {
        int num;
        string result = string.Empty;

        //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        num = int.Parse(Console.ReadLine());
        
        result = string.Format("In decimal: {0,15:G}\nIn hexadecimal: {1,11:X4}\nIn precentage: {2,17:P2}\nIn scientific: {3,15:0.##E+0}", num, num, num, num);
        
        Console.WriteLine(result);
    }
}

