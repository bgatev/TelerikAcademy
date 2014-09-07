namespace CreateAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    public class ExtractAlbumsFromXml
    {
        internal static void Main()
        {
            var authorsByName = new Dictionary<string, Author>();

            ReadXmlDocument(authorsByName);
            CreateXmlDocument(authorsByName);
            PrintAuthorInformation(authorsByName);
        }

        private static void ReadXmlDocument(IDictionary<string, Author> authorsByName)
        {
            using (XmlReader reader = XmlReader.Create("../../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.Name == "name")
                    {
                        var album = CreateAlbum(reader);

                        ReadAuthorName(reader, authorsByName, album);
                        ReadAuthors(reader, album);
                    }
                }
            }
        }
        private static void CreateXmlDocument(IDictionary<string, Author> bandsByName)
        {
            string fileName = "../../album.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                foreach (var band in bandsByName)
                {
                    foreach (var album in band.Value.Albums)
                    {
                        WriteBook(writer, album.Name, string.Join(", ", album.Authors));
                    }
                }
                writer.WriteEndDocument();
            }
            Console.WriteLine("Document {0} created.\n", fileName);
        }
        private static Album CreateAlbum(XmlReader reader)
        {
            var albumName = reader.ReadElementContentAsString();
            var album = new Album()
                                    {
                                        Name = albumName
                                    };
            
            return album;
        }
        private static void ReadAuthorName(XmlReader reader, IDictionary<string, Author> authorByName, Album album)
        {
            reader.ReadToFollowing("author");
            var authorName = reader.ReadElementContentAsString().Trim();

            if (!authorByName.ContainsKey(authorName))
            {
                authorByName[authorName] = new Author()
                                        {
                                            Name = authorName
                                        };
            }

            authorByName[authorName].Albums.Add(album);
        }
        private static void ReadAuthors(XmlReader reader, Album album)
        {
            reader.ReadToFollowing("artists");

            if (reader.ReadToDescendant("artist"))
            {
                do
                {
                    var artistName = reader.ReadElementContentAsString();
                    album.Authors.Add(artistName);
                }

                while (reader.ReadToNextSibling("artist"));
            }
        }
        private static void WriteBook(XmlWriter writer, string title, string authors)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("title", title);
            writer.WriteElementString("authors", authors);
            writer.WriteEndElement();
        }
        private static void PrintAuthorInformation(IDictionary<string, Author> authorsByName)
        {
            foreach (var author in authorsByName)
            {
                Console.WriteLine("Band: {0}", author.Key);
                Console.WriteLine(" Albums:");

                foreach (var album in author.Value.Albums)
                {
                    Console.WriteLine(" - {0} | Authors: {1}", album.Name, string.Join(", ", album.Authors));
                }

                Console.WriteLine();
            }
        }
    }
}