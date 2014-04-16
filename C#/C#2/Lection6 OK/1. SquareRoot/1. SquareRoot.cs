//Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative, 
//print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

using System;

class SquareRoot
{
    static void Main()
    {
        int num;

        try
        {
            num = int.Parse(Console.ReadLine());
            if (num < 0) throw new FormatException();
            Console.WriteLine(Math.Sqrt(num));
        }
        
        catch(FormatException)
        {
            Console.WriteLine("Invalid Number");
        }
        
        finally
        {
            Console.WriteLine("Good bye");
        }

    }
}

