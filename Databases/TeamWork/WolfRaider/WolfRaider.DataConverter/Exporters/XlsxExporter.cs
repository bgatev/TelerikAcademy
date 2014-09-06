namespace WolfRaider.DataConverter.Exporters
{
    using System.Collections.Generic;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using WolfRaider.Common.Models;

    public class XlsxExporter 
    {
        public IWorkbook ConvertEmployeeCollection(IEnumerable<Employee> employees)
        {
            IWorkbook workbook = new XSSFWorkbook();

            var sheet = this.CreateSheet(workbook);
            int rowNumber = 1;

            foreach (var employee in employees)
            {
                IRow row = sheet.CreateRow(rowNumber++);
                row.CreateCell(0).SetCellValue(employee.EmployeeId.ToString());
                row.CreateCell(1).SetCellValue(employee.FirstName);
                row.CreateCell(2).SetCellValue(employee.LastName);
                row.CreateCell(3).SetCellValue(employee.Age.ToString());

                if (employee.Manager != null)
                {
                    row.CreateCell(4).SetCellValue(employee.Manager.FullName);
                }
                else
                {
                    row.CreateCell(4).SetCellValue("N/A");
                }
            }

            return workbook;
        }

        public IWorkbook CovertEmployee(Employee employee)
        {
            IWorkbook workBook = new XSSFWorkbook();

            ISheet sheet = this.CreateSheet(workBook);
            IRow row = sheet.CreateRow(1);
            row.CreateCell(0).SetCellValue(employee.EmployeeId.ToString());
            row.CreateCell(1).SetCellValue(employee.FirstName);
            row.CreateCell(2).SetCellValue(employee.FirstName);
            
            return workBook;
        }

        public IWorkbook ConvertOccupation(Occupation occupation)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = this.CreateSheet(workBook);

            int rowCounter = 1;

            IRow row = sheet.CreateRow(rowCounter);
            row.CreateCell(0).SetCellValue(occupation.OccupationId.ToString());
            row.CreateCell(1).SetCellValue(occupation.Name);

            return workBook;
        }

        public IWorkbook ConvertOccupations(IEnumerable<Occupation> occupations)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = this.CreateSheet(workBook);

            int rowCounter = 1;

            foreach (var occupation in occupations)
            {
                IRow row = sheet.CreateRow(rowCounter++);
                row.CreateCell(0).SetCellValue(occupation.OccupationId.ToString());
                row.CreateCell(1).SetCellValue(occupation.Name);
            }

            return workBook;
        }

        public IWorkbook ConvertNationality(Nationality nationality)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = this.CreateSheet(workBook);

            int rowCounter = 1;

            IRow row = sheet.CreateRow(rowCounter);
            row.CreateCell(0).SetCellValue(nationality.NationalityId.ToString());
            row.CreateCell(1).SetCellValue(nationality.Name);

            return workBook;
        }

        public IWorkbook ConvertNationalities(IEnumerable<Nationality> nationalities)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = this.CreateSheetNationality(workBook);

            int rowCounter = 1;

            foreach (var nationality in nationalities)
            {
                IRow row = sheet.CreateRow(rowCounter++);
                row.CreateCell(0).SetCellValue(nationality.NationalityId.ToString());
                row.CreateCell(1).SetCellValue(nationality.Name);
            }
            
            return workBook;
        }

        public IWorkbook ConvertPosition(Position position)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = this.CreateSheet(workBook);

            int rowCounter = 1;

            IRow row = sheet.CreateRow(rowCounter);
            row.CreateCell(0).SetCellValue(position.PositionId.ToString());
            row.CreateCell(1).SetCellValue(position.Name);

            return workBook;
        }

        public IWorkbook ConvertPositions(IEnumerable<Position> positions)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = this.CreateSheet(workBook);

            int rowCounter = 1;

            foreach (var position in positions)
            {
                IRow row = sheet.CreateRow(rowCounter++);
                row.CreateCell(0).SetCellValue(position.PositionId.ToString());
                row.CreateCell(1).SetCellValue(position.Name);
            }

            return workBook;
        }

        public IWorkbook ConvertGame(Game game)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = workBook.CreateSheet("Report");
             sheet.CreateRow(0).CreateCell(0).SetCellValue("ID");
            sheet.CreateRow(0).CreateCell(1).SetCellValue("HomeTeam");
            sheet.CreateRow(0).CreateCell(2).SetCellValue("GuestTeam");
            sheet.CreateRow(0).CreateCell(3).SetCellValue("GameDate");

            int rowCounter = 1;
            
            IRow row = sheet.CreateRow(rowCounter);
            row.CreateCell(0).SetCellValue(game.GameId.ToString());
            row.CreateCell(1).SetCellValue(game.HomeTeamId.ToString());
            row.CreateCell(2).SetCellValue(game.GuestTeamId.ToString());
            row.CreateCell(3).SetCellValue(game.PlayedOn.ToString());

            return workBook;
        }

        public IWorkbook ConvertGames(IEnumerable<Game> games)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = workBook.CreateSheet("Report");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("ID");
            sheet.CreateRow(0).CreateCell(1).SetCellValue("HomeTeam");
            sheet.CreateRow(0).CreateCell(2).SetCellValue("GuestTeam");
            sheet.CreateRow(0).CreateCell(3).SetCellValue("GameDate");

            int rowCounter = 1;

            foreach (var game in games)
            {
                IRow row = sheet.CreateRow(rowCounter++);
                row.CreateCell(0).SetCellValue(game.GameId.ToString());
                row.CreateCell(1).SetCellValue(game.HomeTeamId.ToString());
                row.CreateCell(2).SetCellValue(game.GuestTeamId.ToString());
                row.CreateCell(3).SetCellValue(game.PlayedOn.ToString());
            }
            
            return workBook;
        }

        public IWorkbook ConvertSquadHistory(SquadHistory squadHistory)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = workBook.CreateSheet("Report");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("ID");
            sheet.CreateRow(0).CreateCell(1).SetCellValue("Goals");
            sheet.CreateRow(0).CreateCell(2).SetCellValue("Yellowcards");
            sheet.CreateRow(0).CreateCell(3).SetCellValue("RedCards");

            int rowCounter = 1;

            IRow row = sheet.CreateRow(rowCounter);
            row.CreateCell(0).SetCellValue(squadHistory.SquadHistoryId.ToString());
            row.CreateCell(1).SetCellValue(squadHistory.Goals.ToString());
            row.CreateCell(2).SetCellValue(squadHistory.YellowCards.ToString());
            row.CreateCell(3).SetCellValue(squadHistory.RedCards.ToString());

            return workBook;
        }

        public IWorkbook ConvertSquadHistories(IEnumerable<SquadHistory> squadHistories)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = workBook.CreateSheet("Report");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("ID");
            sheet.CreateRow(0).CreateCell(1).SetCellValue("Goals");
            sheet.CreateRow(0).CreateCell(2).SetCellValue("Yellowcards");
            sheet.CreateRow(0).CreateCell(3).SetCellValue("RedCards");

            int rowCounter = 1;

            foreach (var squadHistory in squadHistories)
            {
                IRow row = sheet.CreateRow(rowCounter++);
                row.CreateCell(0).SetCellValue(squadHistory.SquadHistoryId.ToString());
                row.CreateCell(1).SetCellValue(squadHistory.Goals.ToString());
                row.CreateCell(2).SetCellValue(squadHistory.YellowCards.ToString());
                row.CreateCell(3).SetCellValue(squadHistory.RedCards.ToString());
            }

            return workBook;
        }

        public IWorkbook ConvertTeam(Team team)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = this.CreateSheet(workBook);

            int rowCounter = 1;

            IRow row = sheet.CreateRow(rowCounter);
            row.CreateCell(0).SetCellValue(team.TeamId.ToString());
            row.CreateCell(1).SetCellValue(team.Name);

            return workBook;
        }

        public IWorkbook ConvertTeams(IEnumerable<Team> teams)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = this.CreateSheet(workBook);

            int rowCounter = 1;

            foreach (var team in teams)
            {
                IRow row = sheet.CreateRow(rowCounter++);
                row.CreateCell(0).SetCellValue(team.TeamId.ToString());
                row.CreateCell(1).SetCellValue(team.Name);
            }

            return workBook;
        }

        public IWorkbook ConvertWorkHistory(WorkHistory workHistory)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = workBook.CreateSheet("Report");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("ID");
            sheet.CreateRow(0).CreateCell(1).SetCellValue("StartDate");
            sheet.CreateRow(0).CreateCell(2).SetCellValue("EndDate");
            sheet.CreateRow(0).CreateCell(3).SetCellValue("Salary");

            int rowCounter = 1;

            IRow row = sheet.CreateRow(rowCounter);
            row.CreateCell(0).SetCellValue(workHistory.WorkHistoryId.ToString());
            row.CreateCell(1).SetCellValue(workHistory.StartDate.ToString());
            row.CreateCell(2).SetCellValue(workHistory.EndDate.ToString());
            row.CreateCell(3).SetCellValue(workHistory.Salary.ToString());

            return workBook;
        }

        public IWorkbook ConvertWorkHistories(IEnumerable<WorkHistory> workHistories)
        {
            IWorkbook workBook = new XSSFWorkbook();
            ISheet sheet = workBook.CreateSheet("Report");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("ID");
            sheet.CreateRow(0).CreateCell(1).SetCellValue("StartDate");
            sheet.CreateRow(0).CreateCell(2).SetCellValue("EndDate");
            sheet.CreateRow(0).CreateCell(3).SetCellValue("Salary");

            int rowCounter = 1;
            foreach (var workHistory in workHistories)
            {
                IRow row = sheet.CreateRow(rowCounter++);
                row.CreateCell(0).SetCellValue(workHistory.WorkHistoryId.ToString());
                row.CreateCell(1).SetCellValue(workHistory.StartDate.ToString());
                row.CreateCell(2).SetCellValue(workHistory.EndDate.ToString());
                row.CreateCell(3).SetCellValue(workHistory.Salary.ToString());
            }
            
            return workBook;
        }

        private ISheet CreateSheet(IWorkbook workbook)
        {
            ISheet sheet = workbook.CreateSheet("Report");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("Id");
            sheet.GetRow(0).CreateCell(1).SetCellValue("First Name");
            sheet.GetRow(0).CreateCell(2).SetCellValue("Last Name");
            sheet.GetRow(0).CreateCell(3).SetCellValue("Age");
            return sheet;
        }

        private ISheet CreateSheetNationality(IWorkbook workBook)
        {
            ISheet sheet = workBook.CreateSheet("Report Nationalities");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("Id");
            sheet.GetRow(0).CreateCell(1).SetCellValue("Nationality Name");
            return sheet;
        }
    }
}
