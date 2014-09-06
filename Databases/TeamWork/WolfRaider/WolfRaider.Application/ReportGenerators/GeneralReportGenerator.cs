namespace WolfRaider.Application.ReportGenerators
{
    using WolfRaider.Common.Models.Contracts;

    public class GeneralReportGenerator
    {
        protected string GetFileName(IExportable exportable)
        {
            var filename = exportable.GetSerialNumber();
            return filename;
        }
    }
}
