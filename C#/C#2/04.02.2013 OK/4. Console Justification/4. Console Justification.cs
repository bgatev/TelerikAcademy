using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ConsoleJustification
{
    static string[] SplitString(string inString)
    {
        string[] temp = inString.Split(' ');
        int tempLength = 0;
        for (int i = 0; i < temp.Length; i++) if (temp[i] != "") tempLength++;

        string[] result = new string[tempLength];
        for (int i = 0, j = 0; i < temp.Length; i++) if (temp[i] != "") result[j++] = temp[i];

        return result;
    }

    static void PrintLine(string[][] inLines, int lineLength)
    {
        string singleLine = string.Empty;
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < inLines.GetLength(0); i++)
        {
            for (int j = 0; j < inLines[i].Length; j++)
            {
                sb.Append(inLines[i][j]);
                if (j != inLines[i].Length - 1)sb.Append(' ');

                if ((sb.Length == lineLength + 1) && (sb[lineLength] == ' '))
                {
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }
                else if (sb.Length > lineLength)
                {
                    sb.Remove(sb.Length - inLines[i][j].Length - 1, inLines[i][j].Length + 1);

                    string tempStr = string.Empty;
                    tempStr = sb.ToString().TrimEnd(' ');
                    sb.Clear();
                    sb.Append(tempStr);
    
                    int index = 0, flag = 0;
                    do
                    {
                        if (sb[index++] == ' ')
                        {
                            sb.Insert(index, ' ');
                            flag = 1;
                            index++;
                        }
                        if ((index == sb.Length) && (flag == 0)) break; //one word per line check
                        if (index == sb.Length) index = 0; //start over for more spaces
                        if (sb.Length == lineLength) break;
                    } 
                    while (true);

                    tempStr = sb.ToString().TrimEnd(' ');
                    sb.Clear();
                    sb.Append(tempStr);

                    Console.WriteLine(sb.ToString());
			        sb.Clear();
			        sb.Append(inLines[i][j]);
                    if (j != inLines[i].Length - 1) sb.Append(' ');
                }
                
                if ((i == inLines.GetLength(0) - 1) && (j == inLines[i].Length - 1)) Console.WriteLine(sb.ToString());
                
            }
            sb.Append(' ');
        }

    }

    static void Main()
    {
        int N, W;
        
        N = int.Parse(Console.ReadLine());
        W = int.Parse(Console.ReadLine());

        string[] lineStr = new string[N];

        string[][] lines = new string[N][];
        for (int i = 0; i < N; i++) lineStr[i] = Console.ReadLine();

        for (int i = 0; i < N; i++)
        {
            string[] temp = SplitString(lineStr[i]);
            lines[i] = new string[temp.Length];

            for (int j = 0; j < temp.Length; j++) lines[i][j] = temp[j];
        }

        PrintLine(lines,W);
        //Console.WriteLine();
    }
}


/*
public class ConsoleJustificationByStanislav
{
    public static void Main()
    {
        Queue<string> words = new Queue<string>();
        Queue<string> outputLineWords = new Queue<string>();

        int linesCount = int.Parse(Console.ReadLine());
        int maximumAllowedLineLength = int.Parse(Console.ReadLine());

        string inputLine = Console.ReadLine();
        int inputLineNumber = 1;

        ExtractWordsFromLine(inputLine, words);

        int currentWordsLength = 0;
        int gapSize = 0;
        int additionalWhiteSpacesNeeded = 0;
        bool singleWordOnLine = false;
        bool shouldPrint = false;

        StringBuilder output = new StringBuilder();
        string currentOutputWord = String.Empty;
        string currentWord = String.Empty;

        while (words.Count > 0 || outputLineWords.Count > 0)
        {
            if (words.Count > 0)
            {
                currentWord = words.Peek();
                if ((currentWordsLength + outputLineWords.Count + currentWord.Length) <= maximumAllowedLineLength)
                {
                    outputLineWords.Enqueue(words.Dequeue());
                    currentWordsLength += currentWord.Length;
                    if ((currentWordsLength + outputLineWords.Count - 1) == maximumAllowedLineLength) shouldPrint = true;
                    else shouldPrint = false;
                }
                else
                {
                    shouldPrint = true;
                    int symbolsRemaining = maximumAllowedLineLength - currentWordsLength - outputLineWords.Count + 1;

                    if (outputLineWords.Count > 1)
                    {
                        singleWordOnLine = false;
                        gapSize = symbolsRemaining / (outputLineWords.Count - 1);
                        additionalWhiteSpacesNeeded = symbolsRemaining % (outputLineWords.Count - 1);
                    }
                    else singleWordOnLine = true;
                }
            }
            else
            {
                shouldPrint = true;
                int symbolsRemaining = maximumAllowedLineLength - currentWordsLength - outputLineWords.Count + 1;

                if (outputLineWords.Count > 1)
                {
                    singleWordOnLine = false;
                    gapSize = symbolsRemaining / (outputLineWords.Count - 1);
                    additionalWhiteSpacesNeeded = symbolsRemaining % (outputLineWords.Count - 1);
                }
                else singleWordOnLine = true;
            }

            if (shouldPrint)
            {
                if (singleWordOnLine)
                {
                    currentOutputWord = outputLineWords.Dequeue();
                    output.Append(currentOutputWord);
                    singleWordOnLine = false;
                }
                else
                {
                    while (outputLineWords.Count > 1)
                    {
                        currentOutputWord = outputLineWords.Dequeue();
                        output.Append(currentOutputWord);
                        output.Append(new String(' ', gapSize + 1));
                        if (additionalWhiteSpacesNeeded > 0)
                        {
                            output.Append(' ');
                            additionalWhiteSpacesNeeded--;
                        }
                    }
                    currentOutputWord = outputLineWords.Dequeue();
                    output.Append(currentOutputWord);
                }
                output.AppendLine();
                currentWordsLength = 0;
                gapSize = 0;
                additionalWhiteSpacesNeeded = 0;
            }
            if (words.Count == 0 && inputLineNumber < linesCount)
            {
                inputLine = Console.ReadLine();
                inputLineNumber++;
                ExtractWordsFromLine(inputLine, words);
            }
        }
        Console.Write(output.ToString());
    }

    private static void ExtractWordsFromLine(string inputLine, Queue<string> words)
    {
        string[] wordsOnLine = Regex.Split(inputLine, @"\s+");
        for (int index = 0; index < wordsOnLine.Length; index++)
        {
            string word = wordsOnLine[index];
            
            if (word != String.Empty) words.Enqueue(word);
        }
    }
}*/
