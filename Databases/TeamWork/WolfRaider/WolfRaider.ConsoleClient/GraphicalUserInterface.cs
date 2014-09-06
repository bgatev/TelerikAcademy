namespace WolfRaider.ConsoleClient
{
    using System;
    using System.Text;
    using WolfRaider.Application.Core;
    using WolfRaider.Application.Core.Contracts;
    using WolfRaider.ConsoleClient.Contracts;

    public class GraphicalUserInterface
    {
        private readonly ICore core;
        private readonly IPrinter printer;
            
        public GraphicalUserInterface()
            : this(new AppCore(), new ConsolePrinter())
        {
        }

        public GraphicalUserInterface(ICore core, IPrinter printer)
        {
            this.core = core;
            this.printer = printer;
        }

        public void Start()
        {
            this.core.GenerateApplicationFolders();
            this.ShowIntroScreen();
            this.ShowMainMenu();
        }

        private void ShowIntroScreen()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Wolf Raider SQL Tool");

            this.printer.PrintLine(stringBuilder);
        }

        private void ShowMainMenu()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Select a task:");
            stringBuilder.AppendLine("1. Input: MongoDB, Zip, Excel 2003. Output: SQL Server ");
            stringBuilder.AppendLine("2. Input: SQL Server. Output: PDF report.");
            stringBuilder.AppendLine("3. Input: SQL Server database. Output: XML report.");
            stringBuilder.AppendLine(
                "4. Input: SQL Server database. Output: a set of JSON files; data loaded in MySQL database.");
            stringBuilder.AppendLine(
                "5. Input: XML file. Output: data loaded in the SQL Server; data loaded in the MongoDB.");
            stringBuilder.AppendLine("6. Input: SQLite database; MySQL database. Output: Excel 2007 file (.xlsx).");

            this.printer.PrintLine(stringBuilder);

            int taskNumber;

            do
            {
                this.printer.Print("Enter a number: ");

                string text = Console.ReadLine();

                try
                {
                    taskNumber = int.Parse(text);
                    break;
                }
                catch (Exception exception)
                {
                    this.printer.PrintLine(exception.Message);
                }
            }
            while (true);

            switch (taskNumber)
            {
                case 1:
                    this.MongoZipExcelToSqlServer();
                    break;
                case 2:
                    this.SqlServerToPdf();
                    break;
                case 3:
                    this.SqlServerToXlm();
                    break;
                case 4:
                    this.SqlServerToJsonMySql();
                    break;
                case 5:
                    this.XmlToSqlServerMongoDb();
                    break;
                case 6:
                    this.SqliteMySqlToExcel2007();
                    break;

                default:
                    this.printer.PrintLine("Good bye!");
                    break;
            }
        }

        private void SqliteMySqlToExcel2007()
        {
            this.core.CreateExcel2007Reports();
        }

        private void XmlToSqlServerMongoDb()
        {
            this.core.ImportXml();
        }

        private void SqlServerToJsonMySql()
        {
            this.core.CreateJsonReportsMySql();
        }

        private void SqlServerToXlm()
        {
            this.core.CreateXmlReports();
        }

        private void SqlServerToPdf()
        {
            this.core.GeneratePdfReports();
        }

        private void MongoZipExcelToSqlServer()
        {
            this.core.ImportDataFromMongoExcelToSqlServer();
        }
    }
}
