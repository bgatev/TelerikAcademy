using System;
using Newtonsoft.Json;
using WolfRaider.Common.Config;
using WolfRaider.Common.Models.Contracts;
using WolfRaider.DataConverter.Exporters.Contracts;
using WolfRaider.DataWriter;

namespace WolfRaider.DataConverter.Exporters
{
    /// <summary>
    /// A class for exporting some data to to a json file.
    /// </summary>
    public class JsonExporter : Exporter
    {
        private const string PathFormat = "{0}\\{1}";
        private const string FileNameFormat = "{0}.json";

        public JsonExporter(IDataWriter dataWriter)
            : base(dataWriter)
        {
        }

        private void WriteFile(string filename, string text)
        {
            var path = string.Format(PathFormat, Folders.JsonFolder, filename);
            dataWriter.Write(path, text);
        }

        public override void Export(IExportable serializable)
        {
            var json = this.GetJson(serializable);
            var filename = this.GetFileName(serializable);
            this.WriteFile(filename, json);
        }

        private string GetFileName(IExportable exportable)
        {
            var filename = string.Format(FileNameFormat, exportable.GetSerialNumber());
            return filename;
        }

        private string GetJson(Object data)
        {
            string json = JsonConvert.SerializeObject(data);
            return json;
        }
    }
}
