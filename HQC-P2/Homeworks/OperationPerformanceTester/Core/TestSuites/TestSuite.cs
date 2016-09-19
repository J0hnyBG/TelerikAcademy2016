using System;
using System.Collections.Generic;

namespace OperationPerformanceTester.Core.TestSuites
{
    public abstract class TestSuite
    {
        private long totalIterationsPerOperation;

        protected TestSuite(long totalIterationsPerOperation)
        {
            this.totalIterationsPerOperation = totalIterationsPerOperation;
            this.AllTests = new List<Array>();
        }

        protected long TotalIterationsPerOperation
        {
            get
            {
                return this.totalIterationsPerOperation;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.TotalIterationsPerOperation),
                        this.TotalIterationsPerOperation,
                        "Value must be greater than 0!");
                }

                this.totalIterationsPerOperation = value;
            }
        }

        protected ICollection<Array> AllTests { get; }

        protected abstract void Init();

        public string RunAll()
        {
            Console.WriteLine($"Starting arithmetic operations tests with ${this.TotalIterationsPerOperation} iterations.");

            foreach (var testCase in this.AllTests)
            {
                var averageTimeFromAllTests = TestRunner.RunPerformanceTests(
                    testCase, 
                    (a, b) => a + b, 
                    this.TotalIterationsPerOperation);

                //Func<T, T, T> addition = (a, b) => a + b;
            }

            return string.Empty;
        }


    }
}
