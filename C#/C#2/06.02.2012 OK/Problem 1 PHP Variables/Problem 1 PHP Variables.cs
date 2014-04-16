using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Problem1PHPVariables
{
    static bool isValidChar(char c)
    {
        if (char.IsLetterOrDigit(c) || c == '_') return true;
        else return false;
    }

    static HashSet<string> ExtractWordsByIvailo(string inputCode)
    {
        HashSet<string> allVariables = new HashSet<string>();

        bool inOneLineComment = false, inMultiLineComment = false;
        bool inSingleQuoteString = false, inDoubleQuoteString = false;
        bool inVariable = false;

        StringBuilder currentVariable = new StringBuilder();

        for (int i = 0; i < inputCode.Length; i++)
        {
            char currentSymbol = inputCode[i];

            if (inOneLineComment)
            {
                if (currentSymbol == '\n') inOneLineComment = false;
                continue;
            }

            if (inMultiLineComment)
            {
                if ((currentSymbol == '*') && ((i + 1) < inputCode.Length) && (inputCode[i + 1] == '/'))
                {
                    inMultiLineComment = false;
                    i++;
                }
                continue;
            }

            if (inVariable)
            {
                if (isValidChar(currentSymbol))
                {
                    currentVariable.Append(currentSymbol);
                    continue;
                }
                else
                {
                    if (currentVariable.Length > 0) allVariables.Add(currentVariable.ToString());
                    currentVariable.Clear();
                    inVariable = false;
                }
            }

            if (inSingleQuoteString)
            {
                if (currentSymbol == '\'')
                {
                    inSingleQuoteString = false;
                    continue;
                }
            }

            if (inDoubleQuoteString)
            {
                if (currentSymbol == '"')
                {
                    inDoubleQuoteString = false;
                    continue;
                }
            }

            if ((!inSingleQuoteString) && (!inDoubleQuoteString))
            {
                if (currentSymbol == '#')
                {
                    inOneLineComment = true;
                    continue;
                }

                if ((currentSymbol == '/') && ((i + 1) < inputCode.Length) && (inputCode[i + 1] == '/'))
                {
                    inOneLineComment = true;
                    i++;
                    continue;
                }

                if ((currentSymbol == '/') && ((i + 1) < inputCode.Length) && (inputCode[i + 1] == '*'))
                {
                    inMultiLineComment = true;
                    i++;
                    continue;
                }
            }
            else
            {
                if (currentSymbol == '\\')
                {
                    i++;
                    continue;
                }
            }

            if (currentSymbol == '\'')
            {
                inSingleQuoteString = true;
                continue;
            }
            if (currentSymbol == '\"')
            {
                inDoubleQuoteString = true;
                continue;
            }
            if (currentSymbol == '$')
            {
                inVariable = true;
                continue;
            }
        }

        return allVariables;
    }
  
    static void Main()
    {
        string currentLine = Console.ReadLine();

        StringBuilder phpCode = new StringBuilder();

        while (currentLine != "?>")
        {
            phpCode.AppendLine(currentLine);
            currentLine = Console.ReadLine().Trim();
        }

        string inputCode = phpCode.ToString();

        var result = ExtractWordsByIvailo(inputCode);

        Console.WriteLine(result.Count);
        foreach (var variable in result)
        {
            Console.WriteLine(variable);
        }

    }
}