namespace Facade.ReportGenerators.Documents.Contracts
{
    using System.Collections.Generic;

    public interface IDocumentAdapter
    {
        IDocumentAdapter AddRow(string text);

        IDocumentAdapter AddTable<T>(IEnumerable<T> tableData)
            where T : new();

        IDocumentAdapter NewPage();

        IDocumentAdapter AddMetadata();

        void Save();
    }
}
