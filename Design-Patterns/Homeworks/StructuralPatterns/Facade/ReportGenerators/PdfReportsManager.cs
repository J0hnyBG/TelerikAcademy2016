namespace Facade.ReportGenerators
{
    using System;

    using Documents;
    using Documents.Contracts;

    public class PdfReportsManager : AbstractReportManager
    {
        protected override IDocumentAdapter CreateDocument(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                throw new ArgumentNullException(nameof(fileLocation));
            }

            return new PdfDocumentAdapter(fileLocation);
        }
    }
}
