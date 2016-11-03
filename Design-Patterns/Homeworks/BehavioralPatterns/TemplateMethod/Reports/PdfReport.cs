namespace TemplateMethod.Reports
{
    using System;

    using Abstract;

    public class PdfReport : Report
    {
        protected override void AddHeaders()
        {
            Console.WriteLine("Added PDF headers.");
        }

        protected override void AddData()
        {
            Console.WriteLine("Added PDF data.");
        }
    }
}
