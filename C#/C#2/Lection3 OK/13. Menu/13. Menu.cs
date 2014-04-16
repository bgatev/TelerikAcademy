//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//		Create appropriate methods.
//		Provide a simple text-based menu for the user to choose which task to solve.
//		Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

using System;

class Menu
{
    static void ReverseDigits()
    {
        string numString = string.Empty, temp = string.Empty;
        int num, reversedNum;

        do
        {
            Console.Write("Input non negative number: ");
            num = int.Parse(Console.ReadLine());
        }
        while (num < 0);

        numString = Convert.ToString(num);
        for (int i = numString.Length - 1; i > -1; i--) temp += numString[i];
        
        reversedNum = int.Parse(temp);
        Console.WriteLine("Reversed number is: {0}",reversedNum);
    }

    static void CalcAverage()
    {
        int num;
        double result = 0;

        do
        {
            Console.Write("Input number of numbers to calculate: ");
            num = int.Parse(Console.ReadLine());
        }
        while (num == 0);

        int[] numArray = new int[num];
        for (int i = 0; i < num; i++)
        {
            numArray[i] = int.Parse(Console.ReadLine());
            result += numArray[i];
        }

        result /= num;
        Console.WriteLine("The average of all integers is: {0:F2}",result);
        
    }

    static void LinearEquationSolver()
    {
        double a, b;
        
        do
        {
            Console.Write("Input non-zero a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Input b: ");
            b = double.Parse(Console.ReadLine());
        }
        while (a == 0);

        Console.WriteLine("For equation {0} * x + {1} = 0 -> x = {2:F2}", a, b, -b/a);

    }

    static void Main()
    {
        int choice;
        
        Console.WriteLine("Please choose your task:");
        Console.WriteLine();
        Console.WriteLine("1. Reverses the digits of a number");
        Console.WriteLine("2. Calculates the average of a sequence of integers");
        Console.WriteLine("3. Solves a linear equation a * x + b = 0");
        Console.WriteLine();
        Console.Write("Your Choice: ");
        choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: ReverseDigits();
                    break;
            case 2: CalcAverage();
                    break;
            case 3: LinearEquationSolver();
                    break;
            default: break;
        }
    }
}

