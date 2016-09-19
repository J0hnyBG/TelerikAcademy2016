namespace OperationPerformanceTester.Core.TestSuites
{
    using System;
    using System.Text;

    public class ComplexArithmeticOperationsTestSuite
        : NaiveArithmeticTestSuite
    {
        private const int ValueOffset = 1000;

        public ComplexArithmeticOperationsTestSuite(long totalIterationsPerOperation)
            : base(totalIterationsPerOperation)
        {
            this.Init(ValueOffset);
        }

        public override string GetTestsSummary()
        {
            var sb = new StringBuilder();
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            var sinusResult = this.GetTestResult(
                                                 a => Math.Sin((double)a),
                                                 "sinus");
            sb.Append(sinusResult);
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            var squareRootResult = this.GetTestResult(
                                                      a => Math.Sqrt((double)a),
                                                      "square root");
            sb.Append(squareRootResult);
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            var naturalLogarithmResult = this.GetTestResult(
                                                            a => Math.Log((double)a),
                                                            "natural logarithm");
            sb.Append(naturalLogarithmResult);
            sb.Append(NaiveArithmeticTestSuite.DivisorString);

            return sb.ToString();
        }
    }
}
