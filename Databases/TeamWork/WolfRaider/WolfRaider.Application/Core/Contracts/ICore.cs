namespace WolfRaider.Application.Core.Contracts
{
    public interface ICore
    {
        void GenerateApplicationFolders();

        void ImportDataFromMongoExcelToSqlServer();

        void GeneratePdfReports();

        void CreateXmlReports();

        void ImportXml();

        void CreateJsonReportsMySql();

        void CreateExcel2007Reports();
    }
}