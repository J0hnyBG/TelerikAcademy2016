namespace OperationPerformanceTester.Core
{
    using System;
    using System.Diagnostics;

    public static class BenchmarkRunner
    {
        public static TimeSpan Run(
            Func<dynamic, dynamic, dynamic> testDelegate,
            dynamic testCases,
            long totalIterations)
        {
            ThrowIfNull(testCases as object);
            ThrowIfNull(testDelegate);

            var timer = new Stopwatch();
            timer.Start();

            for (var k = 0; k < totalIterations; k++)
            {
                dynamic result = testCases[0];
                for (var i = 1; i < testCases.Length; i++)
                {
                    result = testDelegate.Invoke(result, testCases[i]);
                }
            }

            timer.Stop();

            return timer.Elapsed;
        }

        public static TimeSpan Run(
            Action<dynamic> testDelegate,
            dynamic testCases,
            long totalIterations)
        {
            ThrowIfNull(testCases as object);
            ThrowIfNull(testDelegate);

            var timer = new Stopwatch();
            timer.Start();

            for (var k = 0; k < totalIterations; k++)
            {
                for (var i = 0; i < testCases.Length; i++)
                {
                    testDelegate.Invoke(testCases[i]);
                }
            }

            timer.Stop();

            return timer.Elapsed;
        }

        private static void ThrowIfNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
        }
    }
}
