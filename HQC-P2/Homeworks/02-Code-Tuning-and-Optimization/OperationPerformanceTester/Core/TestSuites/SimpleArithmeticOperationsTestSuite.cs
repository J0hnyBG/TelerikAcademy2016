namespace OperationPerformanceTester.Core.TestSuites
{
    using System.Numerics;
    using System.Text;

    public class SimpleArithmeticOperationsTestSuite
        : NaiveArithmeticOperationsTestSuite
    {
        public SimpleArithmeticOperationsTestSuite(long totalIterationsPerOperation)
            : base(totalIterationsPerOperation)
        {
            this.Init();
        }

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
