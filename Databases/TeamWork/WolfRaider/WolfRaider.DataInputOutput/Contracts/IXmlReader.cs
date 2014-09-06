namespace WolfRaider.DataInputOutput.Contracts
{
    using System.Xml.Linq;

    public interface IXmlReader
    {
        void ReadPlayerPositions(XDocument parsedXml);
    }
}
