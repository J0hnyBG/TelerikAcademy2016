namespace OperationPerformanceTester.Core.TestSuites
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Provides methods to run a set of given benchmarks.
    /// </summary>
    public abstract class NaiveArithmeticOperationsTestSuite
    {
        protected const string DivisorString = "------------------------------------------------------------------\n";
        protected const string TestResultTemplate = "{0} {1} finished. Average time per run: {2}ms. Total time: {3}ms.\n";
        protected const int TestCaseCount = 20;
        private const int TypeNamePadding = 10;
        private const string ValueMustBeGreaterThanZero = "Value must be greater than 0!";

        private long _totalIterationsPerOperation;

        /// <summary>
        /// Creates a new instance of NaiveArithmeticOperationsTestSuite.
        /// </summary>
        /// <param name="totalIterationsPerOperation">Total number of times each test case will be run</param>
        protected NaiveArithmeticOperationsTestSuite(long totalIterationsPerOperation)
        {
            this._totalIterationsPerOperation = totalIterationsPerOperation;
            this.AllTests = new List<Array>();
        }

        /// <summary>
        /// Gets or sets the total number of times each test case will be run.
        /// </summary>
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

        /// <summary>
        /// Gets all of the cases to be benchmarked.
        /// </summary>
        protected ICollection<Array> AllTests { get; }

        public abstract string GetBenchmarkSummary();

        /// <summary>
        /// Instantiates the cases to be benchmarked.
        /// </summary>
        /// <param name="valueOffset"></param>
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

        /// <summary>
        /// Runs a specific benchmark and returns the results.
        /// </summary>
        /// <param name="testDelegate">A delegate of the action to be benchmarked.</param>
        /// <param name="testName">A name for the delegate.</param>
        /// <returns>A formated string with benchmark results.</returns>
        protected string GetSingleBenchmarkResult(Func<dynamic, dynamic, dynamic> testDelegate, string testName)
        {
            var sb = new StringBuilder();

            foreach (var testCase in this.AllTests)
            {
                TimeSpan totalTime = Benchmark.Run(
                                                   testDelegate,
                                                   testCase,
                                                   this.TotalIterationsPerOperation);
                double avgTimePerSingleRun = totalTime.TotalMilliseconds / this.TotalIterationsPerOperation;

                var typeName = testCase.GetType()
                                       .Name
                                       .TrimEnd('[', ']')
                                       .PadLeft(TypeNamePadding);

                sb.Append(string.Format(
                                        TestResultTemplate,
                                        typeName,
                                        testName,
                                        $"{avgTimePerSingleRun:F8}",
                                        totalTime.TotalMilliseconds));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Runs a specific benchmark and returns the results.
        /// </summary>
        /// <param name="testDelegate">A delegate of the action to be benchmarked.</param>
        /// <param name="testName">A name for the delegate.</param>
        /// <returns>A formated string with benchmark results.</returns>
        protected string GetSingleBenchmarkResult(Action<dynamic> testDelegate, string testName)
        {
            var sb = new StringBuilder();

            foreach (var testCase in this.AllTests)
            {
                TimeSpan totalTime = Benchmark.Run(
                                                   testDelegate,
                                                   testCase,
                                                   this.TotalIterationsPerOperation);
                double avgTimePerSingleRun = totalTime.TotalMilliseconds / this.TotalIterationsPerOperation;

                var typeName = testCase.GetType()
                                       .Name
                                       .TrimEnd('[', ']')
                                       .PadLeft(TypeNamePadding);
                sb.Append(string.Format(
                                        TestResultTemplate,
                                        typeName,
                                        testName,
                                        $"{avgTimePerSingleRun:F8}",
                                        totalTime.TotalMilliseconds));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets a benchmark result and appends it by ref to a Stringbuilder.
        /// </summary>
        /// <param name="testDelegate">A delegate of the action to be benchmarked.</param>
        /// <param name="testName">A name for the delegate.</param>
        protected void AppendSingleBenchmarkResultToStringBuilder(
            ref StringBuilder sb,
            Action<dynamic> testDelegate,
            string testName)
        {
            var result = this.GetSingleBenchmarkResult(testDelegate, testName);
            sb.Append(result);
            sb.Append(DivisorString);
        }

        /// <summary>
        /// Gets a benchmark result and appends it by ref to a Stringbuilder.
        /// </summary>
        /// <param name="testDelegate">A delegate of the action to be benchmarked.</param>
        /// <param name="testName">A name for the delegate.</param>
        protected void AppendSingleBenchmarkResultToStringBuilder(
            ref StringBuilder sb,
            Func<dynamic, dynamic, dynamic> testDelegate,
            string testName)
        {
            var result = this.GetSingleBenchmarkResult(testDelegate, testName);
            sb.Append(result);
            sb.Append(DivisorString);
        }
    }
}
