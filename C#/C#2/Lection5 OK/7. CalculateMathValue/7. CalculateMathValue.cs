//* Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
//Real numbers, e.g. 5, 18.33, 3.14159, 12.6
//Arithmetic operators: +, -, *, / (standard priorities)
//Mathematical functions: ln(x), sqrt(x), pow(x,y)
//Brackets (for changing the default priorities)
//	Examples:
//	(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
//	pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
//	Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".
// With the help of Nikolay

using System;
using System.Text;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;


namespace ExpressionEvaluation
{
    public class IncorrectExpressionException : Exception
    {
 
    }

    public class ExpressionEvaluator
    {
        private const string codeFormat = @"
        using System;
        namespace ExpressionEvaluation
        {
            public class EvaluatorHelper
            {
                public double Evaluate()
                {
                    return {0};
                }
            }
        }";

        private CSharpCodeProvider cSharpCodeProvider;
        private CompilerParameters cp;

        public ExpressionEvaluator()
        {
            cSharpCodeProvider = new CSharpCodeProvider();
            cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("system.dll");
            cp.GenerateInMemory = true;
        }

        private string PrepareExpression(string expression)
        {
            StringBuilder expressionBuilder = new StringBuilder(expression);
            expressionBuilder.Replace("sqrt", "Math.Sqrt");
            expressionBuilder.Replace("ln", "Math.Log");
            expressionBuilder.Replace("pow", "Math.Pow");
            //return string.Format(codeFormat, expressionBuilder);
            return codeFormat.Replace("{0}", expressionBuilder.ToString());
        }

        public bool TryEvaluate(string expression, out double result)
        {
            try
            {
                result = this.Evaluate(expression);
                return true;
            }

            catch (IncorrectExpressionException)
            {
                result = 0;
                return false;
            }
        }

        public double Evaluate(string expression)
        {
            try
            {
                expression = this.PrepareExpression(expression);
                CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(cp, expression);
                Assembly assembly = compilerResults.CompiledAssembly;
                object instance = assembly.CreateInstance("ExpressionEvaluation.EvaluatorHelper");
                object invokeResult = instance.GetType().GetMethod("Evaluate").Invoke(instance, null);
                double result = 0;
                double.TryParse(invokeResult.ToString(), out result);
                
                return result;
            }

            catch
            {
                throw new IncorrectExpressionException();
            }
        }
    }

    class ExpressionEvaluatorDemo
    {
        static void Main()
        {
            string expression = Console.ReadLine();
            ExpressionEvaluator expressionEvaluator = new ExpressionEvaluator();
            double result = 0;
            
            if (expressionEvaluator.TryEvaluate(expression, out result)) Console.WriteLine("{0:F6}", result);
            else Console.WriteLine("Incorrect expression!");
        }
    }

}

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CalculateMathValue
{
    static int[] nums = new int[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char[] operators = new char[] { '*', '/', '+', '-', '(', ')', '.' };
    //static char[] brackets = new char[] { '(', ')' };
    static string[] functions = new string[] { "ln", "sqrt", "pow" };

    static string RPN(string inString)
    {
        int flag = 0;
        char[] rpnResult = new char[inString.Length];
        double num;
        char[] digits = new char[inString.Length];
        char[] ops = new char[inString.Length];

        for (int i = 0, j = 0, k = 0; i < inString.Length; i++)
        {
            if (nums.Contains(inString[i]))
            {
                digits[j++] = inString[i];
                ops[k++] = ' ';
            }
            else if (operators.Contains(inString[i]))
            {
                ops[k++] = inString[i];
                digits[j++] = ' ';
            }

            //Console.WriteLine(functions.Contains(inString.Substring(i,4)));
            
        }
        for (int i = 0, j = 0, k = 0; ((i < inString.Length) || (j < inString.Length)); i++)
        {
            if (i >= inString.Length) flag = 2;
            else if (digits[i] != ' ') rpnResult[k++] = digits[i];
            else if (digits[i] == ' ') flag++;
            
            if (flag == 2)
            {
                while (ops[j] == ' ')
                {
                    j++;
                    if (j == inString.Length) break;
                }
                
                if (j == inString.Length) break;
                else if (ops[j] != ' ') rpnResult[k++] = ops[j++];
                flag = 1;
            }
        }


        return rpnResult.ToString();   
    }
    
    static void Main()
    {
        string equation = string.Empty, rpnResult = string.Empty;
        double equationResult = 0;

        equation = Console.ReadLine();

        rpnResult = RPN(equation);

        Console.WriteLine(equationResult);
    }
}
*/