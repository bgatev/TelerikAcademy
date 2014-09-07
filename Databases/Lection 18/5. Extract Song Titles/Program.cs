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
        XmlReader reader = XmlReader.Create("../../../catalog.xml");

        Console.WriteLine("All song titles:\n");

        using (reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "title") Console.WriteLine(reader.ReadElementContentAsString());
            }
        }
    }
}

