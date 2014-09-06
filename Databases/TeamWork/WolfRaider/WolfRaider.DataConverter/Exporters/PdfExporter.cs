namespace WolfRaider.DataConverter.Exporters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public class PdfExporter<T>
    {
        private const string DataListMustHaveAtLeastTwoElements = "Data list must have at least two elements.";

        /// <summary>
        /// Creates a table from T data to add to a PDF document.
        /// </summary>
        /// <param name="data">Single data entity</param>
        /// <param name="widthsFormat">A float array to set column widths. If it is set to null all columns have equal widths.</param>
        /// <returns>PdfPTable table</returns>
        public PdfPTable CreatePdfTable(T data, int colCount, float[] widthsFormat = null)
        {
            PropertyInfo[] columns = data.GetType().GetProperties();
            PdfPTable table = new PdfPTable(colCount);

            if (widthsFormat != null)
            {
                table.SetWidths(widthsFormat);
            }

            this.AddDate(table);
            this.AddHeaderRow(columns, table);
            this.AddEntities(table, columns, data);

            return table;
        }

        public PdfPTable CreatePdfTable(IEnumerable<T> data, int colCount, float[] widthsFormat = null)
        {
            if (data.Count() <= 1)
            {
                throw new ArgumentException(DataListMustHaveAtLeastTwoElements);
            }

            var columns = data.First().GetType().GetProperties();
            var table = new PdfPTable(colCount);

            if (widthsFormat != null)
            {
                table.SetWidths(widthsFormat);
            }

            this.AddDate(table);
            this.AddHeaderRow(columns, table);

            foreach (var item in data)
            {
                PropertyInfo[] entities = item.GetType().GetProperties();
                this.AddEntities(table, entities, item);
            }

            return table;
        }

        /// <summary>
        /// Create PDF table by given array of headers and list of strings
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="entities"></param>
        /// <param name="widthsFormat"></param>
        /// <returns></returns>
        public PdfPTable CreatePdfTable(string[] headers, List<string> entities, float[] widthsFormat = null)
        {
            int colCount = headers.GetLength(0);
            var table = new PdfPTable(colCount);

            if (widthsFormat != null)
            {
                table.SetWidths(widthsFormat);
            }

            this.AddDate(table);
            this.AddHeaderRow(table, headers);
            this.AddEntities(table, entities);
            return table;
        }

        private void AddDate(PdfPTable table)
        {
            Font font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9);

            var date = new PdfPCell(new Phrase("Date: " + DateTime.Now.ToString("MM-dd-yyyy"), font));
            date.BackgroundColor = new BaseColor(200, 200, 200);
            date.Colspan = table.NumberOfColumns;
            date.PaddingLeft = 5;
            date.PaddingBottom = 5;
            date.PaddingRight = 5;
            date.PaddingTop = 5;

            table.AddCell(date);
        }

        private void AddHeaderRow(IEnumerable<PropertyInfo> columns, PdfPTable table)
        {
            Font headerCellFont = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);

            foreach (var colName in columns)
            {
                var headerCell = new PdfPCell(new Phrase(colName.Name, headerCellFont));
                headerCell.BackgroundColor = new BaseColor(200, 200, 200);
                headerCell.PaddingLeft = 5;
                headerCell.PaddingBottom = 5;
                headerCell.PaddingRight = 5;
                headerCell.PaddingTop = 5;
                table.AddCell(headerCell);
            }
        }

        private void AddHeaderRow(PdfPTable table, string[] headers)
        {
            Font headerCellFont = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);

            for (int i = 0; i < headers.GetLength(0); i++)
            {
                var headCell = new PdfPCell(new Phrase(headers[i], headerCellFont));
                headCell.PaddingLeft = 5;
                headCell.PaddingBottom = 5;
                headCell.PaddingRight = 5;
                headCell.PaddingTop = 5;
                headCell.BorderWidthBottom = 2;
                headCell.HorizontalAlignment = 1;

                table.AddCell(headCell);
            }
        }

        private void AddEntities(PdfPTable table, IEnumerable<PropertyInfo> entities, T data)
        {
            Font font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9);

            foreach (var record in entities)
            {
                var recordValue = record.GetValue(data, null);

                if (recordValue == null)
                {
                    recordValue = string.Empty;
                }

                var cell = new PdfPCell(new Phrase(recordValue.ToString(), font));
                cell.PaddingLeft = 5;
                cell.PaddingBottom = 5;
                cell.PaddingRight = 5;
                cell.PaddingTop = 5;

                table.AddCell(cell);
            }
        }

        private void AddEntities(PdfPTable table, List<string> entities)
        {
            Font font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9);

            for (int i = 0; i < entities.Count(); i++)
            {
                var cell = new PdfPCell(new Phrase(entities[i], font));
                cell.PaddingLeft = 5;
                cell.PaddingBottom = 5;
                cell.PaddingRight = 5;
                cell.PaddingTop = 5;
                table.AddCell(cell);
            }
        }
    }
}
