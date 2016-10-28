namespace Facade.ReportGenerators.Reports
{
    using System;

    using Contracts;

    using Data;

    using Documents.Contracts;

    public class TopClientReport : IReport
    {
        public void Generate(IDocumentAdapter document)
        {
            var fakeDb = new MockDbContext();
            using (fakeDb)
            {
                var totalRevenueByDealers = fakeDb.GetTotalRevenueByDealers();

                document.AddMetadata()
                        .AddRow($"Top client. Generated on {DateTime.Now}")
                        .AddTable(totalRevenueByDealers)
                        .Save();
            }
        }
    }
}
