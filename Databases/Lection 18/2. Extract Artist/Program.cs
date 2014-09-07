using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        var catalogXml = XElement.Load("../../../catalog.xml");
        var albumsXml = catalogXml.Element("albums").Elements("album");

        var allArtists = new HashSet<string>();
        var allAuthors = new Dictionary<string, int>();

        foreach (var album in albumsXml)
        {
            foreach (var artist in album.Element("artists").Elements("artist"))
            {
                allArtists.Add(artist.Value);
            }

            var authorName = album.Element("author").Value;

            if (!allAuthors.ContainsKey(authorName)) allAuthors[authorName] = 0;
            allAuthors[authorName]++;
        }

        Console.WriteLine("All artists: {0}\n", string.Join(", ", allArtists));

        foreach (var author in allAuthors)
        {
            Console.WriteLine("{0}: {1} song(s)", author.Key, author.Value);
        }
    }
}

