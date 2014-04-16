//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
//The tags cannot be nested. Example:
//We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
//The expected result:
//We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

using System;
using System.Linq;

class ChangeTags
{
    static string ExtractXML(string line, string startTag, string endTag)
    {
        string fixedLine = string.Empty, textForUp = string.Empty;
        int startIndex = 0, endIndex = 0;

        do
        {
            startIndex = line.IndexOf(startTag);

            if (startIndex == -1)
            {
                fixedLine += line;
                break;
            }

            fixedLine += line.Substring(0, startIndex);
            line = line.Substring(startIndex + startTag.Length);
            endIndex = line.IndexOf(endTag);

            textForUp = (line.Substring(0, endIndex)).ToUpper();
            fixedLine += textForUp;
            line = line.Substring(endIndex + endTag.Length);
        }
        while (startIndex != -1);

        return fixedLine;
    }

    static void Main()
    {
        const string StartTag = "<upcase>";
        const string EndTag = "</upcase>";

        string xmlText=string.Empty, result = string.Empty;

        xmlText = Console.ReadLine();
        result = ExtractXML(xmlText, StartTag, EndTag);

        Console.WriteLine(result);
    }
}

