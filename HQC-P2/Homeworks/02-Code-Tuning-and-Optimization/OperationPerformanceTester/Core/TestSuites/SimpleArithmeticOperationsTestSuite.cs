namespace OperationPerformanceTester.Core.TestSuites
{
    using System.Numerics;
    using System.Text;

    /// <summary>
    /// Provides methods to benchmark the performance of addition, substraction, multiplication, division and incrementation over different data types.
    /// </summary>
    public class SimpleArithmeticOperationsTestSuite
        : NaiveArithmeticOperationsTestSuite
    {
        /// <summary>
        /// Initiates a new instance of SimpleArithmeticOperationsTestSuite.
        /// </summary>
        /// <param name="totalIterationsPerOperation"></param>
        public SimpleArithmeticOperationsTestSuite(long totalIterationsPerOperation)
            : base(totalIterationsPerOperation)
        {
            this.Init();
        }

        /// <summary>
        /// Runs a set of benchmarks and returns their results.
        /// </summary>
        /// <returns>The benchmark results</returns>
        public override string GetBenchmarkSummary()
        {
            var sb = new StringBuilder();
            sb.Append(NaiveArithmeticOperationsTestSuite.DivisorString);

            this.AppendSingleBenchmarkResultToStringBuilder(ref sb, (a, b) => a + b, "addition");
            this.AppendSingleBenchmarkResultToStringBuilder(ref sb, (a, b) => a - b, "substraction");
            this.AppendSingleBenchmarkResultToStringBuilder(ref sb, (a, b) => a * b, "multiplication");
            this.AppendSingleBenchmarkResultToStringBuilder(ref sb, (a, b) => a / b, "division");
            this.AppendSingleBenchmarkResultToStringBuilder(ref sb, a => a++, "incrementation");

            return sb.ToString();
        }

        /// <summary>
        /// Instantiates the cases to be benchmarked.
        /// </summary>
        /// <param name="valueOffset"></param>
        protected sealed override void Init(int valueOffset = 1)
        {
            var testCaseCount = NaiveArithmeticOperationsTestSuite.TestCaseCount;

            var bigIntegerTestCases = new BigInteger[testCaseCount];
            var longTestCases = new long[testCaseCount];
            var intTestCases = new int[testCaseCount];

            for (var i = 0; i < testCaseCount; i++)
            {
                var value = (i + 1) * valueOffset;
                bigIntegerTestCases[i] = value;
                longTestCases[i] = value;
                intTestCases[i] = value;
            }

            this.AllTests.Add(bigIntegerTestCases);
            this.AllTests.Add(longTestCases);
            this.AllTests.Add(intTestCases);

            base.Init(valueOffset);
        }
    }
}
