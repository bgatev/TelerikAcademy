using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FakeTextMarkupLanguage
{
    const string RevTagOpen = "<rev>";
    const string UpperTagOpen = "<upper>";
    const string LowerTagOpen = "<lower>";
    const string ToggleTagOpen = "<toggle>";
    const string DelTagOpen = "<del>";

    const string RevTagClose = "</rev>";
    const string UpperTagClose = "</upper>";
    const string LowerTagClose = "</lower>";
    const string ToggleTagClose = "</toggle>";
    const string DelTagClose = "</del>";
        
    static StringBuilder output = new StringBuilder();
    static List<int> revTagStarts = new List<int>();

    static void Reverse(int currentRevStart, int revEnd)
    {
        int start = currentRevStart, end = revEnd;

        while (start < end)
        {
            char temp = output[start];
            output[start] = output[end];
            output[end] = temp;

            end--;
            start++;
        }
    }

    static void ProcessTag(ref List<string> currentOpenTag, string tag, ref int openedDelTags)
    {
        if (tag == DelTagOpen) openedDelTags++;
        else if (tag == DelTagClose) openedDelTags--;
        else
        {
            if (openedDelTags == 0)
            {
                if (tag == RevTagOpen) revTagStarts.Add(output.Length);
                else if (tag == RevTagClose)
                {
                    int currentRevStart = revTagStarts[revTagStarts.Count - 1];
                    int revEnd = output.Length - 1;

                    Reverse(currentRevStart, revEnd);
                    revTagStarts.RemoveAt(revTagStarts.Count - 1);
                }
                else if (tag[1] == '/') currentOpenTag.RemoveAt(currentOpenTag.Count - 1);
                else currentOpenTag.Add(tag);
            }
        }
    }

    static string GetTag(string currentLine, int symbolIndex)
    {
        int tagStart = symbolIndex;
        int tagEnd = currentLine.IndexOf('>', tagStart + 1);

        string tag = currentLine.Substring(tagStart, tagEnd - tagStart + 1);

        return tag;
    }

    static char ApplyEffects(char symbolToAdd, string currentOpenTag)
    {
        if (char.IsLetter(symbolToAdd))
        {
            if (currentOpenTag == UpperTagOpen) symbolToAdd = char.ToUpper(symbolToAdd);
            else if (currentOpenTag == LowerTagOpen) symbolToAdd = char.ToLower(symbolToAdd);
            else if (currentOpenTag == ToggleTagOpen)
            {
                if (char.IsLower(symbolToAdd)) symbolToAdd = char.ToUpper(symbolToAdd);
                else symbolToAdd = char.ToLower(symbolToAdd);
            }
        }

        return symbolToAdd;
    }

    static void Main()
    {
        int openedDelTags = 0;
        List<string> currentOpenTag = new List<string>();

        int numberOfLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfLines; i++)
        {
            string currentLine = Console.ReadLine();
            int currentSymbolIndex = 0;

            while (currentSymbolIndex < currentLine.Length)
            {
                if (currentLine[currentSymbolIndex] == '<')
                {
                    string tag = GetTag(currentLine, currentSymbolIndex);

                    ProcessTag(ref currentOpenTag, tag, ref openedDelTags);
                    currentSymbolIndex += tag.Length - 1;
                }
                else if (openedDelTags == 0)
                {
                    char symbolToAdd = currentLine[currentSymbolIndex];

                    for (int j = currentOpenTag.Count - 1; j > -1; j--) symbolToAdd = ApplyEffects(symbolToAdd, currentOpenTag[j]);
                    output.Append(symbolToAdd);
                }
                
                currentSymbolIndex++;
            }
            output.Append('\n');
        }

        output.Replace("\n", Environment.NewLine); // fix for CRLF on different OS
        Console.WriteLine(output.ToString());
    }
}

