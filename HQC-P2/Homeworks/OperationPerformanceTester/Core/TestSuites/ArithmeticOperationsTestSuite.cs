using System.Numerics;

namespace OperationPerformanceTester.Core.TestSuites
{
    public class ArithmeticOperationsTestSuite
        : TestSuite
    {
        public ArithmeticOperationsTestSuite(long totalIterationsPerOperation)
            : base(totalIterationsPerOperation)
        {
            this.Init();
        }

        protected override void Init()
        {
            var bigIntTestCases = new BigInteger[this.TotalIterationsPerOperation];
            var decimalTestCases = new decimal[this.TotalIterationsPerOperation];
            var doubleTestCases = new double[this.TotalIterationsPerOperation];
            var floatTestCases = new float[this.TotalIterationsPerOperation];
            var intTestCases = new int[this.TotalIterationsPerOperation];
            var longTestCases = new long[this.TotalIterationsPerOperation];

            for (var i = 0; i < this.TotalIterationsPerOperation; i++)
            {
                var value = i + 1;
                intTestCases[i] = value;
                longTestCases[i] = value;
                floatTestCases[i] = value;
                doubleTestCases[i] = value;
                decimalTestCases[i] = value;
                bigIntTestCases[i] = value;
            }

            this.AllTests.Add(bigIntTestCases);
            this.AllTests.Add(decimalTestCases);
            this.AllTests.Add(doubleTestCases);
            this.AllTests.Add(floatTestCases);
            this.AllTests.Add(intTestCases);
            this.AllTests.Add(longTestCases);
        }
    }
}
