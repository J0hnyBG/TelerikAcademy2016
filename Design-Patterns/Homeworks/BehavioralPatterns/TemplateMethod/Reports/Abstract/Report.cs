namespace TemplateMethod.Reports.Abstract
{
    using System;

    public abstract class Report
    {
        public void Generate()
        {
            Console.WriteLine("Generating a report..");
            this.AddHeaders();
            this.AddData();
            Console.WriteLine("Done!");
        }

        protected abstract void AddHeaders();

        protected abstract void AddData();
    }
}
