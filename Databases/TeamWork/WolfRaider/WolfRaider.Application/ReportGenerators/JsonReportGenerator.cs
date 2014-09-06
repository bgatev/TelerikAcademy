namespace WolfRaider.Application.ReportGenerators
{
    using WolfRaider.Common.Config;
    using WolfRaider.Common.Models;
    using WolfRaider.DataConverter.Exporters;
    using WolfRaider.DataConverter.Exporters.Contracts;
    using WolfRaider.DataInputOutput;

    public class JsonReportGenerator : GeneralReportGenerator
    {
        private const string PathFormat = "{0}\\{1}";
        private const string FileNameFormat = "{0}.json";

        private readonly TextFileWriter textFileWriter;
        private readonly IExporter<string> exporter;
       
        public JsonReportGenerator()
            : this(new TextFileWriter(), new JsonExporter())
        {
        }

        public JsonReportGenerator(TextFileWriter textFileWriter, IExporter<string> exporter)
        {
            this.textFileWriter = textFileWriter;
            this.exporter = exporter;
        }

        public void CreateEmployeeReport(Employee employee)
        {
            var json = this.exporter.ConvertEmployee(employee);
            string filename = this.GetFileName(employee);
            var fullFileName = string.Format(FileNameFormat, filename);
            string path = string.Format(PathFormat, Folders.JsonFolder, fullFileName);

            this.textFileWriter.Write(path, json);
        }
    }
}
