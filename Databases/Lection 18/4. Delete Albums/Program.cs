using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

    class Program
    {
        static void Main()
        {
            var catalogXml = new XmlDocument();

            catalogXml.Load("../../../catalog.xml");

            RemoveAllAlbumsWithPriceBiggerThan(catalogXml, 20);

            catalogXml.Save("../../../new-catalog.xml");
        }

        private static void RemoveAllAlbumsWithPriceBiggerThan(XmlDocument xmlDocument, double price)
        {
            var albumsParent = xmlDocument.SelectSingleNode("catalog/albums");
            var albumsXml = albumsParent.SelectNodes("album");

            foreach (XmlNode album in albumsXml)
            {
                var priceXml = album.SelectSingleNode("price").InnerText.Replace("$", string.Empty);
                var priceAsDouble = double.Parse(priceXml);

                if (priceAsDouble > price) albumsParent.RemoveChild(album);
            }
        }
    }

