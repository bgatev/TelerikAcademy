namespace WolfRaider.DataInputOutput
{
    using System.Collections.Generic;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public class PdfFileWriter
    {
        /// <summary>
        /// Creates a PDF File with a single table.
        /// </summary>
        /// <param name="path">Path to folder plus filename as string.</param>
        /// <param name="table">A table created via PDFExporter.CreatePdfTable method.</param>
        /// <param name="reportTitle">Title/Heading of the report</param>
        public void Write(string path, PdfPTable table, string reportTitle)
        {
            Document document = new Document();

            FileStream fileStream = File.Create(path);
            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            PdfPTable documentHead = this.GetDocumentTitle(reportTitle);
            document.Add(documentHead);
            document.Add(table);
            document.Close();
        }

        /// <summary>
        /// Creates a PDF File with multiple tables.
        /// </summary>
        /// <param name="path">Path to folder plus filename as string.</param>
        /// <param name="tables">A list of tables created via PDFExporter.CreatePdfTable method.</param>
        /// <param name="reportTitle">Title/Heading of the report</param>
        public void Write(string path, IEnumerable<PdfPTable> tables, string reportTitle)
        {
            Document document = new Document();

            FileStream fileStream = File.Create(path);
            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            PdfPTable documentHead = this.GetDocumentTitle(reportTitle);
            document.Add(documentHead);

            foreach (var table in tables)
            {
                document.Add(table);
            }

            document.Close();
        }

        private PdfPTable GetDocumentTitle(string reportTitle)
        {
            if (string.IsNullOrEmpty(reportTitle))
            {
                reportTitle = "Daily Report";
            }

            Font font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 14);
            PdfPTable documentHead = new PdfPTable(1);
            PdfPCell title = new PdfPCell(new Phrase(reportTitle, font));
            title.VerticalAlignment = Element.ALIGN_TOP;
            title.HorizontalAlignment = Element.ALIGN_CENTER;
            title.PaddingLeft = 5;
            title.PaddingBottom = 5;
            title.PaddingRight = 5;
            title.PaddingTop = 5;

            documentHead.AddCell(title);

            return documentHead;
        }
    }
}
