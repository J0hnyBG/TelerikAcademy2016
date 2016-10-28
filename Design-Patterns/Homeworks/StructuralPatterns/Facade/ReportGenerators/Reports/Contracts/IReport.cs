namespace Facade.ReportGenerators.Reports.Contracts
{
    using Documents.Contracts;

    public interface IReport
    {
        void Generate(IDocumentAdapter document);
    }
}
