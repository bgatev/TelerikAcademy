//Write a program for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> 
//should be recognized as emails.

using System;
using System.Linq;

class EMail
{
    public EMail()
    {

    }

    public static string Identifier { get; set; }
    public static string Host { get; set; }
    public static string Domain { get; set; }
}

class ExtractEMail
{
    static string GetIdentifier(string inEMail)
    {
        string identifier = string.Empty;
        int startIndex = 0;

        startIndex = inEMail.IndexOf("@");
        if (startIndex == -1) return "-1";

        identifier = inEMail.Substring(0, startIndex);

        return identifier;
    }

    static string GetHost(string inEMail)
    {
        string host = string.Empty;
        int startIndex = 0, endIndex = 0;
        
        startIndex = inEMail.IndexOf("@");

        if (inEMail[inEMail.Length - 1] == '.') inEMail = inEMail.Substring(0, inEMail.Length - 1);
        endIndex = inEMail.LastIndexOf('.');
        if ((startIndex == -1) || (endIndex == -1)) return "-1";
        
        host = inEMail.Substring(startIndex + 1, endIndex - startIndex - 1);

        return host;
    }

    static string GetDomain(string inEMail)
    {
        string domain = string.Empty;
        int startIndex = 0;

        if (!char.IsLetterOrDigit(inEMail, inEMail.Length - 1)) inEMail = inEMail.Substring(0, inEMail.Length - 1);

        startIndex = inEMail.LastIndexOf(".");
        if (startIndex == -1) return "-1";

        domain = inEMail.Substring(startIndex);

        return domain;
    }

    static void Main()
    {
        string inputText = string.Empty;

        inputText = "I am a beautiful boy and my address is aman@ivan.telerik-students.org. My girlfriend address is hello@abv.bg, but is not full.";

        string[] inputEmail = inputText.Split(' ');

        for (int i = 0; i < inputEmail.Length; i++)
        {
            EMail.Identifier = GetIdentifier(inputEmail[i]);
            if (EMail.Identifier == "-1") continue;
            
            EMail.Host = GetHost(inputEmail[i]);
            if (EMail.Host == "-1") continue;
            
            EMail.Domain = GetDomain(inputEmail[i]);
            if (EMail.Domain == "-1") continue;

            Console.WriteLine("Identifier = {0}", EMail.Identifier);
            Console.WriteLine("   Host    = {0}", EMail.Host);
            Console.WriteLine("  Domain   = {0}", EMail.Domain);         
        }
    }
}


