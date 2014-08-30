using System.Collections.Generic;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WolfRaider.Common.Models;
using WolfRaider.Common.Models.Contracts;
using WolfRaider.DataWriter;

namespace WolfRaider.DataConverter.Exporters
{
    public class XlsxExporter : Exporter
    {
        public XlsxExporter(IDataWriter dataWriter)
            : base(dataWriter)
        {
        }

        public override void Export(IExportable exportable)
        {
        }


        private void PrepareWorkBook(IEnumerable<TestData> list)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Report");

            sheet.CreateRow(0).CreateCell(0).SetCellValue("ID");
            sheet.CreateRow(0).CreateCell(1).SetCellValue("Name");

            int index = 0;
            foreach (var product in list)
            {
                IRow row = sheet.CreateRow(index++);
                row.CreateCell(0).SetCellValue(product.Id.ToString());
                row.CreateCell(1).SetCellValue(product.Name);
            }
        }
    }
}
