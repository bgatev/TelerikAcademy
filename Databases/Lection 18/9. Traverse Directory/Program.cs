namespace TraverseDir
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    public class TraverseDirectory
    {
        private const string DirectoryToTraverse = @"D:\Genius";
        internal static void Main()
        {
            Console.Write("Loading...");
            BuildXmlDirectoryTree();
            Console.Write("\r");
        }

        private static void BuildXmlDirectoryTree()
        {
            var xmlTextWriter = new XmlTextWriter("../../directory.xml", Encoding.UTF8);
            var startupDirectory = new DirectoryInfo(DirectoryToTraverse);

            using (xmlTextWriter)
            {
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.IndentChar = '\t';
                xmlTextWriter.Indentation = 1;
                xmlTextWriter.WriteStartElement("directories");
                BuildXmlForDirectoryRecursively(xmlTextWriter, startupDirectory);
                xmlTextWriter.WriteEndDocument();
            }
        }

        private static void BuildXmlForDirectoryRecursively(XmlTextWriter writer, DirectoryInfo dirInfo)
        {
            if (!dirInfo.GetFiles().Any() && !dirInfo.GetDirectories().Any()) return;

            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", dirInfo.Name);

            foreach (var file in dirInfo.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }

            foreach (var dir in dirInfo.GetDirectories())
            {
                BuildXmlForDirectoryRecursively(writer, dir);
            }

            writer.WriteEndElement();
        }
    }
}