using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Problem1BasicLanguage
{
    static void RunCommands(List<string> allCommands, StringBuilder result)
    {
        result.Clear();

        for (int i = 0; i < allCommands.Count; i++)
        {
            int allLoops = 1;
            string[] subCommands = allCommands[i].Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var command in subCommands)
            {
                string currentCommand = command.TrimStart();

                if (currentCommand.StartsWith("EXIT")) return;
                else if (currentCommand.StartsWith("PRINT"))
                {
                    int paramsStart = currentCommand.IndexOf("(") + 1;
                    string content = currentCommand.Substring(paramsStart);

                    for (int j = 0; j < allLoops; j++) result.Append(content);
                }
                else if (currentCommand.StartsWith("FOR"))
                {
                    int paramsStart = currentCommand.IndexOf("(") + 1;
                    string allParams = currentCommand.Substring(paramsStart);

                    if (allParams.Contains(","))
                    {
                        string[] loopParams = allParams.Split(',');
                        int a = int.Parse(loopParams[0]), b = int.Parse(loopParams[1]);

                        allLoops *= (b - a + 1);
                    }
                    else
                    {
                        int value = int.Parse(allParams);
                        
                        allLoops *= value;
                    }
                }
            }
        }
    }

    static void Main()
    {
        List<string> allCommands = new List<string>();
        StringBuilder result = new StringBuilder();

        while (true)
        {
            string line = Console.ReadLine();

            result.AppendLine(line);
            if (line.Contains("EXIT")) break;
        }

        string allInput = result.ToString();
        result.Clear();

        foreach (var symbol in allInput)
        {
            result.Append(symbol);
            if (symbol == ';')
            {
                allCommands.Add(result.ToString());
                result.Clear();
            }
        }

        RunCommands(allCommands, result);

        Console.WriteLine(result.ToString());
    }

}

