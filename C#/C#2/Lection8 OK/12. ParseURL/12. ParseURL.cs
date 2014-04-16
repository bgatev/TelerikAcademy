//Write a program that parses an URL address given in the format:
//[protocol]://[server]/[resource]
//and extracts from it the [protocol], [server] and [resource] elements. For example from the URL http://www.devbg.org/forum/index.php the 
//following information should be extracted:
//		[protocol] = "http"
//		[server] = "www.devbg.org"
//		[resource] = "/forum/index.php"

using System;
using System.Linq;

class URL
{
    public URL()
    {

    }

    public static string Protocol { get; set; }
    public static string Server { get; set; }
    public static string Resource { get; set; }
}

class ParseURL1
{
    static string GetProtocol(string inURL)
    {
        string protocol = string.Empty;
        int startIndex = 0;

        startIndex = inURL.IndexOf("://");
        protocol = inURL.Substring(0, startIndex);
        
        return protocol;
    }

    static string GetServer(string inURL)
    {
        string server = string.Empty;
        int startIndex = 0;

        startIndex = inURL.IndexOf("://");
        inURL = inURL.Substring(startIndex + 3);

        startIndex = inURL.IndexOf('/');
        server = inURL.Substring(0, startIndex);

        return server;
    }

    static string GetResource(string inURL)
    {
        string resource = string.Empty;
        int startIndex = 0;

        startIndex = inURL.IndexOf("://");
        inURL = inURL.Substring(startIndex + 3);

        startIndex = inURL.IndexOf('/');
        resource = inURL.Substring(startIndex);

        return resource;
    }

    static void Main()
    {
        string inputUrl = string.Empty;

        inputUrl = "http://www.devbg.org/forum/index.php";
        URL.Protocol = GetProtocol(inputUrl);
        URL.Server = GetServer(inputUrl);
        URL.Resource = GetResource(inputUrl);

        Console.WriteLine("[protocol] = '{0}'", URL.Protocol);
        Console.WriteLine("[ server ] = '{0}'", URL.Server);
        Console.WriteLine("[resource] = '{0}'", URL.Resource);
    }
}

