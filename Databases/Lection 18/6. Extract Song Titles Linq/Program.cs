using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        var catalogXml = XDocument.Load("../../../catalog.xml");

        var albumsXml = catalogXml.Element("catalog").Element("albums").Elements("album");

        var songTitles = from songName in albumsXml.Descendants("title")
                         select new
                         {
                            Title = songName.Value
                         };

        Console.WriteLine("All song titles:\n");
        foreach (var song in songTitles)
        {
            Console.WriteLine(song.Title);
        }
    }
}

