//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
//<html>
//  <head><title>News</title></head>
// <body><p><a href="http://academy.telerik.com">Telerik
//    Academy</a>aims to provide free real-world practical
//    training for young people who want to turn into
//    skillful .NET software engineers.</p></body>
//</html>

using System;
using System.Linq;

class HTML
{
    public HTML()
    {

    }

    public static string Title { get; set; }
    public static string Body { get; set; }
}

class ExtractHTML
{
    static string GetTitle(string html)
    {
        string title = string.Empty;
        int startIndex = 0, endIndex = 0;

        startIndex = html.IndexOf("<title>");
        endIndex = html.IndexOf("</title>");

        if ((startIndex == -1) || (endIndex == -1)) return "-1";

        title = html.Substring(startIndex + 7, endIndex - startIndex - 7);

        return title;
    }

    static string GetBody(string html)
    {
        string body = string.Empty;
        int startIndex = 0, endIndex = 0;

        startIndex = html.IndexOf("<body>");
        endIndex = html.IndexOf("</body>");

        if ((startIndex == -1) || (endIndex == -1)) return "-1";
        
        body = html.Substring(startIndex + 6, endIndex - startIndex - 6);

        string[] bodyString = body.Split('<');

        body = string.Empty;
        for (int i = 0; i < bodyString.Length; i++)
        {
            endIndex = bodyString[i].IndexOf(">");
            body += bodyString[i].Substring(endIndex + 1); 
        }

        return body;
    }
    
    static void Main()
    {
        string inputHTML = string.Empty;

        inputHTML = "<html>\n <head><title>News</title></head>\n <body><p><a href=" + @"""http://academy.telerik.com""" + ">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body>\n</html>";

        HTML.Title = GetTitle(inputHTML);
        HTML.Body = GetBody(inputHTML);

        Console.WriteLine(inputHTML);
        Console.WriteLine("HTML Title is: {0}", HTML.Title);
        Console.WriteLine("HTML Body is: {0}", HTML.Body);
    }
}

