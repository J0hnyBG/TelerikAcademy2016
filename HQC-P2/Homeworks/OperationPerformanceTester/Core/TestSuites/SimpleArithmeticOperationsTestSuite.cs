namespace OperationPerformanceTester.Core.TestSuites
{
    using System.Numerics;
    using System.Text;

    public class SimpleArithmeticOperationsTestSuite
        : NaiveArithmeticTestSuite
    {
        public SimpleArithmeticOperationsTestSuite(long totalIterationsPerOperation)
            : base(totalIterationsPerOperation)
        {
            this.Init();
        }

        public override string GetTestsSummary()
        {
            var sb = new StringBuilder();
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            var additionResult = this.GetTestResult((a, b) => a + b, "addition");
            sb.Append(additionResult);
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            var substractionResult = this.GetTestResult((a, b) => a - b, "substraction");
            sb.Append(substractionResult);
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            var multiplicationResult = this.GetTestResult((a, b) => a * b, "multiplication");
            sb.Append(multiplicationResult);
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            var divisionResult = this.GetTestResult((a, b) => a / b, "division");
            sb.Append(divisionResult);
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            var incrementationResult = this.GetTestResult(a => ++a, "incrementation");
            sb.Append(incrementationResult);
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            return sb.ToString();
        }

        protected sealed override void Init(int valueOffset = 1)
        {
            var testCaseCount = NaiveArithmeticTestSuite.TestCaseCount;

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

            base.Init();
        }
    }
}
