namespace OperationPerformanceTester.Core.TestSuites
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class NaiveArithmeticTestSuite
    {
        protected const string DivisorString = "------------------------------------------------------------------\n";
        protected const string TestResultTemplate = "{0} {1} finished. Average time per run: {2}ms. Total time: {3}ms.\n";
        protected const int TestCaseCount = 20;

        private const int TypeNamePadding = 10;
        private const string ValueMustBeGreaterThanZero = "Value must be greater than 0!";

        private long _totalIterationsPerOperation;

        protected NaiveArithmeticTestSuite(long totalIterationsPerOperation)
        {
            this._totalIterationsPerOperation = totalIterationsPerOperation;
            this.AllTests = new List<Array>();
        }

        protected long TotalIterationsPerOperation
        {
            get
            {
                return this._totalIterationsPerOperation;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.TotalIterationsPerOperation),
                        this.TotalIterationsPerOperation,
                        ValueMustBeGreaterThanZero);
                }

                this._totalIterationsPerOperation = value;
            }
        }

        protected ICollection<Array> AllTests { get; }

        public abstract string GetTestsSummary();

        protected virtual void Init(int valueOffset = 1)
        {
            var decimalTestCases = new decimal[TestCaseCount];
            var doubleTestCases = new double[TestCaseCount];
            var floatTestCases = new float[TestCaseCount];

            for (var i = 0; i < TestCaseCount; i++)
            {
                var value = (i + 1) * valueOffset;
                decimalTestCases[i] = value;
                doubleTestCases[i] = value;
                floatTestCases[i] = value;
            }

            this.AllTests.Add(decimalTestCases);
            this.AllTests.Add(doubleTestCases);
            this.AllTests.Add(floatTestCases);
        }

        protected string GetTestResult(Func<dynamic, dynamic, dynamic> testDelegate, string testName)
        {
            var sb = new StringBuilder();

            foreach (var testCase in this.AllTests)
            {
                var totalTime = TestRunner.BenchmarkTest(
                                                       testDelegate,
                                                       testCase,
                                                       this.TotalIterationsPerOperation);
                var avgTime = totalTime.TotalMilliseconds / this.TotalIterationsPerOperation;

                var typeName = testCase.GetType().Name.TrimEnd('[', ']').PadLeft(TypeNamePadding);
                sb.Append(string.Format(
                                        TestResultTemplate,
                                        typeName,
                                        testName,
                                        $"{avgTime:F8}",
                                        totalTime.TotalMilliseconds));
            }

            return sb.ToString();
        }

        protected string GetTestResult(Action<dynamic> testDelegate, string testName)
        {
            var sb = new StringBuilder();

            foreach (var testCase in this.AllTests)
            {
                var totalTime = TestRunner.BenchmarkTest(
                                                         testDelegate,
                                                         testCase,
                                                         this.TotalIterationsPerOperation);

                var avgTime = totalTime.TotalMilliseconds / this.TotalIterationsPerOperation;

                var typeName = testCase.GetType().Name.TrimEnd('[', ']').PadLeft(TypeNamePadding - 3);

                sb.Append(string.Format(
                                        TestResultTemplate,
                                        typeName,
                                        testName,
                                        $"{avgTime:F8}",
                                        totalTime.TotalMilliseconds));
            }

            return sb.ToString();
        }
    }
}
