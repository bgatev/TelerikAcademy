namespace WolfRaider.Application.ReportGenerators
{
    using System.Xml.Linq;
    using WolfRaider.Common.Config;
    using WolfRaider.Common.Models;
    using WolfRaider.DataConverter.Exporters;
    using WolfRaider.DataInputOutput;
    using WolfRaider.DataInputOutput.Contracts;

    public class XmlReportGenerator
    {
        private const string FileNameFormat = "{0}.xml";
        private const string PathFormat = "{0}\\{1}";

        private XmlExporter xmlExporter;
        private IDataWriter dataWriter;

        public XmlReportGenerator()
        {
            this.xmlExporter = new XmlExporter();
            this.dataWriter = new TextFileWriter();
        }

        public void GenerateEmployeeReport(Employee employee)
        {
            string fileName = "EmployeeReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.XmlFolder, fullName);

            string employeeXML = this.xmlExporter.ConvertEmployee(employee);

            this.dataWriter.Write(path, employeeXML);
        }
    }
}
