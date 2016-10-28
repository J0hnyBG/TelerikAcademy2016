namespace Facade
{
    using ReportGenerators;
    using ReportGenerators.Documents;
    using ReportGenerators.Documents.Contracts;
    using ReportGenerators.Reports;

    internal class Startup
    {
        private static void Main()
        {
            //Composite tree
            AbstractReportManager reportManager = new PdfReportsManager();
            //Composite leaves
            reportManager.Add(new TotalRevenueByDealerReport());
            reportManager.Add(new TopClientReport());

            //Facade
            reportManager.GenerateReports("..\\..\\");

            //Adapter for a PDF, XML, etc. document.
            IDocumentAdapter document = new PdfDocumentAdapter("..\\..\\example");
        }
    }
}
