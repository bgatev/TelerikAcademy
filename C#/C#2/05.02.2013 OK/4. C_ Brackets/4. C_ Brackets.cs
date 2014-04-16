using System;
using System.Linq;
using System.Text;

class BracketsbyPenka
{
    static bool shouldPrintNewLine = false;
    static bool isFirstSymbol = true;
    static int tabsCount = 0;

    static StringBuilder sb = new StringBuilder();

    static void HandleLine(string line, string tabs)
    {  
        for (int i = 0; i < line.Length; i++)
        {
            char currentCharacter = line[i];

            if (shouldPrintNewLine && char.IsWhiteSpace(currentCharacter)) continue;

            if (shouldPrintNewLine)
            {
                sb.AppendLine();
                shouldPrintNewLine = false;
                isFirstSymbol = true;
            }

            if (currentCharacter == '{')
            {
                if ((!shouldPrintNewLine) && (!isFirstSymbol))
                {
                    if ((sb.Length > 0) && (char.IsWhiteSpace(sb[sb.Length - 1]))) sb.Remove(sb.Length - 1, 1);
                    sb.AppendLine();
                }

                for (int j = 0; j < tabsCount; j++) sb.Append(tabs);
                sb.Append(currentCharacter);
                tabsCount++;
                shouldPrintNewLine = true;
            }
            else if (currentCharacter == '}')
            {
                tabsCount--;
                if ((!shouldPrintNewLine) && (!isFirstSymbol))
                {
                    if ((sb.Length > 0) && (char.IsWhiteSpace(sb[sb.Length - 1]))) sb.Remove(sb.Length - 1, 1);
                    sb.AppendLine();
                }

                for (int j = 0; j < tabsCount; j++) sb.Append(tabs);
                sb.Append(currentCharacter);
                shouldPrintNewLine = true;
            }
            else
            {
                if (isFirstSymbol) for (int j = 0; j < tabsCount; j++) sb.Append(tabs);

                if ((!(isFirstSymbol && char.IsWhiteSpace(currentCharacter)))
                    && (!((i < line.Length - 1) && (char.IsWhiteSpace(line[i])) && (char.IsWhiteSpace(line[i + 1]))))) sb.Append(currentCharacter);

                isFirstSymbol = false;
            }
        }
        shouldPrintNewLine = true;
        isFirstSymbol = true;
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string tabs = Console.ReadLine();

        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine().Trim();
            HandleLine(line, tabs);
        }

        Console.WriteLine(sb.ToString());
    }
}