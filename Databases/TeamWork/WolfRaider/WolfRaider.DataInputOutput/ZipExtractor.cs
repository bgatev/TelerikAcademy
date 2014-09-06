namespace WolfRaider.DataInputOutput
{
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.IO.Compression;

    using MongoRepository;
    using WolfRaider.Common.Models;
    using WolfRaider.DatabaseAccess.MongoDB;
    using WolfRaider.DatabaseAccess.SqlServer;

    public class ZipExtractor
    {
        private readonly string extactionFoder;
        private readonly string pathToArchive;
        private readonly string archiveName;

        public ZipExtractor(string pathToArchive, string fileName, string extractFolderName)
        {
            this.pathToArchive = pathToArchive;
            this.archiveName = fileName;
            this.extactionFoder = extractFolderName;
        }

        public void GetAllReports()
        {
            this.ExtractFromArchive();
            this.ParseReports();
        }

        private void ExtractFromArchive()
        {
            ZipFile.ExtractToDirectory(this.pathToArchive + this.archiveName, this.pathToArchive + this.extactionFoder);
        }

        private void ParseReports()
        {
            var allFolders = Directory.GetDirectories(this.pathToArchive + this.extactionFoder);

            foreach (var folder in allFolders)
            {
                var folderName = Path.GetFileName(folder);
                var allFiles = Directory.GetFiles(folder);

                foreach (var file in allFiles)
                {
                    this.ParseExcelFile(folderName, file);
                }
            }
        }

        private void ParseExcelFile(string folderName, string pathOfFile)
        {
            var connectionString =
                string.Format(
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                pathOfFile);

            OleDbConnection excelConnection = new OleDbConnection(connectionString);

            excelConnection.Open();

            using (excelConnection)
            {
                var dataTable = new DataTable();
                var adapter = new OleDbDataAdapter("SELECT * FROM [Employees$] ", excelConnection);

                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    var firstName = row.ItemArray[0].ToString();
                    var lastName = row.ItemArray[1].ToString();
                    var age = int.Parse(row.ItemArray[2].ToString());
                    this.InsertToDatabase(firstName, lastName, age);
                }
            }
        }

        private void InsertToDatabase(string firstName, string lastName, int age)
        {
            var employeeDao = new EmployeeDaoSqlServer();
            var employeeDaoMongoDB = new EmployeeDaoMongoDB();

            var employee = new Employee();
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Age = age;

            employeeDaoMongoDB.Insert(employee);
            employeeDao.Insert(employee);
        }
    }
}
