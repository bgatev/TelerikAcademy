using Microsoft.VisualStudio.TestTools.UnitTesting;
using WolfRaider.Application.ReportGenerators;
using WolfRaider.Common.Models;
using WolfRaider.DatabaseAccess.Connections;

namespace WolfRaider.DataConverter.Tests
{
    [TestClass]
    public class PdfReportGeneratorTests
    {
        private const string path = @"../../../TestResults/";

        private PdfReportGenerator<SquadHistory> pdfReportGeneraotor = new PdfReportGenerator<SquadHistory>();
        private WolfRaiderContext db = new WolfRaiderContext();

        [TestMethod]
        public void CreatePdfFileWithAListOfTestData()
        {
            //IQueryable list = dao.ListAll();

            // string reportTitle = "New List Report";
            //
            //pdfReportGeneraotor.GenerateReport(list, path + "sample-list.pdf", reportTitle);            
        }

        [TestMethod]
        public void CreatePdfFileWithSingleTestData()
        {
            //  var testData = new TestData("Pesho Peshov");

            // float[] widthsFormat = { 3f, 5f };
            // string reportTitle = "New Single Data Record Report";

            // pdfReportGeneraotor.GenerateReport(testData, path + "sample-single-record.pdf",reportTitle, widthsFormat);            
        }

        [TestMethod]
        public void CreatePdfFileWithMultipleTables()
        {
            //  var list = new List<TestData>();
            //  list.Add(new TestData("Pesho Peshov"));
            //  list.Add(new TestData("Gosho Goshov"));
            //  list.Add(new TestData("Vankata Ivanov"));
            //
            //  var secondList = new List<TestData>();
            //  secondList.Add(new TestData("Pesho Peshov"));
            //  secondList.Add(new TestData("Gosho Goshov"));
            //  secondList.Add(new TestData("Vankata Ivanov"));
            //
            //  var multipleData = new List<List<TestData>>();
            //  multipleData.Add(list);
            //  multipleData.Add(secondList);
            //
            //  float[] widthsFormat = { 3f, 5f };
            //  string reportTitle = "New Multiple Tables Report";
            //
            //  pdfReportGeneraotor.GenerateReport(multipleData, path + "sample-multiple-tables.pdf", reportTitle, widthsFormat);
        }
    }
}
