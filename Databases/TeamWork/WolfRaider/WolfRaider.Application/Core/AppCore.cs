namespace WolfRaider.Application.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WolfRaider.Application.Core.Contracts;
    using WolfRaider.Application.ReportGenerators;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.AdoNET;
    using WolfRaider.DatabaseAccess.Commands;
    using WolfRaider.DatabaseAccess.Connections;
    using WolfRaider.DatabaseAccess.MongoDB;
    using WolfRaider.DatabaseAccess.Parameters;
    using WolfRaider.DatabaseAccess.SqlServer;
    using WolfRaider.DataConverter.Importers;
    using WolfRaider.DataInputOutput;

    public class AppCore : ICore
    {
        private const string ReportTitle = "Player's Games Statistics";
        private const string PdfPath = @"..\..\..\..\Documentation\PlayersGamesStatistics.pdf";

        private readonly IFolderGenerator folderGenerator;

        public AppCore()
            : this(new FolderGenerator())
        {
        }

        public AppCore(IFolderGenerator folderGenerator)
        {
            this.folderGenerator = folderGenerator;
        }

        public void GenerateApplicationFolders()
        {
            this.folderGenerator.CreateJsonFolder();
            this.folderGenerator.CreateExcelFolder();
            this.folderGenerator.CreatePdfFolder();
            this.folderGenerator.CreateXMLFolder();
        }

        public void ImportDataFromMongoExcelToSqlServer()
        {
            Console.Clear();
            Console.WriteLine("Exporting information from ZIP file...");

            Console.Write("Enter file path:");
            var filePath = Console.ReadLine();

            if (!filePath.EndsWith("\\"))
            {
                filePath += "\\";
            }

            Console.Write("Enter file name:");
            var fileName = Console.ReadLine();

            Console.Write("Extraction directory name:");
            var directoryName = Console.ReadLine();

            var zipExtractor = new ZipExtractor(filePath, fileName, directoryName);
            zipExtractor.GetAllReports();

            Console.Clear();
            Console.WriteLine("Data from ZIP imported");
        }

        public void GeneratePdfReports()
        {
            string[] headers = 
            {
                "Player",
                "Game Played On",
                "Home Team",
                "Guest Team",
                "Goals",
                "Yellow Cards",
                "Red Cards"
            };

            var pdfReportGeneraotor = new PdfReportGenerator<SquadHistory>();
            var dao = new SquadHistoryDaoSqlServer();

            using (dao)
            {
                var records = new List<string>();
                var squadHistories = dao.ListAll();

                foreach (var item in squadHistories)
                {
                    records.Add(item.Employee.FullName.ToString());
                    records.Add(item.Game.PlayedOn.Value.ToString("MM-dd-yyyy"));
                    records.Add(item.Game.HomeTeam.Name);
                    records.Add(item.Game.GuestTeam.Name);
                    records.Add(item.Goals.ToString());
                    records.Add(item.YellowCards.ToString());
                    records.Add(item.RedCards.ToString());
                }

                pdfReportGeneraotor.GenerateReport(headers, records, PdfPath, ReportTitle);
            }

            Console.WriteLine("PDF report created.");
        }

        public void CreateXmlReports()
        {
            var xmlReportGenerator = new XmlReportGenerator();
            var dao = new EmployeeDaoSqlServer();

            var squadHistories = dao.ListAll().OrderBy(e => e.FullName);

            foreach (var item in squadHistories)
            {
                xmlReportGenerator.GenerateEmployeeReport(item);
            }

            Console.WriteLine("XML report created.");
        }

        public void ImportXml()
        {
            XmlImporter xmlImporter = new XmlImporter();
            string positionsFilePath = @"..\..\..\..\Documentation\PlayerPositions.xml";
            IEnumerable<Position> parsedPositions = xmlImporter.ParsePositions(positionsFilePath);
            var positionsMongoDao = new PositionDaoMongoDB();
            var positionDaoSql = new PositionDaoSqlServer();

            foreach (var position in parsedPositions)
            {
                positionsMongoDao.Insert(position);
                positionDaoSql.Insert(position);
            }

            string employeesPath = @"..\..\..\..\Documentation\Employees.xml";
            IEnumerable<Employee> parsedEmployees = xmlImporter.ParseEmployees(employeesPath);
            var employeesMongoDao = new EmployeeDaoMongoDB();
            var employeesDaoSqlServer = new EmployeeDaoSqlServer();

            foreach (var employee in parsedEmployees)
            {
                employeesMongoDao.Insert(employee);
                employeesDaoSqlServer.Insert(employee);
            }

            Console.WriteLine("XML Data imported into SQL Server");
        }

        public void CreateJsonReportsMySql()
        {
            var sqlServerDao = new EmployeeDaoSqlServer();
            var jsonReportGenerator = new JsonReportGenerator();

            var mysqlEmployeeDao = new EmployeeDao(new MySqlDatabaseConnection(), new MySqlCommandStategy(), new MySqlParameterStrategy());

            using (sqlServerDao)
            {
                var list = sqlServerDao.Find(x => x.ManagerId.HasValue).OrderBy(x => x.ManagerId);

                foreach (var employee in list)
                {
                    jsonReportGenerator.CreateEmployeeReport(employee);
                    mysqlEmployeeDao.Insert(employee);
                }
            }
        }

        public void CreateExcel2007Reports()
        {
            var reportGenerator = new XlsxReportGenerator();
            var employeeDaoMySql = new EmployeeDao(new MySqlDatabaseConnection(), new MySqlCommandStategy(), new MySqlParameterStrategy());
            var n = new NationalytyDao(new SqliteDatabaseConnection(), new SqliteCommandStrategy(), new SqliteParameterStrategy());

            var employees = employeeDaoMySql.ListAll();
            var nationalities = n.ListAll();

            reportGenerator.GenerateEmployeesReport(employees);
            reportGenerator.GenerateNationalitiesReport(nationalities);
        }
    }
}
