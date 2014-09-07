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
        var catalogXml = new XmlDocument();
        catalogXml.Load("../../../catalog.xml");

        var albumsXml = catalogXml.SelectNodes("/catalog/albums/album");

        var allArtists = new HashSet<string>();
        var allAuthors = new Dictionary<string, int>();

        foreach (XmlNode album in albumsXml)
        {
            foreach (XmlNode artist in album.SelectNodes("artists/artist"))
            {
                allArtists.Add(artist.InnerText);
            }

            var authorName = album.SelectSingleNode("author").InnerText;

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

