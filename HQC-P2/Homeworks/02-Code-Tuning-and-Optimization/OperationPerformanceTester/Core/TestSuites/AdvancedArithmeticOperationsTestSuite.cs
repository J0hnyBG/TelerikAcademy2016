namespace OperationPerformanceTester.Core.TestSuites
{
    using System;
    using System.Text;

    /// <summary>
    /// Provides methods to benchmark the performance of Math.Sin, Math.Sqrt and Math.Log over different data types.
    /// </summary>
    public class AdvancedArithmeticOperationsTestSuite
        : NaiveArithmeticOperationsTestSuite
    {
        private const int ValueOffset = 1000;

        /// <summary>
        /// Initiates a new instance of AdvancedArithmeticOperationsTestSuite.
        /// </summary>
        /// <param name="totalIterationsPerOperation"></param>
        public AdvancedArithmeticOperationsTestSuite(long totalIterationsPerOperation)
            : base(totalIterationsPerOperation)
        {
            base.Init(ValueOffset);
        }

        /// <summary>
        /// Runs a set of benchmarks and returns their results.
        /// </summary>
        /// <returns>The benchmark results</returns>
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
