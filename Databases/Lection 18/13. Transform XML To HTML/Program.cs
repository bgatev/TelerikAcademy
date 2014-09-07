using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;


class Program
{
    static void Main()
    {
        var xslt = new XslCompiledTransform();

        xslt.Load("../../catalog.xsl");
        xslt.Transform("../../../catalog.xml", "../../catalog.html");
    }
}

