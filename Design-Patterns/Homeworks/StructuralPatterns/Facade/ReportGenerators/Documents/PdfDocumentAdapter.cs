namespace Facade.ReportGenerators.Documents
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Facade.ReportGenerators.Documents.Contracts;

    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.draw;

    public class PdfDocumentAdapter : IDocumentAdapter
    {
        private const float DefaultCellPadding = 10f;
        private const float DefaultGrayFill = 0.9f;
        private const int DefaultColspan = 1;
        private const int CentralAlignment = 1;

        private readonly Document document;

        public PdfDocumentAdapter(string filePathAndName)
        {
            this.document = new Document();
            var fs = new FileStream(filePathAndName + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var wr = PdfWriter.GetInstance(this.document, fs);
        }

        public void Save()
        {
            this.document.Close();
        }

        public IDocumentAdapter AddRow(string text)
        {
            this.document.Add(new Paragraph(text));
            this.document.Add(Chunk.NEWLINE);
            this.document.Add(new LineSeparator());
            this.document.Add(Chunk.NEWLINE);

            return this;
        }

        public IDocumentAdapter AddTable<T>(IEnumerable<T> tableData)
            where T : new()
        {
            if (tableData == null)
            {
                throw new ArgumentNullException(nameof(tableData));
            }

            var modelProperties = typeof(T).GetProperties();
            var table = new PdfPTable(modelProperties.Length);

            foreach (var property in modelProperties)
            {
                var propertyName = property.Name;
                var cell = new PdfPCell(new Phrase(propertyName))
                           {
                               Colspan = DefaultColspan,
                               HorizontalAlignment = CentralAlignment,
                               GrayFill = DefaultGrayFill
                           };
                table.AddCell(cell);
            }

            foreach (var data in tableData)
            {
                foreach (var property in modelProperties)
                {
                    var value = property.GetValue(data);
                    var cellValue = (value ?? "N/A").ToString();

                    var cell = new PdfPCell(new Phrase(cellValue))
                               {
                                   Padding = DefaultCellPadding,
                                   HorizontalAlignment = CentralAlignment
                               };
                    table.AddCell(cell);
                }
            }

            this.document.Add(table);

            return this;
        }

        public IDocumentAdapter NewPage()
        {
            this.document.NewPage();
            return this;
        }

        public IDocumentAdapter AddMetadata()
        {
            this.document.AddTitle("Reports");
            this.document.AddSubject($"A sales report for {DateTime.Now}");
            this.document.AddKeywords("Report, Sales");
            this.document.AddCreator(AppDomain.CurrentDomain.FriendlyName);
            this.document.AddAuthor(AppDomain.CurrentDomain.FriendlyName);
            this.document.Open();
            return this;
        }
    }
}
