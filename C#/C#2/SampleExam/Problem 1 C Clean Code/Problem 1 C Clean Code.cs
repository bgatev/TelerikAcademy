using System;
using System.IO;
using System.Linq;
using System.Text;

class Problem1CCleanCode
{
    static void Main()
    {
        StringBuilder result = new StringBuilder();
        
        int numberOfLines = int.Parse(Console.ReadLine());

        bool inMultiLineComment = false;
        bool inString = false;
        bool inMultiLineString = false;
        bool inSingleQuotedString = false;

        for (int i = 1; i <= numberOfLines; i++)
        {
            string line = Console.ReadLine();

            for (int j = 0; j < line.Length; j++)
            {
                if (inMultiLineString)
                {
                    if ((line[j] == '\"') && ((j + 1) < line.Length) && (line[j + 1] == '\"'))
                    {
                        result.Append("\"\"");
                        j++;
                        continue;
                    }
                }
                if (inString)
                {
                    if ((line[j] == '\\') && ((j + 1) < line.Length) && (line[j + 1] == '\"'))
                    {
                        result.Append("\\\"");
                        j++;
                        continue;
                    }
                    if ((line[j] == '\\') && ((j + 1) < line.Length) && (line[j + 1] == '\''))
                    {
                        result.Append("\\\'");
                        j++;
                        continue;
                    }
                    if ((line[j] == '\"') && (!inSingleQuotedString))
                    {
                        inString = false;
                        inMultiLineString = false;
                        result.Append('\"');
                        continue;
                    }
                    if ((line[j] == '\'') && (inSingleQuotedString))
                    {
                        inString = false;
                        inSingleQuotedString = false;
                        result.Append('\'');
                        continue;
                    }
                    result.Append(line[j]);
                    continue;
                }

                // Multiline comments
                if (!inMultiLineComment && ((j + 1) < line.Length) && (line[j] == '/') && (line[j + 1] == '*'))
                {
                    inMultiLineComment = true;
                    j++;
                    continue;
                }
                if (inMultiLineComment && ((j + 1) < line.Length) && (line[j] == '*') && (line[j + 1] == '/'))
                {
                    inMultiLineComment = false;
                    j++;
                    continue;
                }
                if (inMultiLineComment) continue;
                
                // One line comment
                if ((line[j] == '/') && ((j + 1) < line.Length) && (line[j + 1] == '/'))
                {
                    if (((j + 2) >= line.Length) || (line[j + 2] != '/')) break;
                    else
                    {
                        // Inline documentation (///)
                        result.Append("///");
                        j += 2;
                        continue;
                    }
                }

                if ((line[j] == '@') && ((j + 1) < line.Length) && (line[j + 1] == '\"'))
                {
                    inString = true;
                    inMultiLineString = true;
                    j++;
                    result.Append("@\"");
                    continue;
                }

                if (line[j] == '\"') inString = true;
                
                if (line[j] == '\'')
                {
                    inString = true;
                    inSingleQuotedString = true;
                }

                result.Append(line[j]);
            }

            if (!inMultiLineComment) result.AppendLine();
        }

        StringReader sr = new StringReader(result.ToString());
        string lineToPrint = null;
        while ((lineToPrint = sr.ReadLine()) != null) if (!string.IsNullOrWhiteSpace(lineToPrint)) Console.WriteLine(lineToPrint);
    }
}

