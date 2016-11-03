namespace TemplateMethod
{
    using Reports;
    using Reports.Abstract;

    internal class Startup
    {
        private static void Main()
        {
            Report pdfReport = new PdfReport();
            pdfReport.Generate();

            Report xmlReport = new XmlReport();
            xmlReport.Generate();
        }
    }
}
