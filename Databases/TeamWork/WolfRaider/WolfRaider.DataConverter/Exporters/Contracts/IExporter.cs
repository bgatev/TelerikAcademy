using WolfRaider.Common.Models.Contracts;

namespace WolfRaider.DataConverter.Exporters.Contracts
{
    public interface IExporter
    {
        void Export(IExportable exportable);
    }
}
