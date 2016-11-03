namespace TemplateMethod.Reports
{
    using System;

    using Abstract;

    public class XmlReport : Report
    {
        protected override void AddHeaders()
        {
            Console.WriteLine("Added XML headers.");
        }

        protected override void AddData()
        {
            Console.WriteLine("Added XML data.");
        }
    }
}
