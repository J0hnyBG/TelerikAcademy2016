namespace OperationPerformanceTester.Core.TestSuites
{
    using System;
    using System.Text;

    public class AdvancedArithmeticOperationsTestSuite
        : NaiveArithmeticOperationsTestSuite
    {
        private const int ValueOffset = 1000;

        public AdvancedArithmeticOperationsTestSuite(long totalIterationsPerOperation)
            : base(totalIterationsPerOperation)
        {
            base.Init(ValueOffset);
        }

        public override string GetBenchmarkSummary()
        {
            var sb = new StringBuilder();
            sb.Append(NaiveArithmeticOperationsTestSuite.DivisorString);

            this.AppendSingleBenchmarkResultToStringBuilder(ref sb, a => Math.Sin((double)a), "sinus");
            this.AppendSingleBenchmarkResultToStringBuilder(ref sb, a => Math.Sqrt((double)a), "square root");
            this.AppendSingleBenchmarkResultToStringBuilder(ref sb, a => Math.Log((double)a), "natural logarithm");

            return sb.ToString();
        }
    }
}
