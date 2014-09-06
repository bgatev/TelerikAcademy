namespace WolfRaider.Application.ReportGenerators
{
    using System.Collections.Generic;
    using System.Linq;

    using iTextSharp.text.pdf;
    using WolfRaider.DataConverter.Exporters;
    using WolfRaider.DataInputOutput;

    public class PdfReportGenerator<T>
    {
        private PdfFileWriter pdfFileWriter;
        private PdfExporter<T> pdfCreator;
 
        public PdfReportGenerator()
            : this(new PdfFileWriter(), new PdfExporter<T>())
        {
        }

        public PdfReportGenerator(PdfFileWriter pdfFileWriter, PdfExporter<T> pdfCreator)
        {
            this.pdfFileWriter = pdfFileWriter;
            this.pdfCreator = pdfCreator;
        }

        /// <summary>
        /// Generates a PDF report from a single entity.
        /// </summary>
        /// <param name="data">Single data entity.</param>
        /// <param name="path">Path to file plus file name</param>
        /// <param name="reportTitle">Report title</param>
        /// <param name="widthsFormat">A float array to set column widths</param>
        public void GenerateReport(T data, string path, string reportTitle, int colCount, float[] widthsFormat = null)
        {
            PdfPTable table = this.pdfCreator.CreatePdfTable(data, colCount, widthsFormat);
            this.pdfFileWriter.Write(path, table, reportTitle);
        }

        /// <summary>
        /// Generates a PDF report from a list of entities.
        /// </summary>
        /// <param name="data">IEnumerable list of entities</param>
        /// <param name="path">Path to file plus file name</param>
        /// <param name="reportTitle">Report title</param>
        /// <param name="widthsFormat">A float array to set column widths</param>
        public void GenerateReport(IEnumerable<T> data, string path, string reportTitle, int colCount, float[] widthsFormat = null)
        {
            PdfPTable table = this.pdfCreator.CreatePdfTable(data, colCount, widthsFormat);
            this.pdfFileWriter.Write(path, table, reportTitle);
        }

        /// <summary>
        /// Generates a PDF report from multiple lists of entities.
        /// </summary>
        /// <param name="data">IEnumerable list of IEnumerable lists of entities</param>
        /// <param name="path">Path to file plus file name</param>
        /// <param name="reportTitle">Report title</param>
        /// <param name="widthsFormat">A float array to set column widths</param>
        public void GenerateReport(IEnumerable<IEnumerable<T>> data, string path, string reportTitle, int colCount, float[] widthsFormat = null)
        {
            List<PdfPTable> tables = new List<PdfPTable>();

            foreach (var collection in data)
            {
                PdfPTable table = this.pdfCreator.CreatePdfTable(collection, colCount, widthsFormat);
                tables.Add(table);
            }

            this.pdfFileWriter.Write(path, tables, reportTitle);
        }

        /// <summary>
        /// Generate Squad History Report
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        /// <param name="reportTitle"></param>
        /// <param name="widthsFormat"></param>
        public void GenerateReport(string[] headers, List<string> entities, string path, string reportTitle, float[] widthsFormat = null)
        {
            PdfPTable table = this.pdfCreator.CreatePdfTable(headers, entities, widthsFormat);
            this.pdfFileWriter.Write(path, table, reportTitle);
        }
    }
}
