//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: (()(a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;
using System.Linq;

class ValidateExpression
{
    static void Main()
    {
        string inputExpression = string.Empty;
        int startIndex = 0, endIndex = 0;

        inputExpression = "((a+b)(a*c)/5-d)";

        do
        {
            startIndex = inputExpression.IndexOf('(');
            endIndex = inputExpression.LastIndexOf(')');

            if ((startIndex == -1) && (endIndex == -1))
            {
                Console.WriteLine("The expression is correct");
                break;
            }
            else if ((startIndex == -1) || (endIndex == -1) || (endIndex < startIndex))
            {
                Console.WriteLine("The expression is incorrect");
                break;
            }

            inputExpression = inputExpression.Substring(startIndex + 1, endIndex - startIndex - 1);
        }
        while (true);    
    }
}

