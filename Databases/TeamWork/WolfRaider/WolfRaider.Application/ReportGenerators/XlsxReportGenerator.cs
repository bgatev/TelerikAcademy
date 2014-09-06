namespace WolfRaider.Application.ReportGenerators
{
    using System;
    using System.Collections.Generic;

    using NPOI.SS.UserModel;
    using WolfRaider.Common.Config;
    using WolfRaider.Common.Models;
    using WolfRaider.DataConverter.Exporters;
    using WolfRaider.DataInputOutput;

    public class XlsxReportGenerator
    {
        private const string FileNameFormat = "{0}.xlsx";
        private const string PathFormat = "{0}\\{1}";

        private XlsxExporter xlsxExporter;
        private TextFileWriter fileWriter;

        public XlsxReportGenerator()
        {
            this.xlsxExporter = new XlsxExporter();
            this.fileWriter = new TextFileWriter();
        }

        public void GenerateEmployeeReport(Employee employee)
        {
            string fileName = "EmployeeReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);

            IWorkbook employeeWorkBook = this.xlsxExporter.CovertEmployee(employee);
            
            this.fileWriter.Write(path, employeeWorkBook);
        }

        public void GenerateEmployeesReport(IEnumerable<Employee> employees)
        {
            string fileName = "EmployeesReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);
            IWorkbook employeesWorkBook = this.xlsxExporter.ConvertEmployeeCollection(employees);

            this.fileWriter.Write(path, employeesWorkBook);
        }

        public void GenerateOccupationReport(Occupation occupation)
        {
            string fileName = "OccupationReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);

            IWorkbook occupationWorkBook = this.xlsxExporter.ConvertOccupation(occupation);

            this.fileWriter.Write(path, occupationWorkBook);
        }

        public void GenerateOccupationsReport(IEnumerable<Occupation> occupations)
        {
            string fileName = "OccupationsReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);

            IWorkbook occupationsWorkBook = this.xlsxExporter.ConvertOccupations(occupations);

            this.fileWriter.Write(path, occupationsWorkBook);
        }

        public void GenerateNationalityReport(Nationality nationality)
        {
            string fileName = "NationalityReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);

            IWorkbook nationalityWorkBook = this.xlsxExporter.ConvertNationality(nationality);

            this.fileWriter.Write(path, nationalityWorkBook);
        }

        public void GenerateNationalitiesReport(IEnumerable<Nationality> nationalities)
        {
            string fileName = "NationalitiesReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);

            IWorkbook nationalitiesWorkBook = this.xlsxExporter.ConvertNationalities(nationalities);

            this.fileWriter.Write(path, nationalitiesWorkBook);
        }

        public void GeneratePositionReport(Position position)
        {
            string fileName = "PositionReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);

            IWorkbook positionWorkBook = this.xlsxExporter.ConvertPosition(position);

            this.fileWriter.Write(path, positionWorkBook);
        }

        public void GeneratePositionsReport(IEnumerable<Position> positions)
        {
            string fileName = "PositionsReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);

            IWorkbook positionsWorkBook = this.xlsxExporter.ConvertPositions(positions);

            this.fileWriter.Write(path, positionsWorkBook);
        }

        public void GenerateGameReport(Game game)
        {
            string fileName = "GameReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);

            IWorkbook gameWorkBook = this.xlsxExporter.ConvertGame(game);

            this.fileWriter.Write(path, gameWorkBook);
        }

        public void GenerateGameReport(IEnumerable<Game> games)
        {
            string fileName = "GamesReport";
            var fullName = string.Format(FileNameFormat, fileName);
            string path = string.Format(PathFormat, Folders.ExcelFolder, fullName);

            IWorkbook gamesWorkBook = this.xlsxExporter.ConvertGames(games);

            this.fileWriter.Write(path, gamesWorkBook);
        }
    }
}
