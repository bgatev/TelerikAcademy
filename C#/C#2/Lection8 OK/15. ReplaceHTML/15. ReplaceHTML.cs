//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
//Sample HTML fragment:
//<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
//<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] 
//to discuss the courses.</p>

using System;
using System.Linq;

class ReplaceHTML
{
    static string ReplaceString(string line, string source, string dest)
    {
        return line.Replace(source, dest);
    }

    static void Main()
    {
        const string startTagToReplace = @"<a href=""";
        const string startTagReplaceWith = "[URL=";
        const string endTagToReplace = @""">";
        const string endTagReplaceWith = "]";
        const string secondTagToReplace = "</a>";
        const string secondTagReplaceWith = "[/URL]";

        string inputHTML = string.Empty, result = string.Empty;

        inputHTML = Console.ReadLine();

        result = ReplaceString(inputHTML, secondTagToReplace, secondTagReplaceWith);
        result = ReplaceString(result, startTagToReplace, startTagReplaceWith);
        result = ReplaceString(result, endTagToReplace, endTagReplaceWith);

        Console.WriteLine(result);
    }
}

