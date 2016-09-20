namespace OperationPerformanceTester.Core
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// An utility class which provides methods to run an Action or Func over given test cases and iterations.
    /// </summary>
    public static class Benchmark
    {
        /// <summary>
        /// Runs a specific Func a specified number of times and returns the time it took.
        /// </summary>
        /// <param name="testDelegate">The Func to be invoked.</param>
        /// <param name="testCases">The data, which the testDelegate uses.</param>
        /// <param name="totalIterations">The number of iterations for which all testCases will be repeated.</param>
        /// <returns>The time it took to run the benchmark.</returns>
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

        /// <summary>
        /// Runs a specific Func a specified number of times and returns the time it took.
        /// </summary>
        /// <param name="testDelegate">The Func to be invoked.</param>
        /// <param name="testCases">The data, which the testDelegate uses.</param>
        /// <param name="totalIterations">The number of iterations for which all testCases will be repeated.</param>
        /// <returns>The time it took to run the benchmark.</returns>
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
