using OperationPerformanceTester.Core;
using OperationPerformanceTester.Core.TestSuites;

namespace OperationPerformanceTester
{
    public class Startup
    {
        private static void Main()
        {
            const int RepeatCount = 20000;

            int[] intArr = new int[RepeatCount];

            var averageTimeFromAllTests = TestRunner.RunPerformanceTests(intArr, (a, b) => a + b, RepeatCount);

            //Console.WriteLine($"{intTests.Name} finished in: " + averageTimeFromAllTests + "ms");

            var testSuite = new ArithmeticOperationsTestSuite(RepeatCount);

            testSuite.RunAll();

        }
    }
}
