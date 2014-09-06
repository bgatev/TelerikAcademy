namespace WolfRaider.Application.Core.Contracts
{
    public interface IFolderGenerator
    {
        void CreateXMLFolder();

        void CreateJsonFolder();

        void CreateExcelFolder();

        void CreatePdfFolder();
    }
}