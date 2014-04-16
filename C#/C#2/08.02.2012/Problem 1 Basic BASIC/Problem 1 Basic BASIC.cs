using System;
using System.Linq;
using System.Text;

class Problem1BasicBASIC
{
    static int varV = 0, varW = 0, varX = 0, varY = 0, varZ = 0;

    static int FindNextCommandId(ref string[] lines, int currentLine, int maxCommandLineId)
    {
        for (int i = currentLine + 1; i <= maxCommandLineId; i++) if (!string.IsNullOrWhiteSpace(lines[i])) return i;

        return int.MaxValue;
    }

    static int GetValue(string expression)
    {
        switch (expression.Trim())
        {
            case "": return 0;
            case "V": return varV;
            case "W": return varW;
            case "X": return varX;
            case "Y": return varY;
            case "Z": return varZ;
            default: return int.Parse(expression);
        }
    }

    static void Main()
    {
        string[] lines = new string[10001];
        int maxCommandLineId = 0;
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < lines.Length; i++) lines[i] = string.Empty;

        while (true)
        {
            string currentLine = Console.ReadLine();

            if (currentLine == "RUN") break;
            else
            {
                string[] line = currentLine.Split(new char[] { ' ' }, 2);
                int lineNum = int.Parse(line[0]);

                lines[lineNum] = line[1].Trim();
                maxCommandLineId = lineNum;
            }
        }

        RunProgram(ref lines, maxCommandLineId, result);
        Console.Write(result.ToString());
    }
    
    static void RunProgram(ref string[] lines, int maxCommandLineId, StringBuilder result)
    {
        int currentCommandId = FindNextCommandId(ref lines,-1, maxCommandLineId);

        while (currentCommandId != int.MaxValue)
        {
            string command = lines[currentCommandId];

            if (command[0] == 'I')
            {
                string[] conditionAndCommand = command.Substring(2).Split(new string[] { "THEN" }, StringSplitOptions.None);
                string condition = conditionAndCommand[0].Replace(" ", "");
                if (condition.Contains("="))
                {
                    string[] values = condition.Split('=');
                    if (!(GetValue(values[0]) == GetValue(values[1])))
                    {
                        currentCommandId = FindNextCommandId(ref lines,currentCommandId, maxCommandLineId);
                        continue;
                    }
                }
                else if (condition.Contains(">"))
                {
                    string[] values = condition.Split('>');
                    if (!(GetValue(values[0]) > GetValue(values[1])))
                    {
                        currentCommandId = FindNextCommandId(ref lines,currentCommandId, maxCommandLineId);
                        continue;
                    }
                }
                else if (condition.Contains("<"))
                {
                    string[] values = condition.Split('<');
                    if (!(GetValue(values[0]) < GetValue(values[1])))
                    {
                        currentCommandId = FindNextCommandId(ref lines,currentCommandId, maxCommandLineId);
                        continue;
                    }
                }
                command = conditionAndCommand[1].Trim();
            }

            if (command[0] == 'S') break;
            else if (command[0] == 'C') result.Clear();
            else if (command[0] == 'P')
            {
                string variable = command.Substring(5).Trim();
                result.AppendLine(GetValue(variable).ToString());
            }
            else if (command[0] == 'G')
            {
                string lineIdAsString = command.Substring(4).Trim();
                currentCommandId = int.Parse(lineIdAsString);
                continue;
            }
            else if (command.Contains("="))
            {
                string[] variableAndExpression = command.Split('=');
                string variable = variableAndExpression[0].Trim();
                string expression = variableAndExpression[1].Trim();
                int value = 0;
                
                if (expression.Contains("+"))
                {
                    string[] expressionParts = expression.Split('+');
                    value = GetValue(expressionParts[0]) + GetValue(expressionParts[1]);
                }
                else if (expression.Contains("-"))
                {
                    string[] expressionParts = expression.Split('-');
                    value = GetValue(expressionParts[0]) - GetValue(expressionParts[1]);
                }
                else value = GetValue(expression);
                
                switch (variable)
                {
                    case "V": varV = value; break;
                    case "W": varW = value; break;
                    case "X": varX = value; break;
                    case "Y": varY = value; break;
                    case "Z": varZ = value; break;
                    default: break;
                }
            }

            currentCommandId = FindNextCommandId(ref lines,currentCommandId, maxCommandLineId);
        }
    }
}
